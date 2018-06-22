using System.Collections.Generic;

namespace CheezeIT.JiveAPI.Model
{
    public class JiveResources
    {
        public JiveResourceEntry self { get; set; }
        public JiveResourceEntry childOutcomeTypes { get; set; }
        public JiveResourceEntry messages { get; set; }
        public JiveResourceEntry outcomeTypes { get; set; }
        public JiveResourceEntry extprops { get; set; }
        public JiveResourceEntry outcomes { get; set; }
        public JiveResourceEntry followers { get; set; }
        public JiveResourceEntry likes { get; set; }
        public JiveResourceEntry read { get; set; }
        public JiveResourceEntry html { get; set; }
        public JiveResourceEntry images { get; set; }
        public JiveResourceEntry attachments { get; set; }
        public JiveResourceEntry followingIn { get; set; }
        public JiveResourceEntry entitlements { get; set; }
        public JiveResourceEntry avatar { get; set; }


    }

    public class JiveResourceEntry
    {
        public List<string> allowed { get; set; }
        public string @ref { get; set; }
    }
}
