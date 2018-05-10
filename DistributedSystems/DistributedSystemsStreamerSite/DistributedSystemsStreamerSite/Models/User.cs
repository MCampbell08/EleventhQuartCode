using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DistributedSystemsStreamerSite.Models
{
    public class User
    {
        public int Id { get; set; }

        public int FollowerCount { get; set; }

        public int SubscriberCount { get; set; }

        public int PageViewCount { get; set; }

        public string Name { get; set; }
    }
}