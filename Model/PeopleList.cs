using System.Collections.Generic;

namespace CheezeIT.JiveAPI.Model
{
    public class PersonList
    {
        public int itemsPerPage { get; set; }
        //public ListLinks links { get; set; }
        public List<Person> list { get; set; }
    }
}
