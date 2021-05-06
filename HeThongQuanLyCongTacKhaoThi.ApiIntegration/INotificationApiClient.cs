using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Notifications;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.ApiIntegration
{
    public interface INotificationApiClient
    {
        Task<ApiResult<List<NotificationViewModel>>> GetLatestNotifications(Guid accountID);

        Task<ApiResult<NotificationViewModel>> GetByID(string id);
     
        Task<ApiResult<bool>> Create(NotificationCURequest request);

        Task<ApiResult<bool>> Update(string id, NotificationCURequest request);
    }
}
