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
        static List<User> streamers = new List<User>();
        // GET api/streamer

        public IEnumerable<User> Get()
        {
            return streamers;
        }

        // GET api/streamer/5
        public User Get(int id)
        {
            User streamer = streamers.Where(x => x.Id == id) as User;

            return streamer ?? null;
        }

        // POST api/streamer
        public void Post([FromBody]User streamer)
        {
            streamers.Add(streamer);
        }

        // PUT api/streamer/5
        public void Put(int id, [FromBody]User streamer)
        {
            User temp = Get(id);

            if (temp == null)
            {
                throw new ArgumentException("No existing streamer.");
            }

            UpdateUser(temp, streamer);
        }

        // DELETE api/streamer/5
        public void Delete(int id)
        {
            streamers.Remove(Get(id));
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