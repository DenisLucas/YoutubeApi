using System;
using Application.Request;
using MediatR;

namespace Application.Command
{
    public class UpdateVideoCommand : IRequest<VideoRequest>
    {
        public string videoName;
        public string newVideoName;
     
        public string url;
        public UpdateVideoCommand(string VideoName, string Url, string newVideoName)
        {
            videoName = VideoName;
            url = Url;
            this.newVideoName = newVideoName;
        }
    }
}
