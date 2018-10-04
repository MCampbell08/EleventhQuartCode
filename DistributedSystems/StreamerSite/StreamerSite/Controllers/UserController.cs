using System;
using System.Web.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StreamerSite.API.Repositories;
using StreamerSite.API.Models;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;

namespace StreamerSite.API.Controllers
{
    [Produces("application/json")]
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    public class UserController : Controller
    {
        private UserRepository _repo;

        public UserController(UserRepository repo)
        {
            _repo = repo;
        }
        
        [Microsoft.AspNetCore.Mvc.HttpPost("Register")]
        public void Register([Microsoft.AspNetCore.Mvc.FromBody]UserDetail streamer)
        {
            _repo.AddUser(streamer);

            if (_repo.GetUserById(streamer.Id) != null)
            {
                Login(streamer);
            }
        }

        [Microsoft.AspNetCore.Mvc.HttpGet("Login")]
        public void Login([Microsoft.AspNetCore.Mvc.FromBody]UserDetail streamer)
        {
            Console.WriteLine("");
        }
        
        // GET api/user
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public IEnumerable<User> Get()
        {
            if (!BearerTokenPass())
                return null;

            return _repo.GetAllUsers();
        }

        // GET api/user/{id}
        [Microsoft.AspNetCore.Mvc.HttpGet("{id}")]
        public UserDetail Get(int id)
        {
            if (!BearerTokenPass())
                return null;

            return _repo.GetUserById(id);
        }

        // PUT api/user/{id}
        [Microsoft.AspNetCore.Mvc.HttpPut]
        public void Put(int id, [Microsoft.AspNetCore.Mvc.FromBody]UserDetail streamer)
        {
            if (!BearerTokenPass())
            {
                _repo.UpdateUser(id, streamer);
            }
        }

        // PUT api/user/{id}
        [Microsoft.AspNetCore.Mvc.HttpPut("ChangeAdmin")]
        public void ChangeAdmin(int id, [Microsoft.AspNetCore.Mvc.FromBody]bool admin)
        {
            if (!BearerTokenPass())
            {
                UserDetail streamer = _repo.GetUserById(id);
                streamer.Admin = admin;
                _repo.UpdateUser(id, streamer);
            }
        }

        // PUT api/user/UpdatePassword/{id}
        [Microsoft.AspNetCore.Mvc.HttpPut("UpdatePassword/{id}")]
        public void UpdatePassword(int id, [Microsoft.AspNetCore.Mvc.FromBody] UserPasswordModify user)
        {
            if (!BearerTokenPass())
            {
                _repo.UpdatePassword(user);
            }
        }

        // DELETE api/user/{id}
        [Microsoft.AspNetCore.Mvc.HttpDelete]
        public void Delete(int id)
        {
            if (!BearerTokenPass())
            {
                if(IsAdmin())
                { 
                    _repo.DeleteUser(id);
                }
            }
        }

        private bool IsAdmin()
        {
            var list = _repo.GetAllUsers();
            var userList = new List<UserDetail>();
            foreach (User u in list)
            {
                userList.Add(_repo.GetUserById(u.Id));
            }
            if (userList.First(u => (("Bearer " + u.AccessToken) == this.HttpContext.Request.Headers["Authorization"].ToString())).Admin)
            {
                return true;
            }
            return false;
        }

        private bool BearerTokenPass()
        {
            var list = _repo.GetAllUsers();
            var userList = new List<UserDetail>();
            foreach (User u in list)
            {
                userList.Add(_repo.GetUserById(u.Id));
            }
            try
            {
                var userFound = userList.First(u => (("Bearer " + u.AccessToken) == this.HttpContext.Request.Headers["Authorization"].ToString()));
            }
            catch (InvalidOperationException e)
            {
                throw new UnauthorizedAccessException("Unauthorized access");
            }
            return true;
        }
    }
}
