using System;

namespace Application.Request
{
    public class VideoResponse
    {
        public int id { get; set; }
        public string videoName { get; set; }
        public string url { get; set; }
        public string username { get; set; }

    }
    public class VideoResponseView 
    {
        public string videoName { get; set; }
        public string url { get; set; }
        public int fav { get; set; }

    }

}
