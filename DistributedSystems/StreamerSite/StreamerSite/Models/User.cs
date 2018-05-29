using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StreamerSite.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
    }
}
