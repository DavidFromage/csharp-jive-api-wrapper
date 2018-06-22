using System;
using System.Collections.Generic;

namespace CheezeIT.JiveAPI.Model
{
    public class Place
    {
        public int followerCount { get; set; }
        public DateTime published { get; set; }
        public DateTime updated { get; set; }
        public string placeID { get; set; }
        public string description { get; set; }
        public string displayName { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public int viewCount { get; set; }
        public bool visibleToExternalContributors { get; set; }
        public Person creator { get; set; }
        public string groupType { get; set; }
        public int memberCount { get; set; }
        public bool extendedAuthorsEnabled { get; set; }
        public string type { get; set; }
    }
}