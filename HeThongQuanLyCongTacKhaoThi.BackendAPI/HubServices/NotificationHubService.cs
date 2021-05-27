using HeThongQuanLyCongTacKhaoThi.Application.Catalog.TeacherContests;
using HeThongQuanLyCongTacKhaoThi.BackendAPI.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.BackendAPI.HubServices
{
    public class NotificationHubService : INotificationHubService
    {
        private readonly IHubContext<NotificationHub> _notificationHub;
        private readonly ITeacherContestService _teacherContestService;

        public NotificationHubService(IHubContext<NotificationHub> notificationHub, ITeacherContestService teacherContestService)
        {
            _notificationHub = notificationHub;
            _teacherContestService = teacherContestService;
        }

        public async Task StudentSubmited(int contestID, Guid studentAnswerID)
        {
            var getTeacherIDs = await _teacherContestService.GetAllTeacherIDsInContest(contestID);
            var teacherIDs = getTeacherIDs.ResultObj;

            await _notificationHub.Clients.Users(teacherIDs).SendAsync(nameof(INotificationHub.SendToTeacher), Guid.NewGuid().ToString().ToUpper(), studentAnswerID);
        }
    }
}
