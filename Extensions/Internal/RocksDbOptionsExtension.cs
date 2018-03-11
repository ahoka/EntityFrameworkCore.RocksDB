using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFrameworkCore.RocksDB.Extensions.Internal
{
    public class RocksDbOptionsExtension : IDbContextOptionsExtension
    {
        public string LogFragment => throw new System.NotImplementedException();

        public bool ApplyServices(IServiceCollection services)
        {
            throw new System.NotImplementedException();
        }

        public long GetServiceProviderHashCode()
        {
            throw new System.NotImplementedException();
        }

        public void Validate(IDbContextOptions options)
        {
            throw new System.NotImplementedException();
        }
    }
}