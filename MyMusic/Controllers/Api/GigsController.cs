using Microsoft.AspNet.Identity;
using MyMusic.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace MyMusic.Controllers.Api
{

    [Authorize]
    public class GigsController : ApiController
    {
        private ApplicationDbContext _context;

        public GigsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userId = User.Identity.GetUserId();
            var gig = _context.Gigs.Single(g => g.Id == id && g.ArtistId == userId);
            if (gig.isCanceled)
                return NotFound();

            gig.isCanceled = true;

            var notification = new Notification
            {
                DateTime = DateTime.Now,
                Gig = gig,
                Type = NotificationType.GigCanceled
            };

            var attendees = _context.Attendances
                .Where(a => a.GigId == gig.Id)
                .Select(a => a.Attendee)
                .ToList();

            foreach (var attendee in attendees)
                attendee.Notify(notification);

            _context.SaveChanges();

            return Ok();
        }

    }
}
