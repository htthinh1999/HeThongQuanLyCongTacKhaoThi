using HeThongQuanLyCongTacKhaoThi.Application.Catalog.Notifications;
using HeThongQuanLyCongTacKhaoThi.Application.Catalog.TeacherContests;
using HeThongQuanLyCongTacKhaoThi.BackendAPI.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.BackendAPI.HubServices
{
    public class NotificationHubService : INotificationHubService
    {
        private readonly IHubContext<NotificationHub> _notificationHub;
        private readonly ITeacherContestService _teacherContestService;
        private readonly INotificationService _notificationService;

        public NotificationHubService(
            IHubContext<NotificationHub> notificationHub,
            ITeacherContestService teacherContestService,
            INotificationService notificationService)
        {
            _notificationHub = notificationHub;
            _teacherContestService = teacherContestService;
            _notificationService = notificationService;
        }

        public async Task StudentSubmited(int contestID, Guid studentAnswerID)
        {
            var getTeacherIDs = await _teacherContestService.GetAllTeacherIDsInContest(contestID);
            var teacherIDs = getTeacherIDs.ResultObj;

            foreach(var teacherID in teacherIDs)
            {
                await _notificationService.Create(new ViewModels.Catalog.Notifications.NotificationCURequest()
                {
                    AccountID = new Guid(teacherID),
                    DateTime = DateTime.Now,
                    IsRead = false,
                    Message = $"Đã có học viên nộp bài với mã phách \"{studentAnswerID}\"",
                    StudentAnswerID = studentAnswerID
                });
            }

            await _notificationHub.Clients.Users(teacherIDs).SendAsync(nameof(INotificationHub.SendToTeacher), Guid.NewGuid().ToString().ToUpper(), studentAnswerID);
        }
    }
}
