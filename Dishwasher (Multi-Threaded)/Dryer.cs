using System;
using System.Threading.Tasks;
using System.Threading;

namespace Dishwasher
{
    class Dryer
    {
        private int dryerTime;
        private int numberOfPlates;
        public static bool isDryerBusy;
        Rack rack;
        Random random = new Random();

        public Dryer(int dryerTime, Rack rack)
        {
            this.dryerTime = dryerTime;
            this.rack = rack;
        }

        public async void StartDryerAsync(int numberOfPlates)
        {
            this.numberOfPlates = numberOfPlates;
            isDryerBusy = true;
            for (int i = 1; i <= numberOfPlates; i++)
                await Task.Run(() => DryDish(i));
            isDryerBusy = false;
        }

        private void DryDish(int plateNumber)
        {
            if (rack.IsRackEmpty())
            {
                Console.WriteLine("Dryer is waiting");
                rack.HoldSemaphore("dryer");
            }
            else if (rack.IsRackFull() && Washer.isWasherBusy)
            {
                rack.ReleaseSemaphore("dryer");
            }
            rack.RemovePlate();
            Console.WriteLine("Dryer is drying dish #" + plateNumber);
            Thread.Sleep(random.Next(dryerTime * 1000));
            Console.WriteLine("Dryer has finished drying dish #{0}", plateNumber);
            if (plateNumber == numberOfPlates)
                Console.WriteLine("DRYER FINISHED");
        }
    }
}
