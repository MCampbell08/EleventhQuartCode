using Microsoft.VisualStudio.TestTools.UnitTesting;
using StreamerSite.API.Controllers;
using StreamerSite.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreamerSite.API.Tests
{
    [TestClass]
    public class VideoControllerTests
    {
        public static VideoController videoController = new VideoController(new Repositories.VideoRepository(new Data.StreamersContext()));

        [TestMethod()]
        public void GetAllVideosTest()
        {
            Video video = null;

            if (videoController.Get() == null || videoController.Get().Count() == 0)
            {
                video = new Video() { Path = "somePath", UserId = 67 };
                videoController.Post(video);
            }

            Assert.IsNotNull(videoController.Get());

            if (video != null)
                videoController.Delete(video.Id);
        }

        [TestMethod()]
        public void GetVideoByIdTest()
        {
            Video video = null;

            if (videoController.Get() == null || videoController.Get().Count() == 0)
            {
                video = new Video() { Path = "somePath", UserId = 67};
                videoController.Post(video);
            }
            Video pulledVideo = videoController.Get(videoController.Get().First().Id);

            Assert.IsNotNull(pulledVideo);

            if (video != null)
                videoController.Delete(video.Id);
        }

        [TestMethod()]
        public void GetAllVideosByUserIdTest()
        {
            Video video1 = null, video2 = null, video3 = null;

            if (videoController.Get() == null || videoController.Get().Count() == 0)
            {
                video1 = new Video() { Path = "testPath1", UserId = 62 };
                video2 = new Video() { Path = "testPath2", UserId = 62 };
                video3 = new Video() { Path = "testPath3", UserId = 65 };

                videoController.Post(video1);
                videoController.Post(video2);
                videoController.Post(video3);
            }

            var list = videoController.GetByUserId(62);

            Assert.IsNotNull(list);
            Assert.IsNotNull(list.ElementAt(0));
            Assert.IsNotNull(list.ElementAt(1));

            if (video1 != null && video2 != null && video3 != null)
            {
                videoController.Delete(video1.Id);
                videoController.Delete(video2.Id);
                videoController.Delete(video3.Id);
            }
        }

        [TestMethod()]
        public void PostVideoTest()
        {
            Video video = new Video() { Path = "testPath", UserId = 8};

            videoController.Post(video);

            Assert.IsNotNull(videoController.Get().Last().Id);

            videoController.Delete(video.Id);
        }

        [TestMethod()]
        public void PutVideoTest()
        {
            Video video = null;
            if (videoController.Get().Count() == 0 || videoController.Get() == null)
            {
                video = new Video() { Path = "testPath", UserId = 200 };
                videoController.Post(video);
            }
            Video oldTestCase = videoController.Get(videoController.Get().Last().Id);
            oldTestCase = new Video() { Id = oldTestCase.Id, Path = oldTestCase.Path, UserId = oldTestCase.UserId };
            Video newTestCase = new Video() { Path = "updatedTestPath", UserId = 201 };

            videoController.Put(oldTestCase.Id, newTestCase);

            Assert.IsNotNull(oldTestCase);
            Assert.IsNotNull(newTestCase);
            Assert.AreEqual(oldTestCase.Id, videoController.Get(videoController.Get().Last().Id).Id);
            Assert.AreNotEqual(oldTestCase.Path, videoController.Get(videoController.Get().Last().Id).Path);
            Assert.AreNotEqual(oldTestCase.UserId, videoController.Get(videoController.Get().Last().Id).UserId);

            if (video != null)
            {
                videoController.Delete(video.Id);
            }
        }
        [TestMethod()]
        public void DeleteVideoTest()
        {
            Video video = new Video() { Path = "testPath", UserId = 8 };

            videoController.Post(video);

            Assert.IsNotNull(videoController.Get(video.Id));

            videoController.Delete(video.Id);

            Assert.IsNull(videoController.Get(video.Id));
        }
    }
}
