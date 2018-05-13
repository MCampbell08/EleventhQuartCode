using DistributedSystemsStreamerSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DistributedSystemsStreamerSite.Controllers
{
    public class VideoController : ApiController
    {
        static List<Video> videos = new List<Video>();

        public VideoController(List<Video> newVideos)
        {
            videos = newVideos;
        }

        // GET api/video
        public IEnumerable<Video> Get()
        {
            return videos;
        }

        // GET api/video/{id}
        public Video Get(int id)
        {
            Video video = videos.Where(x => x.Id == id) as Video;

            return video ?? null;
        }

        // GET api/video/user/{userId}
        public IEnumerable<Video> GetByUserId(int userId)
        {
            List<Video> tempVideos = videos.Where(x => x.UserId == userId) as List<Video>;

            return tempVideos;
        }

        // POST api/video
        public void Post([FromBody] Video video)
        {
            videos.Add(video);
        }

        //PUT api/video/{id}
        public void Put(int id, [FromBody] Video video)
        {
            Video temp = Get(id);

            if (temp == null)
            {
                throw new ArgumentException("No exisitng video.");
            }

            UpdateVideo(temp, video);
        }

        //DELETE api/video/{id}
        public void Delete(int id)
        {
            videos.Remove(Get(id));
        }

        private static void UpdateVideo(Video temp, Video video)
        {
            temp.Path = video.Path;
            temp.UserId = video.UserId;
        }
    }
}