﻿using System;
using System.Collections.Generic;

namespace HeThongQuanLyCongTacKhaoThi.ViewModels.System.Accounts
{
    public class RoleAssignRequest
    {
        public Guid Id { get; set; }
        public List<SelectItem> Roles { get; set; } = new List<SelectItem>();
    }
}