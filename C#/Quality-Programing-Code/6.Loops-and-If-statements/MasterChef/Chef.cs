namespace MasterChef
{
    using System;
    using System.Linq;

    public class Chef
    {
        public void Cook()
        {
            var potato = this.GetPotato();
            var carrot = this.GetCarrot();
            var bowl = this.GetBowl();

            this.Peel(potato);
            this.Peel(carrot);

            this.Cut(potato);
            this.Cut(carrot);

            bowl.Add(carrot);
            bowl.Add(potato);

            ////Task 2 below
            if (potato != null) 
            {
                if (potato.IsPeeled && !potato.IsRotten) 
                {
                    this.Cook(potato);
                }
            }
        }

        private void Cook(Vegetable vegetable) 
        {
            Console.WriteLine("Cooking {0}", vegetable);
        }

        private Bowl GetBowl()
        {
            Console.WriteLine("Getting Bowl");
            return new Bowl(); 
        }

        private Carrot GetCarrot()
        {
            Console.WriteLine("Getting Carrot");
            return new Carrot();
        }

        private Potato GetPotato()
        {
            Console.WriteLine("Getting Potato");
            return new Potato();
        }

        private void Cut(Vegetable vegetable)
        {
            Console.WriteLine("Cutting {0}...", vegetable);
        }

        private void Peel(Vegetable vegetable) 
        {
            Console.WriteLine("Peeling {0}", vegetable);
        }
    }
}
