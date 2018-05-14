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
            for(int i = 0; i < test.Count && i < test2.Count; ++i)
            {
                Assert.AreEqual(test[i].Id, test2[i].Id);
                Assert.AreEqual(test[i].Name, test2[i].Name);
                Assert.AreEqual(test[i].FollowerCount, test2[i].FollowerCount);
                Assert.AreEqual(test[i].SubscriberCount, test2[i].SubscriberCount);
                Assert.AreEqual(test[i].PageViewCount, test2[i].PageViewCount);
            }
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            User user = TestData()[0];
            User pulledUser = userController.Get(0);

            Assert.IsNotNull(pulledUser);
            Assert.AreEqual(user.Id, pulledUser.Id);
            Assert.AreEqual(user.Name, pulledUser.Name);
            Assert.AreEqual(user.FollowerCount, pulledUser.FollowerCount);
            Assert.AreEqual(user.SubscriberCount, pulledUser.SubscriberCount);
            Assert.AreEqual(user.PageViewCount, pulledUser.PageViewCount);
        }

        [TestMethod()]
        public void GetVideosTest()
        {
            List<Video> videos = TestData()[0].Videos;
            List<Video> pulledVideos = userController.GetVideos(0) as List<Video>;

            Assert.IsNotNull(pulledVideos);

            for (int i = 0; i < videos.Count && i < pulledVideos.Count; ++i)
            {
                Assert.AreEqual(videos[i].Id, pulledVideos[i].Id);
                Assert.AreEqual(videos[i].Path, pulledVideos[i].Path);
                Assert.AreEqual(videos[i].UserId, pulledVideos[i].UserId);
            }
        }

        [TestMethod()]
        public void PostTest()
        {
            List<User> users = TestData();
            users.Add(new User() { Id = 3, FollowerCount = 40, PageViewCount = 200, SubscriberCount = 0, Name = "Toby" });
            userController.Post(new User() { Id = 3, FollowerCount = 40, PageViewCount = 200, SubscriberCount = 0, Name = "Toby" });

            User user = userController.Get(3);

            Assert.IsNotNull(user);
            Assert.AreEqual(user.Id, users.Last().Id);
            Assert.AreEqual(user.Name, users.Last().Name);
            Assert.AreEqual(user.FollowerCount, users.Last().FollowerCount);
            Assert.AreEqual(user.PageViewCount, users.Last().PageViewCount);
            Assert.AreEqual(user.SubscriberCount, users.Last().SubscriberCount);
        }

        [TestMethod()]
        public void PutTest()
        {
            User oldTestCase = userController.Get().Last(); //new User() { Id = 3, FollowerCount = 40, PageViewCount = 200, SubscriberCount = 0, Name = "Toby" }
            oldTestCase = new User() { Id = oldTestCase.Id, FollowerCount = oldTestCase.FollowerCount, PageViewCount = oldTestCase.PageViewCount, SubscriberCount = oldTestCase.SubscriberCount, Name = oldTestCase.Name, Videos = oldTestCase.Videos};
            User newTestCase = new User() { Id = 3, FollowerCount = 100, PageViewCount = 5000, SubscriberCount = 6, Name = "Tobias" };

            userController.Put(oldTestCase.Id, newTestCase);

            Assert.IsNotNull(oldTestCase);
            Assert.IsNotNull(newTestCase);
            Assert.AreNotEqual(oldTestCase.FollowerCount, userController.Get().Last().FollowerCount);
            Assert.AreNotEqual(oldTestCase.PageViewCount, userController.Get().Last().PageViewCount);
            Assert.AreNotEqual(oldTestCase.SubscriberCount, userController.Get().Last().SubscriberCount);
            Assert.AreNotEqual(oldTestCase.Name, userController.Get().Last().Name);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            User deletedUser = userController.Get().Last();

            userController.Delete(deletedUser.Id);

            Assert.AreNotEqual(deletedUser.Id, userController.Get().Last().Id);
            Assert.AreNotEqual(deletedUser.Name, userController.Get().Last().Name);
            Assert.AreNotEqual(deletedUser.FollowerCount, userController.Get().Last().FollowerCount);
            Assert.AreNotEqual(deletedUser.SubscriberCount, userController.Get().Last().SubscriberCount);
            Assert.AreNotEqual(deletedUser.PageViewCount, userController.Get().Last().PageViewCount);
        }

        public static List<User> TestData()
        {
            List<User> users = new List<User>
            {
                new User() { Id = 0, FollowerCount = 10, PageViewCount = 100, SubscriberCount = 0, Name = "Bob", Videos = new List<Video>() { new Video() { Id = 0, Path = "basicStringPath.mp4", UserId = 0 } } },
                new User() { Id = 1, FollowerCount = 20, PageViewCount = 150, SubscriberCount = 5, Name = "Joe", Videos = new List<Video>() { new Video() { Id = 1, Path = "newStringPath.mp4", UserId = 1 }, new Video() { Id = 2, Path = "anotherStringPath.mp4", UserId = 1 } } },
                new User() { Id = 2, FollowerCount = 50, PageViewCount = 1000, SubscriberCount = 0, Name = "Amber", Videos = new List<Video>() { new Video() { Id = 3, Path = "thirdStringPath.mp4", UserId = 2 } } }
            };

            return users;
        }
    }
}