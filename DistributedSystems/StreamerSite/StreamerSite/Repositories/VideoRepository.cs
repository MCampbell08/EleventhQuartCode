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
            return context.Videos as ICollection<Video> ?? null;
        }
        public Video GetVideoById(int id)
        {
            return context.Videos.FirstOrDefault(u => u.Id == id) ?? null;
        }
        public ICollection<Video> GetAllByUserId(int userId)
        {
            return context.Videos.Where(v => v.User.Id == userId) as ICollection<Video>;
        }
        public void AddVideo(Video video)
        {
            if (video != null)
            {
                context.Add(video);
            }
        }
        public void UpdateVideo(int id, Video newVideo)
        {
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
                oldVideo.User = newVideo.User;
            }
        }
        public void DeleteVideo(int id)
        {
            context.Remove(GetVideoById(id));
        }
    }
}
