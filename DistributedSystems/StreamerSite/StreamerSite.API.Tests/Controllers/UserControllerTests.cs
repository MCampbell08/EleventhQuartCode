using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StreamerSite.API.Controllers;
using System.Collections.Generic;
using StreamerSite.API.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using NSubstitute;
using Microsoft.AspNetCore.Mvc;

namespace StreamerSite.API.Tests.Controllers
{
    [TestClass]
    public class UserControllerTest
    {
        private static UserController userController = new UserController(new Repositories.UserRepository(new Data.StreamersContext()));
        
        [TestMethod()]
        public void GetAllUsersTest()
        {
            List<User> test2 = userController.Get() as List<User>;

            Assert.IsNotNull(test2);
        }

        [TestMethod()]
        public void GetUserByIdTest()
        {
            UserDetail user = null;
            if (userController.Get().Count() <= 0)
            {
                user = new UserDetail() { FollowerCount = 40, PageViewCount = 200, SubscriberCount = 0, Username = "Toby", Email = "toby@gmail.com" };
                userController.Post(user);
            }
            UserDetail pulledUser = userController.Get(userController.Get().First().Id);

            Assert.IsNotNull(pulledUser);

            if (user != null)
            {
                userController.Delete(user.Id);
            }
        }

        [TestMethod()]
        public void PostUserTest()
        {
            UserDetail user = user = new UserDetail() { FollowerCount = 40, PageViewCount = 200, SubscriberCount = 0, Username = "Toby", Email = "toby@gmail.com" };

            userController.Post(user);
           
            Assert.IsNotNull(userController.Get(userController.Get().Last().Id));

            userController.Delete(user.Id);
        }

        [TestMethod()]
        public void PutUserTest()
        {
            UserDetail user = null;
            if (userController.Get().Count() <= 0)
            {
                user = new UserDetail() { FollowerCount = 40, PageViewCount = 200, SubscriberCount = 0, Username = "Toby", Email = "toby@gmail.com" };
                userController.Post(user);
            }
            UserDetail oldTestCase = userController.Get(userController.Get().Last().Id); //new User() { Id = 3, FollowerCount = 40, PageViewCount = 200, SubscriberCount = 0, Name = "Toby" }
            oldTestCase = new UserDetail() { Id = oldTestCase.Id, FollowerCount = oldTestCase.FollowerCount, PageViewCount = oldTestCase.PageViewCount, SubscriberCount = oldTestCase.SubscriberCount, Username = oldTestCase.Username};
            UserDetail newTestCase = new UserDetail() { FollowerCount = 100, PageViewCount = 5000, SubscriberCount = 6, Username = "Tobias", Email = "tobias@gmail.com" };

            userController.Put(oldTestCase.Id, newTestCase);

            Assert.IsNotNull(oldTestCase);
            Assert.IsNotNull(newTestCase);
            Assert.AreNotEqual(oldTestCase.Username, userController.Get(userController.Get().Last().Id).Username);
            Assert.AreNotEqual(oldTestCase.Email, userController.Get(userController.Get().Last().Id).Email);

            if(user != null)
            {
                userController.Delete(user.Id);
            }
        }

        [TestMethod]
        public void UpdatePasswordTest()
        {
            UserDetail user = user = new UserDetail() { FollowerCount = 40, PageViewCount = 200, SubscriberCount = 0, Username = "Toby", Email = "toby@gmail.com" };
            string password = user.Password;
            userController.Post(user);
            userController.UpdatePassword(user.Id, new UserPasswordModify() { UserId = user.Id, Password = "newPasswordNoHash" });

            Assert.AreNotEqual(password, user.Password);

            userController.Delete(user.Id);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            UserDetail user = user = new UserDetail() { FollowerCount = 40, PageViewCount = 200, SubscriberCount = 0, Username = "Toby", Email = "toby@gmail.com" };
            
            userController.Post(user);

            Assert.IsNotNull(userController.Get(user.Id));

            userController.Delete(user.Id);

            Assert.IsNull(userController.Get(user.Id));
        }
    }
}
