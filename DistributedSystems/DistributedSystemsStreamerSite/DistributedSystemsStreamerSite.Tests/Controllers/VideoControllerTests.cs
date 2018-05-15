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
    public class VideoControllerTests
    {
        private VideoController videoController = new VideoController(TestData());

        [TestMethod()]
        public void GetTest()
        {
            List<Video> test = TestData();
            List<Video> test2 = videoController.Get() as List<Video>;

            Assert.IsNotNull(test2);
            for (int i = 0; i < test.Count && i < test2.Count; ++i)
            {
                Assert.AreEqual(test[i].Id, test2[i].Id);
                Assert.AreEqual(test[i].Path, test2[i].Path);
                Assert.AreEqual(test[i].UserId, test2[i].UserId);
            }
        }

        [TestMethod()]
        public void GetByVideoIdTest()
        {
            Video video = TestData()[0];
            Video pulledVideo = videoController.Get(0);

            Assert.IsNotNull(pulledVideo);
            Assert.AreEqual(video.Id, pulledVideo.Id);
            Assert.AreEqual(video.UserId, pulledVideo.UserId);
            Assert.AreEqual(video.Path, pulledVideo.Path);
        }

        [TestMethod()]
        public void GetByUserIdTest()
        {
            List<Video> videos = TestData().FindAll(x => x.UserId == 0) as List<Video>;
            List<Video> pulledVideos = videoController.GetByUserId(0) as List<Video>;

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
            List<Video> videos = TestData();
            videos.Add(new Video() { Id = 3, Path = "fourthVideoPath", UserId = 2 });
            videoController.Post(new Video() { Id = 3, Path = "fourthVideoPath", UserId = 2 });

            Video video = videoController.Get(3);

            Assert.IsNotNull(video);
            Assert.AreEqual(video.Id, videos.Last().Id);
            Assert.AreEqual(video.UserId, videos.Last().UserId);
            Assert.AreEqual(video.Path, videos.Last().Path);
        }

        [TestMethod()]
        public void PutTest()
        {
            Video oldTestCase = videoController.Get().Last();
            oldTestCase = new Video() { Id = oldTestCase.Id, UserId = oldTestCase.UserId, Path = oldTestCase.Path };
            Video newTestCase = new Video() { Id = 3, UserId = 5, Path = "changePath" };

            videoController.Put(oldTestCase.Id, newTestCase);

            Assert.IsNotNull(oldTestCase);
            Assert.IsNotNull(newTestCase);
            Assert.AreNotEqual(oldTestCase.Path, videoController.Get().Last().Path);
            Assert.AreNotEqual(oldTestCase.UserId, videoController.Get().Last().UserId);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Video deletedVideo = videoController.Get().Last();

            videoController.Delete(deletedVideo.Id);

            Assert.AreNotEqual(deletedVideo.Id, videoController.Get().Last().Id);
            Assert.AreNotEqual(deletedVideo.Path, videoController.Get().Last().Path);
            Assert.AreNotEqual(deletedVideo.UserId, videoController.Get().Last().UserId);
        }
        public static List<Video> TestData()
        {
            List<Video> videos = new List<Video>
            {
                new Video() { Id = 0, Path = "firstVideoPath", UserId = 0 },
                new Video() { Id = 1, Path = "secondVideoPath", UserId = 0 },
                new Video() { Id = 2, Path = "thirdVideoPath", UserId = 1 }
            };

            return videos;
        }
    }
}