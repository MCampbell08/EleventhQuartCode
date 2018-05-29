using StreamerSite.API.Data;
using StreamerSite.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamerSite.API.Repositories
{
    public class UserRepository
    {
        StreamersContext context;

        public UserRepository(StreamersContext ctx)
        {
            context = ctx;
        }

        public ICollection<User> GetAllUsers()
        {
            var users = new List<User>();
            foreach(UserDetail u in context.Users.AsEnumerable())
            {
                users.Add(new User() { Id = u.Id, Username = u.Username });
            }
            return users ?? null;
        }
        public UserDetail GetUserById(int id)
        {
            return context.Users.FirstOrDefault(u => u.Id == id) ?? null;
        }
        public UserDetail GetUserByName(string name)
        {
            return context.Users.FirstOrDefault(u => u.Username == name) ?? null;
        }
        public long AddUser(UserDetail user)
        {
            int userId = 0;
            if (user == null)
            {
                throw new NullReferenceException("User added is null.");
            }
            if (context.Users.ToList().Any(u => u.Username == user.Username))
            {
                throw new Exception("This username already exists for a user.");
            }
            context.Add(user);
            userId = context.SaveChanges();
            return userId;
        }
        public long UpdateUser(int id, UserDetail newUser)
        {
            int userId = 0;
            UserDetail oldUser = GetUserById(id);

            if (oldUser == null)
            {
                throw new ArgumentNullException("User could not be found with that id.");
            }
            else if (newUser == null)
            {
                throw new ArgumentNullException("User cannot be null.");
            }
            else
            {
                oldUser.FollowerCount = newUser.FollowerCount;
                oldUser.SubscriberCount = newUser.SubscriberCount;
                oldUser.PageViewCount = newUser.PageViewCount;
                oldUser.Username = newUser.Username;

                context.SaveChanges();
            }
            return userId;
        }
        public long DeleteUser(int id)
        {
            int userId = 0;
            UserDetail user = GetUserById(id);

            if (user != null) {
                context.Remove(user);
                userId = context.SaveChanges();
            }
            return userId;
        }        
    }
}
