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
    public class UserController : Controller
    {
        private UserRepository _repo;
        public UserController()
        {
            _repo = new UserRepository(new Data.StreamersContext());
        }
        public UserController(UserRepository repo)
        {
            _repo = repo;
        }

        // GET api/user
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _repo.GetAllUsers();
        }

        // GET api/user/{id}
        [HttpGet]
        public UserDetail Get(int id)
        {
            return _repo.GetUserById(id);
        }

        // POST api/user
        [HttpPost]
        public void Post([FromBody]UserDetail streamer)
        {
            _repo.AddUser(streamer);
        }

        // PUT api/user/{id}
        public void Put(int id, [FromBody]UserDetail streamer)
        {
            _repo.UpdateUser(id, streamer);
        }

        // DELETE api/user/{id}
        public void Delete(int id)
        {
            _repo.DeleteUser(id);
        }
    }
}
