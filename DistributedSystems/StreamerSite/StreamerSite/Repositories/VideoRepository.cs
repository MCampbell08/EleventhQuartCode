using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using StreamerSite.API.Data;
using StreamerSite.API.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StreamerSite.API.Repositories
{
    public class VideoRepository
    {
        StreamersContext context;
        MongoGridFsUtilizer mongoGridFsUtilizer;

        public VideoRepository(StreamersContext ctx)
        {
            context = ctx;
            mongoGridFsUtilizer = new MongoGridFsUtilizer();
        }
        public ICollection<MongoVideoModel> GetAllVideos()
        {
            //return context.Videos.ToArray() ?? null;
            var videoCollection = mongoGridFsUtilizer.GetVideoCollection();
            var videoCursor = videoCollection.FindAll();

            videoCursor.SetFields(Fields.Include("_id", "FileName", "UserId", "VideoId"));

            return videoCursor.ToList() ?? null;
        }
        public MongoVideoModel GetVideoById(string id)
        {
            var videoCollection = mongoGridFsUtilizer.GetVideoCollection();
            var video = videoCollection.FindOneById(ObjectId.Parse(id));

            return video;
            //return context.Videos.FirstOrDefault() ?? null;
        }
        public ICollection<MongoVideoModel> GetAllByUserId(int id)
        {
            var userIds = GetMongoIdsByUserId(id);
            var collection = mongoGridFsUtilizer.GetVideoCollection();
            List<MongoVideoModel> mongoVideos = new List<MongoVideoModel>();

            foreach(string s in userIds)
            {
                mongoVideos.Add(collection.FindOneById(ObjectId.Parse(s)));
            }

            return mongoVideos ?? null;
        }
        public ICollection<string> GetMongoIdsByUserId(int id)
        {
            var list = new List<string>();
            var videosList = context.Videos.ToList().FindAll(v => v.UserDetailId == id);

            foreach (Video v in videosList)
            {
                list.Add(v.MongoId);
            }

            return list.ToList() ?? null;
        }
        public long AddVideo(Video video)
        {
            int videoId = 0;
            if (video == null)
            {
                throw new NullReferenceException("Video added is null.");
            }
            if (!context.Users.Any(x => x.Id == video.UserDetailId))
            {
                throw new Exception("There is no user existing in this table that matches that id.");
            }

            context.Add(video);
            videoId = context.SaveChanges();
            return videoId;
        }

        public string AddMongoDBVideo(IFormFile file)
        {
            MongoVideoModel mongoVideo = new MongoVideoModel() { FileName = file.FileName };
            
            byte[] theVideoAsBytes = new byte[file.Length];
            using (BinaryReader reader = new BinaryReader(file.OpenReadStream()))
            {
                theVideoAsBytes = reader.ReadBytes((int)file.Length);
            };
            mongoVideo.VideoDataAsString = Convert.ToBase64String(theVideoAsBytes);
            mongoGridFsUtilizer.GetVideoCollection().Insert(mongoVideo);

            return mongoVideo._id.ToString();
        }
        public string DeleteVideo(string id)
        {
            var videoCollection = mongoGridFsUtilizer.GetVideoCollection();
            MongoVideoModel mongoVideo = videoCollection.FindOneById(ObjectId.Parse(id));
            Video video = context.Videos.ToList().FirstOrDefault(v => v.MongoId == id);

            if (mongoVideo != null && video != null)
            {
                videoCollection.Remove(Query.EQ("_id", ObjectId.Parse(id)));
                context.Remove(video);
                context.SaveChanges();
            }
            return id;
        }
    }
}
