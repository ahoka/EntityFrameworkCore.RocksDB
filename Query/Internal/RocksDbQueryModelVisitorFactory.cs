using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Query;

namespace EntityFrameworkCore.RocksDB.Query.Internal
{
    public class RocksDbQueryModelVisitorFactory : EntityQueryModelVisitorFactory
    {
        protected RocksDbQueryModelVisitorFactory(EntityQueryModelVisitorDependencies dependencies) : base(dependencies)
        {
        }

        public override EntityQueryModelVisitor Create(QueryCompilationContext queryCompilationContext, EntityQueryModelVisitor parentEntityQueryModelVisitor)
        {
            throw new System.NotImplementedException();
        }
    }
}