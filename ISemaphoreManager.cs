namespace Semaphoria
{
    public interface ISemaphoreManager
    {
        Task WaitAsync(string semaphoreName, CancellationToken cancellationToken = default);
        void Wait(string semaphoreName);
        void Release(string semaphoreName);
        int CurrentCount(string semaphoreName);
        bool IsFull(string semaphoreName);
        SemaphoreSlim Get(string semaphoreName);
    }
}