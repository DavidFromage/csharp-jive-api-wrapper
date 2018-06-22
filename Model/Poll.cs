using System;
using System.Collections.Generic;

namespace CheezeIT.JiveAPI.Model
{
    public class Poll: Content {
        public List<String> options {get;set;}
        public List<PollOptionImage> optionsImages {get;set;}
        public List<Person> users {get;set;}
        public int voteCount {get;set;}
        public List<string> votes {get;set;}
        
    
    }
}
