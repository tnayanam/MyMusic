using Microsoft.AspNet.Identity;
using MyMusic.Models;
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
            _context.SaveChanges();

            return Ok();
        }


    }
}
