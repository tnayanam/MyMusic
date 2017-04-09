﻿using AutoMapper;
using Microsoft.AspNet.Identity;
using MyMusic.Dtos;
using MyMusic.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace MyMusic.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private ApplicationDbContext _context;

        public NotificationsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult MarkAsRead()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _context.UserNotifications
                .Where(un => un.UserId == userId && !un.IsRead)
                .ToList();

            notifications.ForEach(n => n.Read());

            _context.SaveChanges();

            return Ok();
        }

        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _context.UserNotifications
                  .Where(un => un.UserId == userId && !un.IsRead)
                  .Select(un => un.Notification)
                  .Include(n => n.Gig.Artist)
                  .ToList();

            return notifications.Select(Mapper.Map<Notification, NotificationDto>);
        }

    }
}
