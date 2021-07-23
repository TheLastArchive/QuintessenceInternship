using System.Threading;

namespace Dishwasher
{
    class ThreadHandler
    {
        private int numberOfPlates;
        private Rack rack;
        private Washer washer;
        private Dryer dryer;

        public ThreadHandler(int numberOfPlates, int rackCapacity, int washerTime, int dryerTime)
        {
            this.numberOfPlates = numberOfPlates;
            rack = new Rack(rackCapacity);
            washer = new Washer(washerTime, rack);
            dryer = new Dryer(dryerTime, rack);
        }

        public void CreateAndRunWasherAndDryerThreads()
        {
            Thread washerThread = new Thread(() => washer.StartWasherAsync(numberOfPlates));
            washerThread.Start();
            Thread dryerThread = new Thread(() => dryer.StartDryerAsync(numberOfPlates));
            dryerThread.Start();
        }
    }
}
