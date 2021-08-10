using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Video
    {
        public int id { get; set; }
        public int favs {get; set;}
        public string VideoName { get; set; }
        public string url { get; set; }
        public int Userid { get; set; }
    }
}
