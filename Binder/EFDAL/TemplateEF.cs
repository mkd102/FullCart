using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDAL
{
   public class TemplateEF : DbContext
    {
        private IConfiguration _connectionstring;
    public TemplateEF(IConfiguration configuration)
    {
        this._connectionstring = configuration;
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(this._connectionstring.GetConnectionString("connDev"));
        }
    }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
}
}
