using System;

namespace CheezeIT.JiveAPI.Model
{
    public class Document: Content{
         public Person approvers {get;set;}
         public string authorship {get;set;}
         public Person editingBy {get;set;}
         public string fromQuest {get;set;}
         public Boolean restrictComments {get;set;}
         

     
    }
}
