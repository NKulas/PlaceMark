using System;
using System.Collections.Generic;

namespace PlaceMark
{
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime CreatedDate { get; set; }

        public bool NameIsValidate()
        {
            if (string.IsNullOrEmpty(Name)) return false;
            else return true;
        }
    }
}