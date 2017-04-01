using Microsoft.AspNet.Identity;
using MyMusic.Models;
using MyMusic.ViewModels;
using System;
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
        public ActionResult Create(GigFormViewModel viewModel)
        {
            var artistId = User.Identity.GetUserId();
            var gig = new Gig
            {
                ArtistId = artistId,
                Venue = viewModel.Venue,
                DateTime = viewModel.DateTime,
                GenreId = viewModel.Genre
            };
            _context.Gigs.Add(gig);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}