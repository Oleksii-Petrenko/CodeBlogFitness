using CodeBlogFitness.BL.Controler;
using System;


namespace CodeBlogFitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас привествует приложение CodeBlogFitness - App say Hello");

            Console.WriteLine("Введите имя пользователя - Enter name");
            var name = Console.ReadLine();



            var userController = new UserController(name);
            if (userController.IsNewUser)
            {
                Console.WriteLine("Введите пол - Enter Gender");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime();
                var weigth = ParsedDouble("вес - weigth");
                var heigth = ParsedDouble("рост - heigth");

                

                userController.SetNewUserData(gender, birthDate, weigth, heigth);

            }


            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("Что вы хотите сделать? = What you wonna to do ?");
            Console.WriteLine("E - ввести прием пищи - pres E to add food");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.E)
            {
                EnterEating();
            }


            Console.ReadLine();
            
        }

        private static Food EnterEating()
        {
            Console.WriteLine("Введите имя продукта - Enter product name please");
            var food = Console.ReadLine();
            Console.WriteLine("Введите вес порции, Enter weigth of food");
            var weigth = ParsedDouble("вес порции");

            
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {


                Console.WriteLine("Дату рождения - Enter Birthday (dd.MM.yyyy)");

                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный формат даты");
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
