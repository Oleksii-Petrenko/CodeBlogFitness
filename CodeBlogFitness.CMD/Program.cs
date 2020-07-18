using CodeBlogFitness.BL.Controler;
using CodeBlogFitness.BL.Model;
using System;
using System.Globalization;
using System.Resources;

namespace CodeBlogFitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            // создаем культуру
            var culture = CultureInfo.CreateSpecificCulture("en-us");

            // менеджер ресурсов
            var resourseManager = new ResourceManager("CodeBlogFitness.CMD.Langluages.Messages_ru_ru", typeof(Program).Assembly);


            Console.WriteLine(resourseManager.GetString("Hello", culture));

            Console.WriteLine(resourseManager.GetString("EnterName", culture));
            var name = Console.ReadLine();



            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.WriteLine("Введите пол - Enter Gender");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime("Дата рождение - day of birthdate");
                var weigth = ParsedDouble("вес - weigth");
                var heigth = ParsedDouble("рост - heigth");

                

                userController.SetNewUserData(gender, birthDate, weigth, heigth);

            }

            
            Console.WriteLine(userController.CurrentUser);



            while (true)
            {
                Console.WriteLine("Что вы хотите сделать? = What you wonna to do ?");
                Console.WriteLine("E - ввести прием пищи - pres E to add food");
                Console.WriteLine("A - ввести упраженения - pres E to add exercise");
                Console.WriteLine("Q - выход - pres Q to exit");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weigth);


                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }
                        break;
                    case ConsoleKey.A:
                        var exe = EnterExercises();

                        exerciseController.Add(exe.Activity, exe.Begin, exe.End);
                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity} c {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()} ");
                        }
                        break;


                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;


                }


                Console.ReadLine();
            }
        }

        private static (DateTime Begin, DateTime End, Activity Activity) EnterExercises()
        {
            Console.WriteLine("Введите название упражнения - Enter exercise name");
            var name = Console.ReadLine();

            var energy = ParsedDouble("расход енергии в минуту - lost energy in minute");

            var begin = ParseDateTime("начало упражнения - begin exercise time ");
            var end = ParseDateTime("конец упражнения - end exercise time ");

            var activity = new Activity(name, energy);

            return (begin, end, activity);


        }

        private static (Food Food,double Weigth) EnterEating()
        {
            Console.WriteLine("Введите имя продукта - Enter product name please");
            var food = Console.ReadLine();
            

            Console.WriteLine("Ведите калорийность - :");

            var calories = ParsedDouble("Калорийность ");
            var prot = ParsedDouble("Белки ");
            var fats = ParsedDouble("жири ");
            var carbs = ParsedDouble("углеводи");



            var weigth = ParsedDouble("вес порции");
            var product = new Food(food, prot, calories, fats, carbs);


            return (Food: product, Weigth: weigth);
            
        }

        private static DateTime ParseDateTime(string value)
        {
            DateTime birthDate;
            while (true)
            {


                Console.Write($"ВВедите Дату рождения {value} - Enter Birthday (dd.MM.yyyy): ");

                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {value}");
                }

            }

            return birthDate;
        }

        private static double ParsedDouble(string name)
        {
            while (true)
            {


                Console.WriteLine($"Введите {name}");

                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат поля {name}");
                }

            }
        }
    }
}
