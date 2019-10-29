using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace I4DAB_LAB2
{


    public class AppDbContext : DbContext
    {    //private DbSet<Door> doors { get; set; }

        string MikkelsCString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=I4DAB_LAB2;Data Source=DESKTOP-9NFPK3F";
        string MortensCString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=I4DAB_LAB2;Data Source=DESKTOP-CKBOQBP";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(MortensCString);
        }
    }
}
