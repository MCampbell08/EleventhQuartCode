using Microsoft.VisualStudio.TestTools.UnitTesting;
using DistributedSystemsStreamerSite.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DistributedSystemsStreamerSite.Models;

namespace DistributedSystemsStreamerSite.Controllers.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        private UserController userController = new UserController(TestData());

        [TestMethod()]
        public void GetAllTest()
        {
            List <User> test = TestData();
            List <User> test2 = userController.Get() as List<User>;

            Assert.IsNotNull(test2);
            Assert.AreEqual(test, test2);
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            User user = TestData()[0];
            User pulledUser = userController.Get(0);

            Assert.IsNotNull(pulledUser);
            Assert.AreEqual(user, pulledUser);
        }

        [TestMethod()]
        public void GetVideosTest()
        {
            List<Video> videos = TestData()[0].Videos;
            List<Video> pulledVideos = userController.GetVideos(0) as List<Video>;

            Assert.IsNotNull(pulledVideos);
            Assert.AreEqual(videos, pulledVideos);
        }

        [TestMethod()]
        public void PostTest()
        {
            List<User> users = TestData();
            users.Add(new User() { Id = 3, FollowerCount = 40, PageViewCount = 200, SubscriberCount = 0, Name = "Toby" });
        }

        [TestMethod()]
        public void PutTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        public static List<User> TestData()
        {
            List<User> users = new List<User>();
            users.Add(new User() { Id = 0, FollowerCount = 10, PageViewCount = 100, SubscriberCount = 0, Name = "Bob", Videos = new List<Video>() { new Video() { Id = 0, Path = "basicStringPath.mp4", UserId = 0 } } });
            users.Add(new User() { Id = 1, FollowerCount = 20, PageViewCount = 150, SubscriberCount = 5, Name = "Joe", Videos = new List<Video>() { new Video() { Id = 1, Path = "newStringPath.mp4", UserId = 1 }, new Video() { Id = 2, Path = "anotherStringPath.mp4", UserId = 1 } } });
            users.Add(new User() { Id = 2, FollowerCount = 50, PageViewCount = 1000, SubscriberCount = 0, Name = "Amber", Videos = new List<Video>() { new Video() { Id = 3, Path = "thirdStringPath.mp4", UserId = 2 } } });

            return users;
        }
    }
}