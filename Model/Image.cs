using System;
using System.Collections.Generic;

namespace CheezeIT.JiveAPI.Model
{
    public class Image
   {
       public string contentType { get; set;}
       public string description { get; set;}
       public int followerCount { get; set;}
       public int height { get; set; }
       public string id { get; set; }
       public int likeCount { get; set; }
       public string name { get; set; }
       public DateTime published { get; set; }
       public string @ref {get; set;}
       public Object resources {get; set;}
       public int index { get; set; }
       public int size {get; set;}
       public List<string> tags {get; set;}
       public string type {get; set;}
       public DateTime updated { get; set; }
       public int width { get; set; }
       
    }
}
