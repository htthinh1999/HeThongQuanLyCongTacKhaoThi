using HeThongQuanLyCongTacKhaoThi.Application.Catalog.Notifications;
using HeThongQuanLyCongTacKhaoThi.Utilities.Constants;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.BackendAPI.Controllers
{
    [Authorize(Policy = Policy.All)]
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet("get-latest-notifications/{accountID}")]
        public async Task<IActionResult> GetLatestNotifications(Guid accountID)
        {
            var result = await _notificationService.GetTop5LatestNotification(accountID);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var result = await _notificationService.GetByID(id);
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] NotificationCURequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _notificationService.Create(request);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] NotificationCURequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _notificationService.Update(id, request);

            return Ok(result);
        }
    }
}
