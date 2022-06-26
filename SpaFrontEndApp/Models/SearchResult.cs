using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaFrontEndApp.Models
{
    public class SearchResult
    {
        public Results jokes { get; set; }
        public PeopleResult people { get; set; }
    }
}
