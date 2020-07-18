using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeBlogFitness.BL.Controler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBlogFitness.BL.Model;

namespace CodeBlogFitness.BL.Controler.Tests
{
    [TestClass()]
    public class ExerciseControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            // Arrange
            var userName = Guid.NewGuid().ToString();
            var avtivityName = Guid.NewGuid().ToString();
            var rnd = new Random();


            var userController = new UserController(userName);
            var exerciseController  = new ExerciseController(userController.CurrentUser);
            var activity = new Activity(avtivityName, rnd.Next(10, 50 ));

            // Act

            exerciseController.Add(activity, DateTime.Now, DateTime.Now.AddHours(1));


            // Assert


            Assert.AreEqual(avtivityName, exerciseController.Activities.First().Name);
        }
    }
}