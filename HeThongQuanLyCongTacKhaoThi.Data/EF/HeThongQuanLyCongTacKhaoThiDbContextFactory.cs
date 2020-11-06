using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HeThongQuanLyCongTacKhaoThi.Data.EF
{
    public class HeThongQuanLyCongTacKhaoThiDbContextFactory : IDesignTimeDbContextFactory<HeThongQuanLyCongTacKhaoThiDbContext>
    {
        public HeThongQuanLyCongTacKhaoThiDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            string connectionString = configuration.GetConnectionString("HeThongQuanLyCongTacKhaoThiDatabase");

            var optionsBuilder = new DbContextOptionsBuilder<HeThongQuanLyCongTacKhaoThiDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new HeThongQuanLyCongTacKhaoThiDbContext(optionsBuilder.Options);
        }
    }
}
