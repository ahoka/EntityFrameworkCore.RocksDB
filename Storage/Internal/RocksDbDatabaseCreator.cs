using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace EntityFrameworkCore.RocksDB.Storage.Internal
{
    public class RocksDbDatabaseCreator : IDatabaseCreator
    {
        public bool EnsureCreated()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> EnsureCreatedAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new System.NotImplementedException();
        }

        public bool EnsureDeleted()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> EnsureDeletedAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new System.NotImplementedException();
        }
    }
}