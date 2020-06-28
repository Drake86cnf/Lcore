using Microsoft.EntityFrameworkCore;


namespace Lcore.Data
{
    public class LCoreContextbkup : DbContext
    {
        public LCoreContextbkup (DbContextOptions<LCoreContext> options)
            : base(options)
        {
        }

       
    }
}