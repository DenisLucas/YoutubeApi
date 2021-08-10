using System;
using MediatR;

namespace Application.Command
{
    public class LikeVideoCommand : IRequest<bool>
    {
        public string video;

        public LikeVideoCommand(string video)
        {
            this.video = video;
        }
    }
}
