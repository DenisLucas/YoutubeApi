using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using Application.Command;
using Application.Request;
using Application.Services;
using Application.Query;

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

        [HttpPost(ApiRoutes.video.CreateVideo)]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateVideoCommand request)
        {
            var auth = await _UserServices.UserAuthentificationAsync(request.username,request.password);
            if (auth)
            {
            var Video = await _mediator.Send(request); 
            var BaseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";    
            var locationuri = BaseUrl + "/" + ApiRoutes.video.Get.Replace("{id}",Video.id.ToString());
            return Created(locationuri,
                new VideoResponseView {
                    videoName = Video.videoName,
                    url = Video.url});
            }
            return BadRequest("Erro: User Or Password Dont Match");
        }

        
        [HttpGet(ApiRoutes.video.GetVideo)]
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
        
        [HttpPut(ApiRoutes.video.UpdateVideo)]
        public async Task<IActionResult> UpdateVideo(string username, string Password, string videoName, string newVideoName,string url)
        {
            var auth = await _UserServices.UserAuthentificationAsync(username,Password);
            if (auth)
            {
                var videoexist = await _UserServices.VideoExistAsync(videoName);
                if (videoexist)
                {
                    var userOwns = await _UserServices.UserOwnsVideo(username,videoName);
                    if(userOwns)
                    {
                        var query = new UpdateVideoCommand(videoName, url,newVideoName);
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
            return BadRequest("username or password incorrect");
        }

        [HttpDelete(ApiRoutes.video.DeleteVideo)]
        public async Task<IActionResult> DeleteVideo(string username, string Password, string videoName)
        {
            var auth = await _UserServices.UserAuthentificationAsync(username,Password);
            if (auth)
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
            return BadRequest("You don't own this video");
        }

        [HttpPut(ApiRoutes.video.LikeVideo)]
        public async Task<IActionResult> LikeVideo(string username, string Password, string videoName)
        {
            var auth = await _UserServices.UserAuthentificationAsync(username, Password);
            if (auth)
            {
                var command = new LikeVideoCommand(videoName);
                var Query = await _mediator.Send(command);
                if(Query)
                {
                    return Ok();
                }
                return BadRequest("Erro: unable to like the video");
            }
            return BadRequest("Erro: User or Password Incorrect");
        }
        
    }
}
