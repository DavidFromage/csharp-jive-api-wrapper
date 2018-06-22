using System;
using System.Collections.Generic;

namespace CheezeIT.JiveAPI.Model
{
    public class PollOptionImage
   {
       public int followerCount { get; set; }
       public Image image { get; set; }
       public int likeCount { get; set; }
       public string option { get; set; }
       public DateTime published {get;set;}
       public Object recources {get;set;}
       public List<string> tags { get; set; }
       public DateTime úpdated { get; set; }
        
    }
}
