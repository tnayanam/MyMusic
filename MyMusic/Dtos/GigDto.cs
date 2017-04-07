using MyMusic.Models;
using System;

namespace MyMusic.Dtos
{
    public class GigDto
    {
        public int Id { get; set; }
        public UserDto Artist { get; set; }
        public DateTime DateTime { get; set; }
        public string Venue { get; set; }
        public Genre Genre { get; set; }
        public bool isCanceled
        {
            get; set;
        }
    }
}