using System;
using System.Threading.Tasks;
using System.Threading;

namespace Dishwasher
{
    class Washer
    {
        private int dishWashTime;
        private int numberOfPlates;
        public static bool isWasherBusy;
        Random random = new Random();
        Rack rack;

        public Washer(int dishWashTime, Rack rack)
        {
            this.dishWashTime = dishWashTime;
            this.rack = rack;
        }

        public async void StartWasherAsync(int numberOfPlates)
        {
            this.numberOfPlates = numberOfPlates;
            isWasherBusy = true;
            for (int i = 1; i <= numberOfPlates; i++)
                await Task.Run(() => WashDish(i));
            isWasherBusy = false;
        }

        private void WashDish(int plateNumber)
        {
            if (rack.IsRackFull())
            {
                Console.WriteLine("Washer is waiting");
                rack.HoldSemaphore("washer");
            }
            Console.WriteLine("Washer is washing dish #" + plateNumber);
            Thread.Sleep(random.Next(dishWashTime * 1000));
            Console.WriteLine("Washer added dish #{0} to the rack", plateNumber);
            rack.AddPlate();
            if (rack.capacity == 1)
                rack.ReleaseSemaphore("washer");
            if (plateNumber == numberOfPlates)
                Console.WriteLine("WASHER FINISHED");
        }
    }
}
