using System;
using System.Collections.Generic;

namespace CheezeIT.JiveAPI.Model
{
    public class OutcomeType
     {
         public string communityAudience { get; set; }
         public string confirmContentEdit { get; set; }
         public Boolean confirmExclusion { get; set; }
         public Boolean confirmUnmark { get; set; }
         public List<Field> fields { get; set; }
         public Boolean generalNote { get; set; }
         public string id { get; set; }
         public string name { get; set; }
         public Boolean noteRequired { get; set; }
         public Object recources { get; set; }
         public Boolean shareable { get; set; }
         public Boolean urlAllowed { get; set; }

    }
}
