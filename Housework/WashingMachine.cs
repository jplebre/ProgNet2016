using System;

namespace Housework
{
    public class WashingMachine
    {
        private readonly HouseworkSimulator sim;

        public WashingMachine(HouseworkSimulator sim)
        {
            this.sim = sim;
        }

        public void Wash(Laundry laundry)
        {
            int randomNumber = new Random().Next(1, 5);

            if (randomNumber < 2.5)
            {
                sim.DoWork(TimeSpan.FromHours(randomNumber));
                sim.Report("(washing machine has caught fire!!!!)");
                laundry.State = LaundryState.OnFire;
                throw new Exception("Your clothes are on Fire!!!!!");
            }

            sim.DoWork(TimeSpan.FromHours(2.5));
            laundry.State = LaundryState.Wet;
            sim.Report("(washing machine has finished)");
        }
    }
}