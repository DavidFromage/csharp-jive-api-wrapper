using System;
using System.Collections.Generic;

namespace CheezeIT.JiveAPI.Model
{
    public class File: Content{
        public List<Person> authors {get;set;}
        public string autorship {get;set;}
        public string binaryURL {get;set;}
        public string contentType {get;set;}
        public Boolean restrictComments {get;set;}
        public int size {get;set;}
        public Person users {get;set;}
        
    
    }
}
