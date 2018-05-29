using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StreamerSite.API.Repositories;
using StreamerSite.API.Models;

namespace StreamerSite.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class VideoController : Controller
    {
        private VideoRepository _repo;

        public VideoController()
        {
            _repo = new VideoRepository(new Data.StreamersContext());
        }
        public VideoController(VideoRepository repo)
        {
            _repo = repo;
        }

        // GET api/video
        [HttpGet]
        public IEnumerable<Video> Get()
        {
            return _repo.GetAllVideos();
        }

        // GET api/video/{id}
        public Video Get(int id)
        {
            Video video = Get().Single(x => x.Id == id) as Video;

            return video ?? null;
        }

        // GET api/video/user/{userId}
        public IEnumerable<Video> GetByUserId(int userId)
        {
            List<Video> tempVideos = Get().Where(x => x.User.Id == userId) as List<Video>;

            return tempVideos;
        }

        // POST api/video
        public void Post([FromBody] Video video)
        {
            _repo.AddVideo(video);
        }

        //PUT api/video/{id}
        public void Put(int id, [FromBody] Video video)
        {
            _repo.UpdateVideo(id, video);
        }

        //DELETE api/video/{id}
        public void Delete(int id)
        {
            _repo.DeleteVideo(id);
        }
    }
}