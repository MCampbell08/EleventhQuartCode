using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StreamerSite.API.Repositories;
using StreamerSite.API.Models;
using MongoDB.Bson;
using Microsoft.AspNetCore.Authorization;

namespace StreamerSite.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    public class VideoController : Controller
    {
        private VideoRepository _repo;
        
        public VideoController(VideoRepository repo)
        {
            _repo = repo;
        }

        // GET api/video
        [HttpGet]
        public IEnumerable<MongoVideoModel> Get()
        {
            return _repo.GetAllVideos();
        }

        // GET api/video/{id}
        [HttpGet]
        public MongoVideoModel Get(string id)
        {
            return _repo.GetVideoById(id);
        }

        // GET api/video/user/{userId}
        [HttpGet("user/{id}")]
        public IEnumerable<MongoVideoModel> GetByUserId(int id)
        {
            return _repo.GetAllByUserId(id);
        }

        // POST api/video
        [HttpPost]
        public void Post([FromBody] Video video)
        {
            _repo.AddVideo(video);
        }

        public string AddMongoDBVideo(IFormFile file)
        {
            return _repo.AddMongoDBVideo(file);
        }

        //DELETE api/video/{id}
        [HttpDelete]
        public void Delete(string id)
        {
            _repo.DeleteVideo(id);
        }
    }
}