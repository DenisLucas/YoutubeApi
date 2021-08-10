using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Query;
using Application.Request;
using MediatR;

namespace Application.Handlers
{
    public class GetVideoHandler : IRequestHandler<GetVideoQuery, VideoRequest>
    {
        public AppDBContext _context;
        public GetVideoHandler(AppDBContext context)
        {
            _context = context;
        }
        public async Task<VideoRequest> Handle(GetVideoQuery request, CancellationToken cancellationToken)
        {
            var video = await _context.Video.Where(x=> x.VideoName.ToLower() == request.VideoName.ToLower()).FirstOrDefaultAsync();
            return new VideoRequest
            {
                videoName = video.VideoName,
                url = video.url,
                fav = video.favs
            };
        }
    }
}
