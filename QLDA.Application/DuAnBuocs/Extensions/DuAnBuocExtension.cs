using QLDA.Application.DanhMucBuocs.DTOs;

namespace QLDA.Application.DuAnBuocs.Extensions {
    public static class DuAnBuocExtensions {
        /// <summary>
        /// Xây dựng danh sách cây tuần tự với định dạng tiêu đề dạng số La Mã cho cấp gốc và phân cấp tiếp theo.
        /// </summary>
        /// <param name="items">Danh sách các bước dự án chưa sắp xếp.</param>
        /// <returns>Danh sách bước dự án đã sắp xếp và gán lại TenBuoc có định dạng phân cấp.</returns>
        public static List<StepDto> ToTreeList(this IEnumerable<StepDto> items) {
            var all = items.ToList();
            // Build lookup: ParentId -> children
            var childrenLookup = all
                .Where(x => x.ParentId > 0)
                .GroupBy(x => x.ParentId)
                .ToDictionary(g => g.Key, g => g.OrderBy(c => c.Level).ThenBy(c => c.Stt).ThenBy(c => c.Id).ToList());

            // Lấy các root nodes, sort theo Level, Stt, Id
            var roots = all
                .Where(x => x.ParentId == 0)
                .OrderBy(x => x.Level)
                .ThenBy(x => x.Stt)
                .ThenBy(x => x.Id)
                .ToList();

            var result = new List<StepDto>();
            int counter = 1;
            foreach (var root in roots) {
                var prefix = NumberExtension.ToRoman(counter++);
                Traverse(root, prefix, childrenLookup, result);
            }

            return result;
        }

        private static void Traverse(
            StepDto node,
            string prefix,
            Dictionary<int, List<StepDto>> childrenLookup,
            List<StepDto> result) {
            // Gán lại tên bước có prefix
            node.Ten = $"{prefix}. {node.Ten}";
            result.Add(node);

            if (!childrenLookup.TryGetValue(node.BuocId ?? node.Id, out var children))
                return;

            int idx = 1;
            foreach (var child in children) {
                var childPrefix = node.Level == 0 ? idx.ToString() : $"{prefix}.{idx}";
                idx++;
                Traverse(child, childPrefix, childrenLookup, result);
            }
        }


    }
}