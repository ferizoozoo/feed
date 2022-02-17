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
        public async Task<IActionResult> GetNotificationsByUserId(int userId, int? pageNumber, int? pageSize)
        {
            return Ok(await _notificationService.GetNotificationsByUserId(userId, pageNumber, pageSize));
        }
    }
}
