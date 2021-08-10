using System;
using Application.Request;
using MediatR;

namespace Application.Command
{
    public class CreateVideoCommand : IRequest<VideoResponse>
    {
        public string videoName { get; set; }
        public string url { get; set; }
        public string username { get; set; }
        public string password { get; set;}
    }
}
