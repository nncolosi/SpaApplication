using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaFrontEndApp.Models
{
    public class Results
    {
        public int total { get; set; }
        public List<Joke> result { get; set; }
    }
}
