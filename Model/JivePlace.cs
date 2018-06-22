using System;
using System.Collections.Generic;

namespace CheezeIT.JiveAPI.Model
{
    public class JivePlace
    {
        public string JivePlaceId { get; set; }
        public JiveInstance JiveInstance { get; set; }

        public List<Workflow> Workflows { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
