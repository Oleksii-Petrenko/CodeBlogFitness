using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
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
        public List<Eating> Eatings { get; }


        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустим", nameof(user));
            Foods = GetAllFoods();
            Eatings = GetAllEatings();
        }

        private List<Eating> GetAllEatings()
        {
            return Load<List<Eating>>(EATINGS_FILE_NAME) ?? new List<Eating>();
        }

        private List<Food> GetAllFoods()
        {
            return Load<List<Food>>(FOODS_FILE_NAME) ?? new List<Food>();

        }

        private void Save()
        {
            Save(FOODS_FILE_NAME, Foods);
            Save(EATINGS_FILE_NAME, Eatings);
        }

    }
}
