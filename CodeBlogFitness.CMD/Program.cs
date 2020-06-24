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


            Console.WriteLine("Введите пол - Enter Gender ");
            var gender = Console.ReadLine();

            Console.WriteLine("Введите дату рождение  - Enter birdthDay ");
            var birdthdate = DateTime.Parse(Console.ReadLine()); //TODO: переписать

            Console.WriteLine("Введите вес - Enter Weigth ");
            var weigth = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите вес - Enter Heigth ");
            var heigth = double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, birdthdate, weigth,heigth);
            userController.Save();
        }
    }
}
