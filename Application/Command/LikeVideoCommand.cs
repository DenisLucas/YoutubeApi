using System;
using MediatR;

namespace Application.Command
{
    public class LikeVideoCommand : IRequest<bool>
    {
        public string video;
        public string Username;

        public LikeVideoCommand(string video, string username)
        {
            this.video = video;
            Username = username;
        }
    }
}
