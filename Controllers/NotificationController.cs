using System.Net.Http;
using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using feed.Infrastructure;
using Microsoft.EntityFrameworkCore;
using feed.Models;
using feed.Filters;
using feed.Services;
using Microsoft.AspNetCore.Http;
using feed.Infrastructure.Repositories;

namespace feed.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetNotificationsByUserIdByPage([FromQuery] int userId, [FromQuery] PageParameters pageParameters)
        {
            return Ok(await _notificationService.GetNotificationsByUserIdByPage(userId, pageParameters));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllNotificationsByPage([FromQuery] PageParameters pageParameters)
        {
            return Ok(await _notificationService.GetAllNotificationsByPage(pageParameters));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserTotalUnseenNotificationCount(int userId)
        {
            return Ok(await _notificationService.GetUserTotalUnseenNotificationCount(userId));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> MarkNotificationAsSeen(int notificationId)
        {
            return Ok(await _notificationService.MarkNotificationAsSeen(notificationId));
        }
    }
}
