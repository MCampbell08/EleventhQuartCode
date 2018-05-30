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
        [HttpGet]
        public Video Get(int id)
        {
            return _repo.GetVideoById(id);
        }

        // GET api/video/user/{userId}
        [HttpGet]
        public IEnumerable<Video> GetByUserId(int userId)
        {
            return _repo.GetAllByUserId(userId);
        }

        // POST api/video
        [HttpPost]
        public void Post([FromBody] Video video)
        {
            _repo.AddVideo(video);
        }

        //PUT api/video/{id}
        [HttpPut]
        public void Put(int id, [FromBody] Video video)
        {
            _repo.UpdateVideo(id, video);
        }

        //DELETE api/video/{id}
        [HttpDelete]
        public void Delete(int id)
        {
            _repo.DeleteVideo(id);
        }
    }
}