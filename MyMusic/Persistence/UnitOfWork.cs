using MyMusic.Models;
using MyMusic.Repositories;

namespace MyMusic.Persistence
{
    public class UnitOfWork
    {
        private ApplicationDbContext _context;
        public GigRepository Gigs { get; private set; }
        public GenreRepository Genres { get; private set; }
        public FollowingRepository Followings { get; private set; }
        public AttendanceRepository Attendances { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Gigs = new GigRepository(context);
            Genres = new GenreRepository(context);
            Followings = new FollowingRepository(context);
            Attendances = new AttendanceRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}