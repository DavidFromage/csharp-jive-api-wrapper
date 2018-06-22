namespace CheezeIT.JiveAPI.Model
{
    public class OAuthRequest
    {
        public string OAuthRequestId { get; set; }
        public User User { get; set; }
        public bool IsCompleted { get; set; }
    }
}
