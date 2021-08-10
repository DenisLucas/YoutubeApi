using System;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IUserServices
    {
        Task<bool> IDExistAsync(int id);
        Task<bool> UserAuthentificationAsync(string username,string password);
        Task<bool> UserExistsAsync(string username);
        Task<bool> UserOwnsVideo(string user, string videoName);
        Task<bool> VideoExistAsync(string video);
    }
}
