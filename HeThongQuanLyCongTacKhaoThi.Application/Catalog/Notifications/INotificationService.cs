using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.Application.Catalog.Notifications
{
    public interface INotificationService
    {
        Task<ApiResult<bool>> Create(NotificationCURequest request);

        Task<ApiResult<bool>> Update(int id, NotificationCURequest request);

        Task<ApiResult<NotificationViewModel>> GetByID(int id);

        Task<ApiResult<List<NotificationViewModel>>> GetTop5LatestNotification(Guid accountID);
    }
}
