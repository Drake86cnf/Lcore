using Microsoft.EntityFrameworkCore;


namespace LCore.Data
{
    public class LCoreContextbkup : DbContext
    {
        public LCoreContextbkup (DbContextOptions<LCoreContext> options)
            : base(options)
        {
        }

       
    }
}