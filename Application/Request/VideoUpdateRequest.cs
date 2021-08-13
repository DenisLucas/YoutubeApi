using System;

namespace Application.Request
{
    public class VideoUpdateRequest
    {

        public string videoName { get; set; }
        public string newVideoName { get; set; }
        public string url { get; set; }
    }
}
