using CodeBlogFitness.BL.Model;
using System;


namespace CodeBlogFitness.BL.Controler
{
    class DatabaseDataSaver : IDatasaver
    {
        T IDatasaver.Load<T>(string fileName)
        {
            
            using (var db = new FitnessContext()) 
            {
                var result = db.Set<T>().Where(k => true).ToList();

            }

        }

        void IDatasaver.Save(string fileName, object item)
        {

            using (var db = new FitnessContext())
            {

                var type = item.GetType();


                if (type == typeof(User))
                {
                    db.Users.Add(item as User);
                }
                else if (type == typeof(Gender))
                {
                    db.Genders.Add(item as Gender);
                }
                else if (type == typeof(Gender))
                {
                    db.Foods.Add(item as Food);
                }
                else if (type == typeof(Exercise))
                {
                    db.Exercises.Add(item as Exercise);
                }
                else if (type == typeof(Eating))
                {
                    db.Eatings.Add(item as Eating);
                }
                else if (type == typeof(Activity))
                {
                    db.Activities.Add(item as Activity);
                }


                db.SaveChanges();


            }
        }
    }
}
