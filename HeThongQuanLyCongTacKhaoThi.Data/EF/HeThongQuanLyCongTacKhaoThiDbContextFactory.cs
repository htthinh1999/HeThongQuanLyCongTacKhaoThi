using HeThongQuanLyCongTacKhaoThi.Utilities.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

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
            string connectionString = configuration.GetConnectionString(SystemConstants.MAIN_CONNECTION_STRING);

            var optionsBuilder = new DbContextOptionsBuilder<HeThongQuanLyCongTacKhaoThiDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new HeThongQuanLyCongTacKhaoThiDbContext(optionsBuilder.Options);
        }
    }
}