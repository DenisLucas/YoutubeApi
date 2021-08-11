using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class UserServices : IUserServices
    {
        public AppDBContext _context;
        public UserServices(AppDBContext context)
        {
            _context = context;
        }
        public async Task<bool> UserAuthentificationAsync(string username,string password)
        {
            var userToTest = await _context.User.Where(x=> x.Username == username).FirstOrDefaultAsync();
            if (userToTest != null)
            {
                if (userToTest.Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> UserExistsAsync(string username) 
        {
            var userToTest = await _context.User.Where(x=> x.Username == username).FirstOrDefaultAsync();
            if (userToTest  != null)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> IDExistAsync(int id)

        {
            var userToTest = await _context.User.Where(x=> x.id == id).FirstOrDefaultAsync();
            if (userToTest  != null)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> VideoExistAsync(string video)
        {
            var videoToTest = await _context.Video.Where(x=> x.VideoName == video).FirstOrDefaultAsync();
            if (videoToTest  != null)
            {
                return true;
            }
            return false;
        }
    
        public async Task<bool> UserOwnsVideo(string user, string videoName)
        {
            var userid = await _context.User.Where(x=> x.Username == user).FirstOrDefaultAsync();
            var VideoName = await _context.Video.Where(x=> x.Userid == userid.id).ToListAsync();
            foreach (var video in VideoName)
            {
            if (video.VideoName == videoName)
            {
                return true;
            }
            }
            return false;
        }

        public async Task<bool> Liked(string videoName, string username)
        {
            var videoID = await _context.Video.Where(x=> x.VideoName == videoName).FirstOrDefaultAsync();
            var userID = await _context.User.Where(x=>x.Username == username).FirstOrDefaultAsync();
           
            var liked = await _context.LikesAndUsers.Where(x=> x.VideoID == videoID.id && x.UserID == userID.id).FirstOrDefaultAsync();
            if (liked == null)
            {
                return true;
            }
            return false;
        }
    
    }
}
