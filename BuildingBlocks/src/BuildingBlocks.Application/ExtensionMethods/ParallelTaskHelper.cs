namespace BuildingBlocks.Application.ExtensionMethods;

/// <summary>
/// Helper methods for Task parallel execution with error context
/// </summary>
public static class ParallelTaskHelper
{
    /// <summary>
    /// Awaits all tasks and provides context about which task failed on exception.
    /// </summary>
    public static async Task WhenAllWithNames(params (string Name, Task Task)[] tasks)
    {
        var allTasks = tasks.Select(t => t.Task).ToArray();
        try
        {
            await Task.WhenAll(allTasks);
        }
        catch (Exception ex)
        {
            // Find which task(s) faulted
            var faultedNames = tasks
                .Where(t => t.Task.IsFaulted)
                .Select(t => t.Name)
                .ToList();

            if (faultedNames.Count != 0)
            {
                var innerEx = allTasks
                    .Where(t => t.IsFaulted)
                    .Select(t => t.Exception?.InnerException ?? t.Exception)
                    .FirstOrDefault();

                throw new InvalidOperationException(
                    $"Parallel task(s) failed: [{string.Join(", ", faultedNames)}]. {innerEx?.Message}",
                    innerEx ?? ex);
            }

            throw;
        }
    }
}