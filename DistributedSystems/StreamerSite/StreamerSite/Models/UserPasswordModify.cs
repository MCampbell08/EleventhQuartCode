using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamerSite.API.Models
{
    public class UserPasswordModify
    {
        public int UserId { get; set; }
        public string Password { get; set; }
    }
}
