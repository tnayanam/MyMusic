﻿using Microsoft.AspNet.Identity;
using MyMusic.Dtos;
using MyMusic.Models;
using System.Linq;
using System.Web.Http;

namespace MyMusic.Controllers
{
    [Authorize]
    public class FollowingsController : ApiController
    {

        private ApplicationDbContext _context;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();
            if (_context.Followings.Any(f => f.FolloweeId == dto.FolloweeId && f.FollowerId == userId))
                return BadRequest("Following already exists");

            var following = new Following
            {
                FolloweeId = dto.FolloweeId,
                FollowerId = userId
            };

            _context.Followings.Add(following);
            _context.SaveChanges();

            return Ok();
        }
    }
}
