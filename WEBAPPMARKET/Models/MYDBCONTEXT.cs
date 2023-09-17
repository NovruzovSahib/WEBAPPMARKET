using Microsoft.EntityFrameworkCore;

namespace WEBAPPMARKET.Models
{
    public class MYDBCONTEXT:DbContext
    {
        public MYDBCONTEXT(DbContextOptions<MYDBCONTEXT> options)
              : base(options)
        { }
       public DbSet<PRODUCTS> Products { get; set; }
    }
}
