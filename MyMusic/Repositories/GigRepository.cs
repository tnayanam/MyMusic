using MyMusic.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MyMusic.Repositories
{
    public class GigRepository
    {
        private ApplicationDbContext _context;

        public GigRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Gig> GetGigsUserAttending(string userId)
        {
            return _context.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Gig)
                .Include(g => g.Artist)
                .Include(g => g.Genre)
                .ToList();
        }

    }
}