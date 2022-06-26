using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaFrontEndApp.Models
{
    public class PeopleResult
    {
        public int count { get; set; }
        public object next { get; set; }
        public object previous { get; set; }
        public List<Person> results { get; set; }
    }
}
