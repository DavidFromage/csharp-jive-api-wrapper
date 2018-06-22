using System;
using System.Collections.Generic;

namespace CheezeIT.JiveAPI.Model
{
    public class JiveAddon
    {
        public int JiveAddonId { get; set; }
        public string AddonType { get; set; }
        public DateTime DateCreated { get; set; }
        public JiveInstance JiveInstance { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string JiveSignatureURL { get; set; }
        public string TimeStamp { get; set; }
        public string JiveSignature { get; set; }
        public string Scope { get; set; }
        public string Code { get; set; }
        public bool Uninstalled { get; set; }
        public List<JiveTileInstance> JiveTileInstances { get; set; }
    }
}
