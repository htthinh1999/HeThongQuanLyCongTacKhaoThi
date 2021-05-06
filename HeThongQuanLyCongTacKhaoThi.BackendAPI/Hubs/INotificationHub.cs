using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HeThongQuanLyCongTacKhaoThi.BackendAPI.Hubs
{
    public interface INotificationHub
    {
        // Methods for message from server to client
        Task SendToTeacher(string message, int studentAnswerID);
    }
}
