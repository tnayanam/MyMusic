using Microsoft.AspNet.Identity;
using MyMusic.Models;
using MyMusic.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace MyMusic.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GigsController()
        {
            _context = new ApplicationDbContext();
        }
        // Create
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = _context.Genres.ToList()
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = _context.Genres.ToList();
                return View("Create", viewModel);
            }
            var artistId = User.Identity.GetUserId();
            var gig = new Gig
            {
                ArtistId = artistId,
                Venue = viewModel.Venue,
                DateTime = viewModel.GetDateTime(),
                GenreId = viewModel.Genre
            };
            _context.Gigs.Add(gig);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();
            var gigs = _context.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Gig)
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .ToList();

            var viewModel = new GigsViewModel
            {
                ShowActions = User.Identity.IsAuthenticated,
                UpcomingGigs = gigs
            };

            return View(viewModel);
        }
    }
}

//How antiforgery works//
// when we put antiforgery a roken is added as HiddenInputAttribute field in form
// that we are going to submit and also in cookie its encrypted 
// version is set. Now when form is submitted. bothe
//the encrypted and the hidden field values is sent.
//at server the hiddent value is encrypted to match with already received 
//encruypted value from cookie, if they dont match then its csurf attack