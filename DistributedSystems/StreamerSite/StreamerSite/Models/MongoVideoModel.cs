using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamerSite.API.Models
{
    public class MongoVideoModel
    {
        public ObjectId _id { get; set; }
        public string FileName { get; set; }
        public string VideoDataAsString { get; set; }
    }
}
