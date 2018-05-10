using DistributedSystemsStreamerSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace DistributedSystemsStreamerSite.Controllers
{
    public class StreamerController : Controller
    {
        List<Streamer> streamers = new List<Streamer>();
        // GET api/streamer
        public IEnumerable<Streamer> Get()
        {
            return streamers;
        }

        // GET api/streamer/5
        public Streamer Get(int id)
        {
            Streamer streamer = streamers.Where(x => x.Id == id) as Streamer;

            return streamer ?? null;
        }

        // POST api/streamer
        public void Post([FromBody]Streamer streamer)
        {
            streamers.Add(streamer);
        }

        // PUT api/streamer/5
        public void Put(int id, [FromBody]Streamer streamer)
        {
            Streamer temp = Get(id);

            if(temp == null)
            {
                throw new ArgumentException("No existing streamer.");
            }

            UpdateStreamer(temp, streamer);
        }

        // DELETE api/streamer/5
        public void Delete(int id)
        {
            streamers.Remove(Get(id));
        }

        private void UpdateStreamer(Streamer existingStreamer, Streamer newStreamer)
        {
            existingStreamer.FollowerCount = newStreamer.FollowerCount;
            existingStreamer.SubscriberCount = newStreamer.SubscriberCount;
            existingStreamer.PageViewCount = newStreamer.PageViewCount;
            existingStreamer.Name = newStreamer.Name;
        }
    }
}