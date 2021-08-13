using System;
using Application.Request;
using MediatR;

namespace Application.Command
{
    public class UpdateVideoCommand : IRequest<VideoRequest>
    {
        public VideoUpdateRequest video;
        public UpdateVideoCommand(VideoUpdateRequest Video)
        {
            video = Video;
        }
    }
}
