using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.Data.Entities
{
    public class RoleAccount : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
}
