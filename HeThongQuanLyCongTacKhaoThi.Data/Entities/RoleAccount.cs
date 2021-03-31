using Microsoft.AspNetCore.Identity;
using System;

namespace HeThongQuanLyCongTacKhaoThi.Data.Entities
{
    public class RoleAccount : IdentityRole<Guid>
    {
        public string Description { get; set; }
    }
}