using EntityFrameworkCore.RocksDB.Extensions;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using RocksDbSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCore.RocksDB.Infrastructure.Internal
{
    public class RocksDbOptionsExtension : IDbContextOptionsExtension
    {
        private DbOptions dbOptions;    
        private string path;

        public RocksDbOptionsExtension(RocksDbOptionsExtension other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            path = other.path;
            dbOptions = other.dbOptions;
        }

        public RocksDbOptionsExtension()
        {
            this.dbOptions = new DbOptions();
        }

        private RocksDbOptionsExtension Clone() => new RocksDbOptionsExtension(this);

        public string LogFragment => $"Path={path}";

        public RocksDbOptionsExtension WithPath(string path)
        {
            var clone = Clone();

            clone.path = path ?? throw new ArgumentNullException(nameof(path));

            return clone;
        }

        public RocksDbOptionsExtension WithOptions(DbOptions dbOptions)
        {
            var clone = Clone();

            clone.dbOptions = dbOptions ?? throw new ArgumentNullException(nameof(dbOptions));

            return clone;
        }

        public bool ApplyServices(IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddEntityFrameworkRocksDbDatabase();

            return true;
        }

        public long GetServiceProviderHashCode()
        {
            return 0;
        }

        public void Validate(IDbContextOptions options)
        {
        }
    }
}
