using System;

namespace CodeBlogFitness.BL.Model
{
    [Serializable]
    public class Activity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double CaloriesPerMinute { get; set; }

        public Activity(string name, double caloriesPerMinutes)
        {
            // Проверка

            Name = name;
            CaloriesPerMinute = caloriesPerMinutes;

        }


        public override string ToString()
        {
            return Name; 
        }



    }
}
