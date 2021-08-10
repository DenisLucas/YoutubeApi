using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Command;
using Application.Request;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers
{
    public class UpdateVideoHandler : IRequestHandler<UpdateVideoCommand, VideoRequest>
    {
        public AppDBContext _context;
        public UpdateVideoHandler(AppDBContext context)
        {
            _context = context;
        }
        public async Task<VideoRequest> Handle(UpdateVideoCommand request, CancellationToken cancellationToken)
        {
            var video = await _context.Video.Where(x=> x.VideoName == request.videoName).FirstOrDefaultAsync();
            video.VideoName = request.newVideoName;
            video.url = request.url;
            await _context.SaveChangesAsync();
            return new VideoRequest
            {
                videoName = video.VideoName,
                url = video.url
            };

        }
    }
}
