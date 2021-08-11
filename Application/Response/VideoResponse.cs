using System;

namespace Application.Response
{
    public class VideoResponse
    {
        public string videoName { get; set; }
        public string url { get; set; }
        public int fav { get; set; }

    }
    public class VideoUpdateResponse
    {
        public int id { get; set; }
        public string videoName { get; set; }
        public string url { get; set; }
        public string username { get; set; }

    }
}
