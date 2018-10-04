using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StreamerSite.API.Controllers;
using StreamerSite.API.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace StreamerSite.API.Tests
{
    [TestClass]
    public class VideoControllerTests
    {
        public static VideoController videoController = new VideoController(new Repositories.VideoRepository(new Data.StreamersContext()));
        public static UserController userController = new UserController(new Repositories.UserRepository(new Data.StreamersContext()));

        [TestMethod()]
        public void GetAllVideosByUserId()
        {
            Video video1 = null, video2 = null, video3 = null;
            UserDetail user = null, user2 = null;

            user = new UserDetail() { FollowerCount = 40, PageViewCount = 200, SubscriberCount = 0, Username = "Toby", Email = "toby@gmail.com" };
            user2 = new UserDetail() { FollowerCount = 40, PageViewCount = 200, SubscriberCount = 0, Username = "Bob", Email = "bob@gmail.com" };
            userController.Post(user);
            userController.Post(user2);

            FormFile file = null, file2 = null, file3 = null;
            string id = "", id2 = "", id3 = "";
            
            using (BinaryReader reader = new BinaryReader(File.OpenRead(@"C:\EleventhQuartCode\DistributedSystems\StreamerSite\StreamerSite.API.Tests\TestData\test.mp4")))
            {
                file = new FormFile(reader.BaseStream, reader.BaseStream.Position, reader.BaseStream.Length, "test.mp4", "test.mp4");
                file2 = new FormFile(reader.BaseStream, reader.BaseStream.Position, reader.BaseStream.Length, "test2.mp4", "test2.mp4");
                file3 = new FormFile(reader.BaseStream, reader.BaseStream.Position, reader.BaseStream.Length, "test3.mp4", "test3.mp4");
                id = videoController.AddMongoDBVideo(file);
                id2 = videoController.AddMongoDBVideo(file2);
                id3 = videoController.AddMongoDBVideo(file3);
            };

            video1 = new Video() { Name = "testPath1", UserDetailId = user.Id, MongoId = id };
            video2 = new Video() { Name = "testPath2", UserDetailId = user.Id, MongoId = id2 };
            video3 = new Video() { Name = "testPath3", UserDetailId = user2.Id, MongoId = id3 };

            videoController.Post(video1);
            videoController.Post(video2);
            videoController.Post(video3);
            
            var videosList = videoController.GetByUserId(user.Id);

            Assert.IsNotNull(videosList);
            Assert.IsNotNull(videosList.First());
            Assert.IsNotNull(videosList.Last());

            videoController.Delete(id);
            videoController.Delete(id2);
            videoController.Delete(id3);

            userController.Delete(user.Id);
            userController.Delete(user2.Id);
        }

        [TestMethod()]
        public void PostMongoDBVideoTest()
        {

            UserDetail user = new UserDetail() { FollowerCount = 40, PageViewCount = 200, SubscriberCount = 0, Username = "Toby", Email = "toby@gmail.com" };
            FormFile file = null;
            string id = "";

            userController.Post(user);

            using (BinaryReader reader = new BinaryReader(File.OpenRead(@"C:\EleventhQuartCode\DistributedSystems\StreamerSite\StreamerSite.API.Tests\TestData\test.mp4")))
            {
                file = new FormFile(reader.BaseStream, reader.BaseStream.Position, reader.BaseStream.Length, "test.mp4", "test.mp4");
                id = videoController.AddMongoDBVideo(file);
            };

            Video video = new Video() { Name = "testPath", UserDetailId = user.Id, MongoId = id };

            videoController.Post(video);

            Assert.AreNotEqual(id, "");
            Assert.IsNotNull(videoController.Get().Last());
            
            videoController.Delete(id);
            userController.Delete(user.Id);
        }

        [TestMethod()]
        public void DeleteVideoTest()
        {
            UserDetail user = new UserDetail() { FollowerCount = 40, PageViewCount = 200, SubscriberCount = 0, Username = "Toby", Email = "toby@gmail.com" };
            userController.Post(user);

            FormFile file = null;
            string id = "";
            using (BinaryReader reader = new BinaryReader(File.OpenRead(@"C:\EleventhQuartCode\DistributedSystems\StreamerSite\StreamerSite.API.Tests\TestData\test.mp4")))
            {
                file = new FormFile(reader.BaseStream, reader.BaseStream.Position, reader.BaseStream.Length, "test.mp4", "test.mp4");
                id = videoController.AddMongoDBVideo(file);
            };

            Video video = new Video() { Name = "testPath", UserDetailId = user.Id, MongoId = id };

            videoController.Post(video);

            Assert.IsNotNull(videoController.Get(id));

            videoController.Delete(id);

            Assert.IsNull(videoController.Get(id));
            userController.Delete(user.Id);
        }
    }
}
