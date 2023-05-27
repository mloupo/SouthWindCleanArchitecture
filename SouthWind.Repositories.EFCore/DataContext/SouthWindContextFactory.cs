using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouthWind.Repositories.EFCore.DataContext
{
    class SouthWindContextFactory : IDesignTimeDbContextFactory<SouthWindContext>
    {
        public SouthWindContext CreateDbContext(string[] args)
        {
            var OptionBuilder = new DbContextOptionsBuilder<SouthWindContext>();
            OptionBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;database=SouthWindDB");
            return new SouthWindContext(OptionBuilder.Options);
        }
    }
}
