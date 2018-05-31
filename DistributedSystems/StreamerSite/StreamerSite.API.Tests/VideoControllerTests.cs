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

            if (videoController.Get() == null)
            {
                video = new Video() { Path = "somePath", UserId = 67 };
                videoController.Post(video);
            }
            List<Video> list = videoController.Get() as List<Video>;

            Assert.IsNotNull(list);

            if (video != null)
                videoController.Delete(video.Id);
        }

        [TestMethod()]
        public void GetVideoByIdTest()
        {
            Video video = null;

            if (videoController.Get().Count() <= 0)
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

            if (videoController.Get() == null)
            {
                video1 = new Video() { Path = "testPath1", UserId = 62 };
                video2 = new Video() { Path = "testPath2", UserId = 62 };
                video3 = new Video() { Path = "testPath3", UserId = 65 };

                videoController.Post(video1);
                videoController.Post(video2);
                videoController.Post(video3);
            }

            List<Video> list = videoController.GetByUserId(62) as List<Video>;

            Assert.IsNotNull(list);
            Assert.IsNotNull(list[0]);
            Assert.IsNotNull(list[1]);

            if (video1 != null && video2 != null && video3 != null)
            {
                videoController.Delete(video1.Id);
                videoController.Delete(video2.Id);
                videoController.Delete(video3.Id);
            }
        }
    }
}
