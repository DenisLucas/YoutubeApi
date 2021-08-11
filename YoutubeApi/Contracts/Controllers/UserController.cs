using System;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using Application.Query;
using Application.Command;
using Application.Response;

namespace Presentation.Contracts.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserServices _UserServices;
        public UserController(IMediator mediator, IUserServices UserServices)
        {
            _mediator = mediator;
            _UserServices = UserServices;
            
        }

        [HttpPost(ApiRoutes.user.CreateUser)]
        public async Task<IActionResult> CreateUserAsync([FromBody] RegistrateUserCommand request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("hoi");
            }
            var auth =await _UserServices.UserExistsAsync(request.UserName);
            if (!auth)
            {
            var User = await _mediator.Send(request); 
            var BaseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";    
            var locationuri = BaseUrl + "/" + ApiRoutes.user.Get.Replace("{id}",User.id.ToString());
            return Created(locationuri,
                 new UserReturnResponse {
                    Username = User.Username,
                    Password = User.Password});
            }
            return  BadRequest("Erro: Username already exist");
        }
        [HttpGet(ApiRoutes.user.GetPassword)]
        public async Task<IActionResult> GetPasswordAsync(string user)
        {
            var auth = await _UserServices.UserExistsAsync(user);

            if (auth)
            {
                var query = new GetUserQuery(user);
                var User = await _mediator.Send(query); 
                return Ok(User);
            }
            return BadRequest("Erro: User does not exist");
        }

        [HttpPut(ApiRoutes.user.UpdateUser)]
        public async Task<IActionResult> UpdateUserAsync(int id,string user, string password)
        {
            var auth = await _UserServices.IDExistAsync(id);
            if (auth)
            {
                var query = new UpdateUserCommand(user,password,id);
                var User = await _mediator.Send(query);
                return Ok(User);
            }
            return BadRequest("Erro: ID does not match");

        }
        [HttpDelete(ApiRoutes.user.DeleteUser)]
        public async Task<IActionResult> DeleteUserAsync(string user,string password)
        {

            var auth = await _UserServices.UserAuthentificationAsync(user,password);
            if (auth)
            {
                var query = new DeleteUserCommand(user,password);
                var User = await _mediator.Send(query);
                if (User)
                {
                    return NoContent();
                }
                return BadRequest("Erro: Deleting wasn't succesfull ");
            }
            return BadRequest("Erro: User or password does not match"); 
              
        }
        
    }
}
