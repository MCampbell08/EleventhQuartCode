using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DistributedSystemsStreamerSite.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int FollowerCount { get; set; }
        public int SubscriberCount { get; set; }
        public int PageViewCount { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Video> Videos { get; set; }
        public bool Admin { get; set; }
        public bool ShouldSerializePassword() { return Admin; }
    }
}