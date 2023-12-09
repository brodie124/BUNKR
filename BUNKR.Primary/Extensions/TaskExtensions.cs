namespace BUNKR.Primary.Extensions;

public static class TaskExtensions
{
    public static async Task LogExceptions(this Task task, ILogger logger)
    {
        try
        {
            await task.ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            // TODO: log exceptions properly here
            logger.LogError(ex, "An exception occurred while running a task");
        }
    }
}