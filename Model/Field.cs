using System;
using System.Collections.Generic;

namespace CheezeIT.JiveAPI.Model
{
    public class Field
    {
        public Boolean array { get; set; }
        public string availability { get; set; }
        public string description { get; set; }
        public string displayName { get; set; }
        public Boolean editable { get; set; }
        public string name { get; set; }
        public List<string> options { get; set; }
        public Boolean required { get; set; }
        public string since { get; set; }
        public string type { get; set; }
        public Boolean unpublished { get; set; }
    }
}
 