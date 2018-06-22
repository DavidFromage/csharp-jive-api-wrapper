using System;
using System.Collections.Generic;

namespace CheezeIT.JiveAPI.Model
{
    public class JiveInstance
    {
        public string JiveInstanceId { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public string Url { get; set; }

        public virtual List<User> Users { get; set; }
        public string CommunityLanguage { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool IsComplete { get; set; }
        public string Version { get; set; }
        public List<JiveAddon> JiveAddons { get; set; }
        public bool IsLicensed { get; set; }

        public bool IsInstalledViaAddon { get; set; }
        public List<WorkflowDefinition> WorkflowDefinitions { get; set; }

    }
}
