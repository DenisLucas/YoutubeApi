using System;
using Application.Response;
using MediatR;

namespace Application.Command
{
    public class CreateVideoCommand : IRequest<VideoUpdateResponse>
    {
        public string videoName { get; set; }
        public string url { get; set; }
        public string username { get; set; }
        public string password { get; set;}
    }
}
