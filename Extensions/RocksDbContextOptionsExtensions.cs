using EntityFrameworkCore.RocksDB.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using RocksDbSharp;

namespace EntityFrameworkCore.RocksDB.Extensions
{
    public static class RocksDbContextOptionsExtensions
    {
        public static DbContextOptionsBuilder UseRocksDb(this DbContextOptionsBuilder optionsBuilder, string path, DbOptions dbOptions)
        {
            var extension = optionsBuilder.Options.FindExtension<RocksDbOptionsExtension>() ?? new RocksDbOptionsExtension();

            extension = extension.WithPath(path).WithOptions(dbOptions);

            ((IDbContextOptionsBuilderInfrastructure)optionsBuilder).AddOrUpdateExtension(extension);
        
            return optionsBuilder;
        }

        public static DbContextOptionsBuilder<TContext> UseRocksDb<TContext>(this DbContextOptionsBuilder<TContext> optionsBuilder, string path, DbOptions dbOptions)
            where TContext : DbContext
        {
            return UseRocksDb(optionsBuilder, path, dbOptions);
        }

        public static DbContextOptionsBuilder UseRocksDb(this DbContextOptionsBuilder optionsBuilder, string path)
        {
            return optionsBuilder.UseRocksDb(path, new DbOptions());
        }

        public static DbContextOptionsBuilder<TContext> UseRocksDb<TContext>(this DbContextOptionsBuilder<TContext> optionsBuilder, string path)
            where TContext : DbContext
        {
            return optionsBuilder.UseRocksDb(path, new DbOptions());
        }
    }
}