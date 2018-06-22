using System;

namespace CheezeIT.JiveAPI.Model
{
    public class WorkflowInstance
    {
        public int WorkflowInstanceId { get; set; }
        public JiveContent JiveContent { get; set; }
        public Workflow Workflow { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
