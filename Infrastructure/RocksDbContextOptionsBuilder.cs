using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.RocksDB.Infrastructure
{
    public class RocksDbContextOptionsBuilder
    {
        DbContextOptionsBuilder optionsBuilder;

        public RocksDbContextOptionsBuilder(DbContextOptionsBuilder optionsBuilder)
        {
            this.optionsBuilder = optionsBuilder;
        }
    }
}