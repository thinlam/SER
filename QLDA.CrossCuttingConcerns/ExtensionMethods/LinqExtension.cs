using System.Linq.Expressions;

namespace SharedKernel.CrossCuttingConcerns.ExtensionMethods {
    public static class LinqExtension {
        public static IQueryable<TSource> WhereIf<TSource>(this IQueryable<TSource> source,
            bool condition,
            Expression<Func<TSource, bool>> whenTrue,
            Expression<Func<TSource, bool>>? whenFalse = null)
            => condition ? source.Where(whenTrue) : whenFalse != null ? source.Where(whenFalse) : source;

        public static IQueryable<TSource> WhereFunc<TSource>(this IQueryable<TSource> source,
            bool condition,
            Func<IQueryable<TSource>, IQueryable<TSource>> applyIfTrue,
            Func<IQueryable<TSource>, IQueryable<TSource>>? applyIfFalse = null)
            => condition ? applyIfTrue(source) : applyIfFalse?.Invoke(source) ?? source;

        #region Left Join

        private static Expression<Func<TOuter, TInner, TResult>> CastSMLambda<TOuter, TInner, TResult>(
            LambdaExpression ex, TOuter _1, TInner _2, TResult _3) => (Expression<Func<TOuter, TInner, TResult>>)ex;

        public static IQueryable<TResult> LeftOuterJoin<TOuter, TInner, TKey, TResult>(
            this IQueryable<TOuter> outer,
            IQueryable<TInner> inner,
            Expression<Func<TOuter, TKey>> outerKeySelector,
            Expression<Func<TInner, TKey>> innerKeySelector,
            Expression<Func<TOuter, TInner, TResult>> resExpr) {
            var gjResTemplate = new { outer = default(TOuter)!, innerj = default(IEnumerable<TInner>)! };
            // typeof(new { outer, innerj }) oij
            var oijParm = Expression.Parameter(gjResTemplate.GetType(), "oij");
            // TInner inner
            var iParm = Expression.Parameter(typeof(TInner), "inner");
            // oij.outer
            var oijOuter = Expression.PropertyOrField(oijParm, "outer");
            // (oij,inner) => resExpr(oij.outer, inner)
            var selectResExpr = CastSMLambda(Expression.Lambda(resExpr.Apply(oijOuter, iParm)!, oijParm, iParm),
                gjResTemplate, default(TInner), default(TResult));

            return outer.GroupJoin(inner, outerKeySelector, innerKeySelector, (outer, innerj) => new { outer, innerj })!
                .SelectMany(r => r.innerj!.DefaultIfEmpty(), selectResExpr)!;
        }

        // Apply: (x => f).Apply(args)
        /// <summary>
        /// Substitutes an array of Expression args for the parameters of a lambda, returning a new Expression
        /// </summary>
        /// <param name="e">The original LambdaExpression to "call".</param>
        /// <param name="args">The Expression[] of values to substitute for the parameters of e.</param>
        /// <returns>Expression representing e.Body with args substituted in</returns>
        public static Expression? Apply(this LambdaExpression e, params Expression[] args) {
            var b = e.Body;

            foreach (var pa in e.Parameters.Zip(args, (p, a) => (p, a)))
                b = b.Replace(pa.p, pa.a);

            return b?.PropagateNull();
        }

        /// <summary>
        /// Replaces an Expression (reference Equals) with another Expression
        /// </summary>
        /// <param name="orig">The original Expression.</param>
        /// <param name="from">The from Expression.</param>
        /// <param name="to">The to Expression.</param>
        /// <returns>Expression with all occurrences of from replaced with to</returns>
        public static T? Replace<T>(this T? orig, Expression from, Expression to) where T : Expression =>
            (T?)new ReplaceVisitor(from, to).Visit(orig);

        /// <summary>
        /// ExpressionVisitor to replace an Expression (that is Equals) with another Expression.
        /// </summary>
        public class ReplaceVisitor : ExpressionVisitor {
            private readonly Expression from;
            private readonly Expression to;

            public ReplaceVisitor(Expression from, Expression to) {
                this.from = from;
                this.to = to;
            }

            public override Expression? Visit(Expression? node) => node == from ? to : base.Visit(node);
        }

        public static T? PropagateNull<T>(this T orig) where T : Expression => (T?)new NullVisitor().Visit(orig);

        /// <summary>
        /// ExpressionVisitor to replace a null.member Expression with a null
        /// </summary>
        public class NullVisitor : System.Linq.Expressions.ExpressionVisitor {
            public override Expression? Visit(Expression? node) {
                if (node is MemberExpression nme && nme.Expression is ConstantExpression nce && nce.Value == null)
                    return Expression.Constant(null, nce.Type.GetMember(nme.Member.Name).Single().GetType());
                else
                    return base.Visit(node);
            }
        }

        #endregion Left Join

    }
}