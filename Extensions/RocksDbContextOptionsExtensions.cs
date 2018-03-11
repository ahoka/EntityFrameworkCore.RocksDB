using EntityFrameworkCore.RocksDB.Extensions.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EntityFrameworkCore.RocksDB.Extensions
{
    public static class RocksDbContextOptionsExtensions
    {
        public static DbContextOptionsBuilder UseInMemoryDatabase(this DbContextOptionsBuilder optionsBuilder)
        {
            var extension = optionsBuilder.Options.FindExtension<RocksDbOptionsExtension>();

            ((IDbContextOptionsBuilderInfrastructure)optionsBuilder).AddOrUpdateExtension(extension);
        
            return optionsBuilder;
        }
    }
}