using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using StreamerSite.API.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamerSite.API
{
    public class MongoGridFsUtilizer
    {
        private MongoServer server;
        private MongoDatabase database;
        private MongoGridFS gridFS;

        public MongoGridFsUtilizer()
        {
            server = new MongoClient("mongodb://localhost").GetServer();
            database = server.GetDatabase("streamersite");
            gridFS = new MongoGridFS(database);
        }
        public MongoCollection<MongoVideoModel> GetVideoCollection()
        {
            return database.GetCollection<MongoVideoModel>("streamervideos");
        }
    }
}
