using CP2_IgorJoe.Models;
using Microsoft.EntityFrameworkCore;

namespace CP2_IgorJoe.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DbSet<Mouses> Mouses { get; set; }
    }
}
