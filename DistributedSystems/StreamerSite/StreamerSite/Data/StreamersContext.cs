using Microsoft.EntityFrameworkCore;
using StreamerSite.API.Models;  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data;

namespace StreamerSite.API.Data
{
    public class StreamersContext : DbContext
    {
        public StreamersContext()
        {

        }

        public StreamersContext(DbContextOptions<StreamersContext> options) : base(options)
        {
        }

        public DbSet<UserDetail> Users { get; set; }
        public DbSet<Video> Videos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySQL(@"Server=localhost;Port=3306;Database=streamersite;Uid=root;pwd=1_Tails_4;SslMode=None;");
        }
    }
}
