using DistributedSystemsStreamerSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace DistributedSystemsStreamerSite.Data
{
    public class StreamersContext : DbContext
    {
        public StreamersContext(DbContextOptions<StreamersContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Video> Videos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
        }
    }
}