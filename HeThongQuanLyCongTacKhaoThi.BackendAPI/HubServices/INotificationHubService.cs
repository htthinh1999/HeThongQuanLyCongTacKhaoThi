using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.BackendAPI.HubServices
{
    public interface INotificationHubService
    {
        public Task StudentSubmited(int contestID, int studentAnswerID);
    }
}
