namespace Pokedex.WebAPI.Extensions;

public static class TaskExtensions
{
    public static async Task<IEnumerable<T>> RunTasksInParallel<T>(this IEnumerable<Task<T>> tasks, int maxDegreeOfParallelism)
    {
        using (var semaphore = new SemaphoreSlim(maxDegreeOfParallelism))
        {
            var runningTasks = new List<Task<T>>();

            foreach (var task in tasks)
            {
                await semaphore.WaitAsync().ConfigureAwait(false);

                runningTasks.Add(Task.Run(async () =>
                {
                    try
                    {
                        return await task.ConfigureAwait(false);
                    }
                    finally
                    {
                        semaphore.Release();
                    }
                }));
            }

            return await Task.WhenAll(runningTasks).ConfigureAwait(false);
        }
    }
}
