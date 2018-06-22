using System;
using System.Collections.Generic;

namespace CheezeIT.JiveAPI.Model
{
    public class Announcement
    {
        public Person author { get; set; }
        public ContentBody content { get; set; }
        public List<Image> contentImages { get; set; }
        public List<ContentVideo> contentVideos { get; set; }
        public DateTime endDate { get; set; }
        public int followerCount { get; set; }
        public string highlightBody { get; set; }
        public string highlightSubject { get; set; }
        public string highlightTags { get; set; }
        public string iconCss { get; set; }
        public string id { get; set; }
        public string image { get; set; }
        public int likeCount { get; set; }
        public string parent { get; set; }
        public Summary parentContent { get; set; }
        public Boolean parentContentVisible { get; set; }
        public DateTime publishDate { get; set; }
        public DateTime published { get; set; }
        public int replyCount { get; set; }
        public Object resources { get; set; }
        public int sortKey { get; set; }
        public string status { get; set; }
        public string subject { get; set; }
        public string subjectURI { get; set; }
        public string subjectURITargetType { get; set; }
        public string type { get; set; }
        public DateTime updated { get; set; }
        public int viewCount { get; set; }
        public Boolean visibleToExternalContributors { get; set; }


    }
  
}
