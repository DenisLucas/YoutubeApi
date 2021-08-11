using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Command;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Handlers
{
    public class LikeVideoHandler : IRequestHandler<LikeVideoCommand, bool>
    {
        public AppDBContext _context;
        public LikeVideoHandler(AppDBContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(LikeVideoCommand request, CancellationToken cancellationToken)
        {
            
            var video = await _context.Video.Where(x=>x.VideoName == request.video).FirstOrDefaultAsync();
            video.favs += 1;
            var user = await _context.User.Where(x=>x.Username == request.Username).FirstOrDefaultAsync();
            var liked = new LikesAndUsers{
                UserID = user.id,
                VideoID = video.id};
            await _context.LikesAndUsers.AddAsync(liked);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
