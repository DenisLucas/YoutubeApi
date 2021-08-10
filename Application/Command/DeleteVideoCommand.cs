using System;
using System.Threading.Tasks;
using MediatR;

namespace Application.Command
{
    public class DeleteVideoCommand : IRequest<bool>
    {
        public string videoName;
        public DeleteVideoCommand(string VideoName)
        {
            videoName = VideoName;
        }
    }
}
