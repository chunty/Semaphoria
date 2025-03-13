using Semaphoria.Extensions;

namespace Semaphoria
{
    public class SemaphoreManager : ISemaphoreManager
    {
        private readonly Dictionary<string, SemaphoreSlim> _semaphores = [];
        public int NumSlots { get; set; } = 1;

        public async Task WaitAsync(string semaphoreName, CancellationToken cancellationToken = default) =>
            await Get(semaphoreName).WaitAsync(cancellationToken);

        public void Wait(string semaphoreName) => Get(semaphoreName).Wait();

        public void Release(string semaphoreName) => Get(semaphoreName).Release();
        public int CurrentCount(string semaphoreName) => Get(semaphoreName).CurrentCount;

        // CurrentCount is the number of slots left. NOT the number of slots in use.
        public bool IsFull(string semaphoreName) => Get(semaphoreName).IsFull();

        public SemaphoreSlim Get(string semaphoreName)
        {
            if (_semaphores.TryGetValue(semaphoreName, out SemaphoreSlim? semaphore))
            {
                return semaphore;
            }

            semaphore = new SemaphoreSlim(NumSlots, NumSlots);
            _semaphores.Add(semaphoreName, semaphore);

            return semaphore;
        }
    }
}