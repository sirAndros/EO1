using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdObjects.Models
{
    public class ValueOfProperty
    {
        public int ID { get; set; }
        public int BaseID { get; set; }
        public int PropertyID { get; set; }
        public string Property { get; set; }
        public string Value { get; set; }
        public int Level { get; set; }

    }
}