using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using Application.Command;
using Application.Request;
using Application.Services;
using Application.Query;
using Application.Response;

namespace Presentation.Contracts.Controllers
{
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserServices _UserServices;
        public VideoController(IMediator mediator, IUserServices UserServices)
        {
            _mediator = mediator;
            _UserServices = UserServices;
            
        }

        [HttpPost(ApiRoutes.video.create)]
        public async Task<IActionResult> CreateVideoAsync([FromBody] CreateVideoCommand request)
        {
            var videoexist = await _UserServices.VideoExistAsync(request.videoName);
            if (!videoexist)
            {
                var auth = await _UserServices.UserAuthentificationAsync(request.username,request.password);
                if (auth)
                {
                var Video = await _mediator.Send(request); 
                var BaseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";    
                var locationuri = BaseUrl + "/" + ApiRoutes.video.Get.Replace("{id}",Video.id.ToString());
                return Created(locationuri,
                    new VideoResponse {
                        videoName = Video.videoName,
                        url = Video.url});
                }
                return BadRequest("Erro: User Or Password Dont Match");
            }
            return BadRequest("Erro: A video with this name already exist");
        }

        
        [HttpGet(ApiRoutes.video.read)]
        public async Task<IActionResult> GetVideoByNameAsync(string videoName)
        {
            var auth = await _UserServices.VideoExistAsync(videoName);
            if (auth)
            {
                var request = new GetVideoQuery(videoName);
                var query = await _mediator.Send(request);
                return Ok(query);
            }
            return BadRequest("Erro: Video Does not exist");
        }
        
        [HttpPut(ApiRoutes.video.update)]
        public async Task<IActionResult> UpdateVideoAsync(string username,[FromBody] VideoUpdateRequest request)
        {
            var videoexist = await _UserServices.VideoExistAsync(request.videoName);
            if (videoexist)
            {
                var userOwns = await _UserServices.UserOwnsVideo(username,request.videoName);
                if(userOwns)
                {
                    var query = new UpdateVideoCommand(request);
                    var result = await _mediator.Send(query);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    return BadRequest("Erro: Failed to Delete");
                }
                return BadRequest("Erro: User don't own this video");
            
            }
            return BadRequest("Erro: Video Doesn't Exist");
        }

        [HttpDelete(ApiRoutes.video.delete)]
        public async Task<IActionResult> DeleteVideoAsync(string username, string videoName)
        {
            var videoexist = await _UserServices.VideoExistAsync(videoName);
            if (videoexist)
            {
                var userOwns = await _UserServices.UserOwnsVideo(username,videoName);
                if(userOwns)
                {
                    var query = new DeleteVideoCommand(videoName);
                    var result = await _mediator.Send(query);
                    if (result)
                    {
                        return Ok();
                    }
                    return BadRequest("Erro: Failed to Delete");
                }
                return BadRequest("Erro: User don't own this video");
            
            }
            return BadRequest("Erro: Video Doesn't Exist");
        }

        [HttpPut(ApiRoutes.video.like)]
        public async Task<IActionResult> LikeVideoAsync(string username, string videoName)
        {
            var isFirst = await _UserServices.Liked(videoName,username);
            if (isFirst)
            {
            var command = new LikeVideoCommand(videoName,username);
            var Query = await _mediator.Send(command);
            if(Query)
            {
                return Ok();
            }
            return BadRequest("Erro: unable to like the video");
            }
            return BadRequest("Erro: You already liked this video");
        
        }
        
    }
}
