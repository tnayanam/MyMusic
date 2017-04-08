using MyMusic.Models;
using System.Collections.Generic;

namespace MyMusic.ViewModels
{
    public class GigsViewModel
    {
        public bool ShowActions { get; set; }
        public IEnumerable<Gig> UpcomingGigs { get; set; }
        public string Heading { get; set; }
        public string SearchTerm { get; set; }
    }
}