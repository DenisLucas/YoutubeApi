using System;
namespace Domain.Entities
{
    public class Video
    {
        public int id { get; set; }
        public string VideoName { get; set; }
        public string url { get; set; }
        public User User { get; set; }
    }
}
