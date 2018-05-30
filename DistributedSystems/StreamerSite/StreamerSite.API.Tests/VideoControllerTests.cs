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
    }
}
