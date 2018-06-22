using System;
using System.Collections.Generic;

namespace CheezeIT.JiveAPI.Model
{
    public class Person
    {
        public DateTime updated { get; set; }
        public string status { get; set; }
        public Name name { get; set; }
        public string displayName { get; set; }
        public string type { get; set; }
        public int id { get; set; }
        public List<Photo> photos { get; set; }
        /*
        public int followerCount { get; set; }
        public int followingCount { get; set; }
       
        public string location { get; set; }
        
        public string thumbnailId { get; set; }
        public string thumbnailUrl { get; set; }
        
        public List<ProfileEntry> emails { get; set; }
        public JivePerson jive { get; set; }
        
        public List<ProfileEntry> phoneNumbers { get; set; }
        
        public DateTime published { get; set; }
        public List<string> tags { get; set; }
        public JiveResources resources { get; set; }*/



    }

    public class JivePerson
    {
        public bool enabled { get; set; }
        public bool external { get; set; }
        public bool externalContributor { get; set; }
        public bool federated { get; set; }
        public DateTime lastProfileUpdate { get; set; }
        public Level level { get; set; }
        public string locale { get; set; }
        public List<ProfileEntry> profile { get; set; }
        public bool sendeable { get; set; }
        public bool termsAndConditionsRequired { get; set; }
        public string timeZone { get; set; }
        public string username { get; set; }
        public bool viewContent { get; set; }
        public bool visible { get; set; }
    }

    public class Level
    {
        public string description { get; set; }
        public string imageURI { get; set; }
        public string name { get; set; }
        public int points { get; set; }
    }

    public class ProfileEntry
    {
        public string jive_label { get; set; }
        public string value { get; set; }
        public string type { get; set; }
        public bool primary { get; set; }
    }
    public class Name
    {
        public string familyName { get; set; }
        public string formatted { get; set; }
        public string givenName { get; set; }
    }
    public class Photo
    {
        public string value { get; set; }
        public bool jive_showSummaryLabel { get; set; }
    }
}
