using System;
using System.Collections.Generic;

namespace CheezeIT.JiveAPI.Model
{
    public class PlacesList
    {
        public List<Place> list {get; set;}
        public int startIndex { get; set; }
        public int itemsPerPage { get; set; }

    }
}