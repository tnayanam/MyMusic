using System;
using System.ComponentModel.DataAnnotations;

namespace MyMusic.Models
{
    public class Notification
    {
        protected Notification()
        {

        }

        public Notification(Gig gig, NotificationType type)
        {
            if (gig == null)
                throw new ArgumentNullException("gig");

            DateTime = DateTime.Now;
            Gig = gig;
            Type = type;
        }
        public int Id { get; private set; }

        public DateTime DateTime { get; private set; }

        public NotificationType Type { get; private set; }

        public DateTime? OriginalDateTime { get; set; }

        public string OriginalVenue { get; set; }

        [Required]
        public Gig Gig { get; private set; }
    }
}