using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LABA_2._1
{
    public class AppContext : DbContext
    {
        public DbSet<Note> Notes { set; get; }
        public AppContext() : base("DefaultConnection") { }
    }
}
