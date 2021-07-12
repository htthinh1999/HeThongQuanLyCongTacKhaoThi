using HeThongQuanLyCongTacKhaoThi.ApiIntegration;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.AdminApp.Controllers.Components
{
    public class NotificationViewComponent : ViewComponent
    {
        private readonly INotificationApiClient _notificationApiClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public NotificationViewComponent(INotificationApiClient notificationApiClient, IHttpContextAccessor httpContextAccessor)
        {
            _notificationApiClient = notificationApiClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string accountID = (User.Identity as ClaimsIdentity).FindFirst(ClaimTypes.NameIdentifier).Value;
            var getNotifications = await _notificationApiClient.GetLatestNotifications(new Guid(accountID));

            if(getNotifications == null)
            {
                return await Task.FromResult((IViewComponentResult)View("Default", new List<NotificationViewModel>()));
            }

            var notifications = getNotifications.ResultObj;
            return await Task.FromResult((IViewComponentResult)View("Default", notifications));
        }
    }
}
