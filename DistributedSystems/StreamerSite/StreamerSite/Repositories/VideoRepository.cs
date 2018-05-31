using StreamerSite.API.Data;
using StreamerSite.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamerSite.API.Repositories
{
    public class VideoRepository
    {
        StreamersContext context;

        public VideoRepository(StreamersContext ctx)
        {
            context = ctx;
        }
        public ICollection<Video> GetAllVideos()
        {
            return context.Videos.ToArray() ?? null;
        }
        public Video GetVideoById(int id)
        {
            return context.Videos.FirstOrDefault(u => u.Id == id) ?? null;
        }
        public ICollection<Video> GetAllByUserId(int userId)
        {
            return context.Videos.Where(v => v.UserId == userId).ToArray() ?? null;
        }
        public long AddVideo(Video video)
        {
            int videoId = 0;
            if (video == null)
            {
                throw new NullReferenceException("Video added is null.");
            }
            context.Add(video);
            videoId = context.SaveChanges();
            return videoId;
        }
        public long UpdateVideo(int id, Video newVideo)
        {
            int videoId = 0;
            Video oldVideo = GetVideoById(id);

            if (oldVideo == null)
            {
                throw new ArgumentNullException("Video could not be found with that id.");
            }
            else if (newVideo == null)
            {
                throw new ArgumentNullException("Video cannot be null.");
            }
            else
            {
                oldVideo.Path = newVideo.Path;
                oldVideo.UserId = newVideo.UserId;

                videoId = context.SaveChanges();
            }
            return videoId;
        }
        public long DeleteVideo(int id)
        {
            int videoId = 0;
            Video video = GetVideoById(id);

            if (video != null)
            {
                context.Remove(video);
                videoId = context.SaveChanges();
            }
            return videoId;
        }
    }
}
