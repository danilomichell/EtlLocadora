using Microsoft.EntityFrameworkCore;

namespace EtlLocadora.Data.Context
{
    public class LocadoraContext : DbContext
    {
        public LocadoraContext(DbContextOptions<LocadoraContext> options)
            : base(options)
        {
        }

    }
}