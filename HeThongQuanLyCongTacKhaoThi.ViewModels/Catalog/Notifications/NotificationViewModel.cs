﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.Catalog.Notifications
{
    public class NotificationViewModel
    {
        public int ID { get; set; }
        public Guid AccountID { get; set; }
        public Guid StudentAnswerID { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsRead { get; set; }
        public string SubjectID { get; set; }
    }
}
