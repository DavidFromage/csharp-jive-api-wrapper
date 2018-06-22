namespace CheezeIT.JiveAPI.Model
{
    public class JiveTileInstance
    {
        public int JiveTileInstanceId { get; set; }
        public JiveAddon JiveAddon { get; set; }
        public int TileId { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public int ExpiresIn { get; set; }
        public string Url { get; set; }
        public string TileType { get; set; }
       
    }
}
