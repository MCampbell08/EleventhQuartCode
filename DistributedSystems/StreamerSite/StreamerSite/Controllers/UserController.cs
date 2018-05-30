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
        [HttpPut]
        public void Put(int id, [FromBody]UserDetail streamer)
        {
            _repo.UpdateUser(id, streamer);
        }

        // PUT api/user/UpdatePassword/{id}
        [HttpPut("UpdatePassword/{id}")]
        public void UpdatePassword(int id, [FromBody] UserPasswordModify user)
        {
            _repo.UpdatePassword(user);
        }

        // DELETE api/user/{id}
        [HttpDelete]
        public void Delete(int id)
        {
            _repo.DeleteUser(id);
        }
    }
}
