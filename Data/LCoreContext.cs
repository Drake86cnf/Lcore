using Microsoft.EntityFrameworkCore;


namespace Lcore.Data
{
    public class LCoreContext : DbContext
    {
        public LCoreContext (DbContextOptions<LCoreContext> options)
            : base(options)
        {
        }

       
    }
}