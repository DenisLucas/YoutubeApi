using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Command;
using Application.Request;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers
{
    public class CreateVideoHandler : IRequestHandler<CreateVideoCommand, VideoResponse>
    {
        public AppDBContext _context;
        public CreateVideoHandler(AppDBContext context)
        {
            _context = context;
        }
        
        public async Task<VideoResponse> Handle(CreateVideoCommand request, CancellationToken cancellationToken)
        {
            var Video = await _context.User.Where(
                x => x.Username == request.username && 
                x.Password == request.password).FirstOrDefaultAsync();
            
              var video =  new Video
            {
                VideoName = request.videoName,
                url = request.url,
                Userid = Video.id
            };
            await _context.Video.AddAsync(video);
            await _context.SaveChangesAsync();

            return new VideoResponse
            {
                id = video.id,
                videoName = video.VideoName,
                username = Video.Username,
                url = video.url
            };
            
        }
    }
}
