using System.Threading;

namespace Dishwasher
{
    class Rack
    {
        private int maxCapacity;
        public int capacity { get; set; } = 0;
        private Semaphore rackSemaphore = new Semaphore(0, 1);

        public Rack(int maxCapacity) => this.maxCapacity = maxCapacity;

        public bool IsRackFull() => capacity == maxCapacity;

        public bool IsRackEmpty() => capacity == 0;

        public void AddPlate() => capacity++;

        public void RemovePlate() => capacity--;

        public void HoldSemaphore(string name)
        {
            while (IsRackFull() || IsRackEmpty())
                rackSemaphore.WaitOne();
        }

        public void ReleaseSemaphore(string name)
        {
            if (rackSemaphore.WaitOne(0))
                return;
            rackSemaphore.Release();
        }
    }
}
