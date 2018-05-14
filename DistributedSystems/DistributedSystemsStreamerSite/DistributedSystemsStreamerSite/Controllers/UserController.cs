using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DistributedSystemsStreamerSite.Models;
using System.Web.Http;

namespace DistributedSystemsStreamerSite.Controllers
{
    public class UserController : ApiController
    {
        static List<User> users = new List<User>();
        
        public UserController()
        {

        }

        public UserController(List<User> newUsers)
        {
            users = newUsers;
        }

        // GET api/user
        public IEnumerable<User> Get()
        {
            return users;
        }

        // GET api/user/{id}
        public User Get(int id)
        {
            User streamer = users.Single(x => x.Id == id);

            return streamer ?? null;
        }

        // GET api/user/{id}/videos
        public IEnumerable<Video> GetVideos(int id)
        {
            User user = Get(id);

            return user.Videos;
        }

        // POST api/user
        public void Post([FromBody]User streamer)
        {
            users.Add(streamer);
        }

        // PUT api/user/{id}
        public void Put(int id, [FromBody]User streamer)
        {
            User temp = Get(id);

            if (temp == null)
            {
                throw new ArgumentException("No existing streamer.");
            }

            UpdateUser(temp, streamer);
        }

        // DELETE api/user/{id}
        public void Delete(int id)
        {
            users.Remove(Get(id));
        }

        private void UpdateUser(User existingUser, User newUser)
        {
            existingUser.FollowerCount = newUser.FollowerCount;
            existingUser.SubscriberCount = newUser.SubscriberCount;
            existingUser.PageViewCount = newUser.PageViewCount;
            existingUser.Name = newUser.Name;
        }
    }
}