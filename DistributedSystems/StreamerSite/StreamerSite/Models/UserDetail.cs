using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StreamerSite.API.Models
{
    [Table("User")]
    public class UserDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }
        [Column("FollowerCount")]
        public int FollowerCount { get; set; }
        [Column("SubcriberCount")]
        public int SubscriberCount { get; set; }
        [Column("PageViewCount")]
        public int PageViewCount { get; set; }
        [Column("Username", TypeName = "TEXT")]
        [StringLength(25, ErrorMessage = "Username cannot be greater than 25 characters."), MinLength(1)]
        public string Username { get; set; }
        [Column("Email", TypeName = "TEXT")]
        public string Email { get; set; }
        [Column("Password", TypeName = "TEXT")]
        [StringLength(14, ErrorMessage = "Password cannot be greater than 14 characters"), MinLength(8)]
        public string Password { get; set; }
        [Column("Videos")]
        public ICollection<Video> Videos { get; set; }
        public bool Admin { get; set; }
    }
}
