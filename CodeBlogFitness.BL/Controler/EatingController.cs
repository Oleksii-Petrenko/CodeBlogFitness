using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters.Binary;

namespace CodeBlogFitness.BL.Controler
{
    public class EatingController : ControllerBase
    {
        private const string FOODS_FILE_NAME = "Foods.dat";
        private const string EATINGS_FILE_NAME = "eatings.dat";

        private User user;
        public List<Food> Foods { get; }
        public Eating Eating { get; }


        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустим", nameof(user));
            Foods = GetAllFoods();
            Eating = GetEating();
        }
               
        public void Add(Food food, double weigth)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weigth);
                Save();
            }
            else
            {
                Eating.Add(product, weigth);
                Save();
            }

        }

        private Eating GetEating()
        {
            return Load<Eating>(EATINGS_FILE_NAME) ?? new Eating(user);
        }

        private List<Food> GetAllFoods()
        {
            return Load<List<Food>>(FOODS_FILE_NAME) ?? new List<Food>();

        }

        private void Save()
        {
            Save(FOODS_FILE_NAME, Foods);
            Save(EATINGS_FILE_NAME, Eating);
        }

    }
}
