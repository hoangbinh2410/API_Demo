using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API.EF
{
    public class DBconnect : IDesignTimeDbContextFactory<NVcontext>
    {
        public NVcontext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("UserDatabase");
            var optionsBuilder = new DbContextOptionsBuilder<NVcontext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new NVcontext(optionsBuilder.Options);
        }
    }
}
