using System;
using System.Collections.Generic;
using Application.Request;
using MediatR;

namespace Application.Query
{
    public class GetVideoQuery : IRequest<VideoRequest>
    {
        public string VideoName;
        public GetVideoQuery(string videoName)
        {
            VideoName = videoName;
        }
        
    }
}
