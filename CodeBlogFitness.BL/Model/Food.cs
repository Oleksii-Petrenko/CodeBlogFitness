using System;


namespace CodeBlogFitness.BL.Model
{
    [Serializable]
    public class Food
    {
        public string Name { get;}
        /// <summary>
        /// Белки.
        /// </summary>
        public double Proteins { get; }
        /// <summary>
        /// Жиры.
        /// </summary>
        public double Fat { get; }
        /// <summary>
        /// Углеводи.
        /// </summary>
        public double Carbohydrates { get; }
        /// <summary>
        /// Калории за 100 грамм продукта.
        /// </summary>
        public double Callories { get; }


        /// <summary>
        /// Калории за 1 грамм.
        /// </summary>
        private double CalloriesOneGramm { get {return Callories / 100.0; } }
        /// <summary>
        /// Жиры за 1 грамм.
        /// </summary>
        private double FatOneGramm { get { return Fat / 100.0; } }
        /// <summary>
        /// Протеины за 1 грамм.
        /// </summary>
        private double ProteinsOneGramm { get { return Proteins / 100.0; } }
        /// <summary>
        /// Углеводы за 1 грамм.
        /// </summary>
        private double CarbohydratesOneGramm { get { return Carbohydrates / 100.0; } }

        public Food(string name) : this(name, 0, 0, 0, 0) { }
        
        public Food(string name, double proteins, double callories , double fat, double carbohydrates)
        {
            //TODO: Проверка.


            Name = name;
            Proteins = proteins / 100.0;
            Callories = callories / 100.0;
            Fat = fat / 100.0;
            Carbohydrates = carbohydrates / 100.0;
        }

        public override string ToString()
        {
            return Name; 
        }


    }
}
