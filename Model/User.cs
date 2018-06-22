using System;

namespace CheezeIT.JiveAPI.Model
{
    public class User
    {
        public string UserId { get; set; }
        public int ShortId
        {

            get
            {
                string[] jiveInstanceTemp = this.UserId.Split('@');
                String shortenedId = jiveInstanceTemp[0];
                return Convert.ToInt32(shortenedId);
            }

        }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Department { get; set; }
        public bool IsComplete { get; set; }
        public DateTime LastUpdated { get; set; }
        public DateTime DateCreated { get; set; }
        public bool HasInstalledApp { get; set; }

        public JiveInstance JiveInstance { get; set; }
        public string RefreshToken { get; set; }
        public string AccessToken { get; set; }
   
    }
}
