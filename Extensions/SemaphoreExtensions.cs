namespace Semaphoria.Extensions
{
    public static class SemaphoreExtensions
    {
        public static bool IsFull(this SemaphoreSlim semaphore) => semaphore.CurrentCount.Equals(0);
    }
}