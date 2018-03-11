using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Query;

namespace EntityFrameworkCore.RocksDB.Query
{
    public class RocksDbQueryContextFactory : QueryContextFactory
    {
        protected RocksDbQueryContextFactory(QueryContextDependencies dependencies) : base(dependencies)
        {
        }

        public override QueryContext Create()
        {
            throw new System.NotImplementedException();
        }
    }
}