using System;
using System.Collections.Generic;

namespace CheezeIT.JiveAPI.Model
{
    public class WorkflowDefinition
    {
        public int WorkflowDefinitionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public JiveInstance JiveInstance { get; set; }
        public List<Workflow> Workflows { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
