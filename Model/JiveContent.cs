using System.Collections.Generic;

namespace CheezeIT.JiveAPI.Model
{
    public class JiveContent
    {
        public string JiveContentId { get; set; }
        public JiveInstance JiveInstance { get; set; }
        public List<WorkflowInstance> WorkflowInstances { get; set; }

    }
}
