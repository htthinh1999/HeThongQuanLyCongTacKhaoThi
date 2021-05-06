using HeThongQuanLyCongTacKhaoThi.Data.EF;
using HeThongQuanLyCongTacKhaoThi.Data.Entities;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Notifications;
using HeThongQuanLyCongTacKhaoThi.ViewModels.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace HeThongQuanLyCongTacKhaoThi.Application.Catalog.Notifications
{
    public class NotificationService : INotificationService
    {
        private readonly HeThongQuanLyCongTacKhaoThiDbContext _context;

        public NotificationService(HeThongQuanLyCongTacKhaoThiDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<NotificationViewModel>> GetByID(int id)
        {
            var notification = await _context.Notifications.FindAsync(id);
            if (notification == null)
            {
                return new ApiErrorResult<NotificationViewModel>("Thông báo không tồn tại");
            }

            var notificationViewModel = new NotificationViewModel()
            {
                ID = id,
                SubjectID = notification.SubjectID,
                AccountID = notification.AccountID,
                DateTime = notification.DateTime,
                IsRead = notification.IsRead,
                Message = notification.Message,
                StudentAnswerID = notification.StudentAnswerID
            };

            return new ApiSuccessResult<NotificationViewModel>(notificationViewModel);
        }

        public async Task<ApiResult<bool>> Create(NotificationCURequest request)
        {
            var notification = new Notification()
            {
                AccountID = request.AccountID,
                StudentAnswerID = request.StudentAnswerID,
                Message = request.Message,
                SubjectID = request.SubjectID,
                IsRead = request.IsRead
            };

            _context.Notifications.Add(notification);
            var result = await _context.SaveChangesAsync();

            if (result == 0)
            {
                return new ApiErrorResult<bool>("Không thể thêm thông báo!");
            }

            return new ApiSuccessResult<bool>();

        }

        public async Task<ApiResult<bool>> Update(int id, NotificationCURequest request)
        {
            var notification = await _context.Notifications.FindAsync(id);
            if (notification == null) return new ApiErrorResult<bool>("Không thể tìm thấy thông báo!");

            notification.AccountID = request.AccountID;
            notification.StudentAnswerID = request.StudentAnswerID;
            notification.Message = request.Message;
            notification.SubjectID = request.SubjectID;
            notification.IsRead = request.IsRead;


            _context.Entry(notification).State = EntityState.Modified;
            var result = await _context.SaveChangesAsync();
            if (result == 0)
            {
                return new ApiErrorResult<bool>("Không thể cập nhật thông báo!");
            }
            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<List<NotificationViewModel>>> GetTop5LatestNotification(Guid accountID)
        {
            var notifications = await (from n in _context.Notifications
                                       where n.AccountID == accountID
                                       orderby n.DateTime, n.IsRead
                                       select new NotificationViewModel()
                                       {
                                           AccountID = n.AccountID,
                                           StudentAnswerID = n.StudentAnswerID,
                                           Message = n.Message,
                                           DateTime = n.DateTime,
                                           SubjectID = n.SubjectID,
                                           IsRead = n.IsRead
                                       }).Take(5).ToListAsync();

            return new ApiSuccessResult<List<NotificationViewModel>>(notifications);
        }
    }
}
