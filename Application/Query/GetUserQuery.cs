using Application.Request;
using MediatR;

namespace Application.Query
{
    public class GetUserQuery : IRequest<UserRequest>
    {
        public string username;
        public GetUserQuery(string Username)
        {
            username = Username;
        }
                
    }
}
