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
        private static UserController userController = new UserController();
        private static List<UserDetail> userDetails = new List<UserDetail>()
        {
            new UserDetail() { FollowerCount = 10, PageViewCount = 100, SubscriberCount = 0, Username = "Bob", Password = "bobPass" },
            new UserDetail() { FollowerCount = 20, PageViewCount = 150, SubscriberCount = 5, Username = "Joe", Password = "joePass" },
            new UserDetail() { FollowerCount = 50, PageViewCount = 1000, SubscriberCount = 0, Username = "Amber", Password = "amberPass" },
        };
        private List<User> users = new List<User>() {
                new User(){ Username = "Bob"  },
                new User(){ Username = "Joe"  },
                new User(){ Username = "Amber" },
        };
        private List<User> userToBeDeleted = new List<User>();

        [TestInitialize]
        public void InitializeUserController()
        {
            userController.Post(new UserDetail() { FollowerCount = 10, PageViewCount = 100, SubscriberCount = 0, Username = "Bob",    Password = "bobPass"  });
            userController.Post(new UserDetail() { FollowerCount = 20, PageViewCount = 150, SubscriberCount = 5, Username = "Joe",    Password = "joePass"  });
            userController.Post(new UserDetail() { FollowerCount = 50, PageViewCount = 1000, SubscriberCount = 0, Username = "Amber", Password = "amberPass"});
        }

        [TestMethod()]
        public void GetAllTest()
        {
            List<User> test2 = userController.Get() as List<User>;

            Assert.IsNotNull(test2);
            for (int i = 0; i < users.Count && i < test2.Count; ++i)
            {
                Assert.AreEqual(users[i].Username, test2[i].Username);
            }
            RemoveTestData();
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            UserDetail user = userDetails.First();
            UserDetail pulledUser = userController.Get(userController.Get().First().Id);

            Assert.IsNotNull(pulledUser);
            Assert.AreEqual(user.Username, pulledUser.Username);
            Assert.AreEqual(user.FollowerCount, pulledUser.FollowerCount);
            Assert.AreEqual(user.SubscriberCount, pulledUser.SubscriberCount);
            Assert.AreEqual(user.PageViewCount, pulledUser.PageViewCount);

            RemoveTestData();
        }

        [TestMethod()]
        public void PostTest()
        {
            UserDetail lastUser = userController.Get(userController.Get().Last().Id);
            userController.Post(new UserDetail() {FollowerCount = 40, PageViewCount = 200, SubscriberCount = 0, Username = "Toby" });
            UserDetail newLastUser = userController.Get(userController.Get().Last().Id);

            Assert.IsNotNull(lastUser);
            Assert.IsNotNull(newLastUser);
            Assert.AreNotEqual(newLastUser.Username, lastUser.Username);
            Assert.AreNotEqual(newLastUser.FollowerCount, lastUser.FollowerCount);
            Assert.AreNotEqual(newLastUser.PageViewCount, lastUser.PageViewCount);
            Assert.AreNotEqual(newLastUser.SubscriberCount, lastUser.SubscriberCount);

            RemoveTestData();
        }

        [TestMethod()]
        public void PutTest()
        {
            UserDetail oldTestCase = userController.Get(userController.Get().Last().Id); //new User() { Id = 3, FollowerCount = 40, PageViewCount = 200, SubscriberCount = 0, Name = "Toby" }
            oldTestCase = new UserDetail() { Id = oldTestCase.Id, FollowerCount = oldTestCase.FollowerCount, PageViewCount = oldTestCase.PageViewCount, SubscriberCount = oldTestCase.SubscriberCount, Username = oldTestCase.Username};
            UserDetail newTestCase = new UserDetail() { FollowerCount = 100, PageViewCount = 5000, SubscriberCount = 6, Username = "Tobias" };

            userController.Put(oldTestCase.Id, newTestCase);

            Assert.IsNotNull(oldTestCase);
            Assert.IsNotNull(newTestCase);
            Assert.AreNotEqual(oldTestCase.FollowerCount, userController.Get(userController.Get().Last().Id).FollowerCount);
            Assert.AreNotEqual(oldTestCase.PageViewCount, userController.Get(userController.Get().Last().Id).PageViewCount);
            Assert.AreNotEqual(oldTestCase.SubscriberCount, userController.Get(userController.Get().Last().Id).SubscriberCount);
            Assert.AreNotEqual(oldTestCase.Username, userController.Get(userController.Get().Last().Id).Username);

            RemoveTestData();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            UserDetail deletedUser = userController.Get(userController.Get().Last().Id);

            userController.Delete(deletedUser.Id);

            Assert.AreNotEqual(deletedUser.Id, userController.Get(userController.Get().Last().Id).Id);
            Assert.AreNotEqual(deletedUser.Username, userController.Get(userController.Get().Last().Id).Username);
            Assert.AreNotEqual(deletedUser.FollowerCount, userController.Get(userController.Get().Last().Id).FollowerCount);
            Assert.AreNotEqual(deletedUser.SubscriberCount, userController.Get(userController.Get().Last().Id).SubscriberCount);
            Assert.AreNotEqual(deletedUser.PageViewCount, userController.Get(userController.Get().Last().Id).PageViewCount);

            RemoveTestData();
        }

        private void RemoveTestData()
        {
            foreach(User user in userController.Get())
            {
                userController.Delete(user.Id);
            }
        }
    }
}
