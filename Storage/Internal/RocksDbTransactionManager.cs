using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace EntityFrameworkCore.RocksDB.Storage.Internal
{
    public class RocksDbTransactionManager : IDbContextTransactionManager
    {
        public IDbContextTransaction CurrentTransaction => throw new System.NotImplementedException();

        public IDbContextTransaction BeginTransaction()
        {
            throw new System.NotImplementedException();
        }

        public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new System.NotImplementedException();
        }

        public void CommitTransaction()
        {
            throw new System.NotImplementedException();
        }

        public void ResetState()
        {
            throw new System.NotImplementedException();
        }

        public void RollbackTransaction()
        {
            throw new System.NotImplementedException();
        }
    }
}