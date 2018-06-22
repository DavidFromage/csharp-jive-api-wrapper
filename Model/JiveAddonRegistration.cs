namespace CheezeIT.JiveAPI.Model
{
    public class JiveAddonRegistration
    {
        public int JiveAddonRegistrationId { get; set; }
        public string Timestamp { get; set; }

        public string JiveSignatureURL { get; set; }

        public string TenantId { get; set; }

        public string JiveUrl { get; set; }

        public string JiveSignature { get; set; }

        public string ClientSecret { get; set; }

        public string ClientId { get; set; }

        public string Uninstalled { get; set; }

        public string Code { get; set; }
        public string Scope { get; set; }
    }
}
