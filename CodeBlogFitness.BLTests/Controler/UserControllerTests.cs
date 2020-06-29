using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeBlogFitness.BL.Controler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Controler.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        
        [TestMethod()]
        public void SetNewUserDataTest()
        {
            // Arrange - данные которые подаютса на вход

            var userName = Guid.NewGuid().ToString();
            var gender = "m";
            var birthdate = DateTime.Now.AddYears(-18);
            var weigth = 90;
            var heigth = 185;
            var controller = new UserController(userName);

            // Act - действие когда мы ызываем что-то

            controller.SetNewUserData(gender, birthdate, weigth, heigth);

            var controller2 = new UserController(userName);

            // Assert - когда мы проверяем то что получилось и то что ожидалось

            Assert.AreEqual(userName, controller2.CurrentUser.Name);
            Assert.AreEqual(gender, controller2.CurrentUser.Gender);
            Assert.AreEqual(birthdate, controller2.CurrentUser.BirthDate);
            Assert.AreEqual(weigth, controller2.CurrentUser.Weigth);
            Assert.AreEqual(heigth, controller2.CurrentUser.Heigth);
          

        }

        [TestMethod()]
        public void SaveTest()
        {
            // Arrange - данные которые подаютса на вход
            
            var userName = Guid.NewGuid().ToString();


            // Act - действие когда мы ызываем что-то

            var controller = new UserController(userName);

            // Assert - когда мы проверяем то что получилось и то что ожидалось

            Assert.AreEqual(userName, controller.CurrentUser.Name);



        }
    }
}