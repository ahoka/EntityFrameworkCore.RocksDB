using EntityFrameworkCore.RocksDB.Infrastructure.Internal;
using EntityFrameworkCore.RocksDB.Query;
using EntityFrameworkCore.RocksDB.Query.ExpressionVisitors.Internal;
using EntityFrameworkCore.RocksDB.Query.Internal;
using EntityFrameworkCore.RocksDB.Storage;
using EntityFrameworkCore.RocksDB.Storage.Internal;
using EntityFrameworkCore.RocksDB.ValueGeneration.Internal;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Microsoft.Extensions.DependencyInjection;
using Remotion.Linq.Parsing.ExpressionVisitors.TreeEvaluation;
using System;

namespace EntityFrameworkCore.RocksDB.Extensions
{
    public static class RocksDbServiceCollectionExtensions
    {
        public static IServiceCollection AddEntityFrameworkRocksDbDatabase(this IServiceCollection serviceCollection)
        {
            if (serviceCollection == null)
            {
                throw new System.ArgumentNullException(nameof(serviceCollection));
            }

            var builder = new EntityFrameworkServicesBuilder(serviceCollection)
                .TryAdd<IDatabaseProvider, DatabaseProvider<RocksDbOptionsExtension>>()
                .TryAdd<IValueGeneratorSelector, RocksDbValueGeneratorSelector>()
                .TryAdd<IDatabase>(p => p.GetService<IRocksDbDatabase>())
                .TryAdd<IDbContextTransactionManager, RocksDbTransactionManager>()
                .TryAdd<IDatabaseCreator, RocksDbDatabaseCreator>()
                .TryAdd<IQueryContextFactory, RocksDbQueryContextFactory>()
                .TryAdd<IEntityQueryModelVisitorFactory, RocksDbQueryModelVisitorFactory>()
                .TryAdd<IEntityQueryableExpressionVisitorFactory, RocksDbEntityQueryableExpressionVisitorFactory>()
                .TryAdd<IEvaluatableExpressionFilter, EvaluatableExpressionFilter>()
                //.TryAdd<ISingletonOptions, IRocksDbSingletonOptions>(p => p.GetService<IRocksDbSingletonOptions>())
                .TryAddProviderSpecificServices(
                    b => b
                        .TryAddScoped<IRocksDbDatabase, RocksDbDatabase>());
                /*.TryAddProviderSpecificServices(
                    b => b
                        .TryAddSingleton<IRocksDbSingletonOptions, RocksDbSingletonOptions>()
                        .TryAddSingleton<IRocksDbStoreCache, RocksDbStoreCache>()
                        .TryAddSingleton<IRocksDbTableFactory, RocksDbTableFactory>()
                        .TryAddScoped<IRocksDbDatabase, RocksDbDatabase>()
                        .TryAddScoped<IRocksDbMaterializerFactory, RocksDbMaterializerFactory>())*/;

            builder.TryAddCoreServices();

            return serviceCollection;
        }
    }
}