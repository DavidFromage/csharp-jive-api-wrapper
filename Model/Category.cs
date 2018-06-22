using System;
using System.Collections.Generic;

namespace CheezeIT.JiveAPI.Model
{
    public class Category
    {
        public string description { get; set; }
        public int followerCount { get; set; }
        public string id { get; set; }
        public int likeCount { get; set; }
        public string name { get; set; }
        public string place { get; set; }
        public DateTime published { get; set; }
        public Object resources { get; set; }
        public List<string> tags { get; set; }
        public string type { get; set; }
        public DateTime updated { get; set; }

    }
}
