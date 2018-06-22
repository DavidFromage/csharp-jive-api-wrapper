using System;
using System.Collections.Generic;

namespace CheezeIT.JiveAPI.Model
{
    public class Workflow
    {
        public int WorkflowId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public JiveInstance JiveInstance { get; set; }
        public JivePlace JivePlace { get; set; }
        public List<WorkflowInstance> WorkflowInstances { get; set; }
        public WorkflowDefinition WorkflowDefinition { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
