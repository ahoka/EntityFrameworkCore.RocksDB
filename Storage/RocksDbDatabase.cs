using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Update;

namespace EntityFrameworkCore.RocksDB.Storage
{
    public class RocksDbDatabase : Database, IRocksDbDatabase
    {
        public RocksDbDatabase(DatabaseDependencies dependencies)
            : base(dependencies)
        {
        }

        private string MapValue(object obj)
        {
            // TODO: proper mapping
            return obj.ToString();
        }

        private int Add(IUpdateEntry entry)
        {
            var type = entry.EntityType;

            var inserts = new List<(string, string)>();
            var primaryKeyName = "";
            var primaryKeyValue = "";

            foreach (var prop in type.GetProperties())
            {
                if (prop.IsPrimaryKey())
                {
                    primaryKeyName = prop.Name;
                    primaryKeyValue = MapValue(entry.GetCurrentValue(prop));
                }

                inserts.Add((prop.Name, MapValue(entry.GetCurrentValue(prop))));
            }

            return 1;
        }

        public override int SaveChanges(IReadOnlyList<IUpdateEntry> entries)
        {
            int rowsAffected = 0;

            foreach (var entry in entries)
            {
                switch (entry.EntityState)
                {
                    case EntityState.Added:
                        rowsAffected += Add(entry);
                        break;
                    case EntityState.Deleted:
                        break;
                    case EntityState.Modified:
                        break;
                }
            }

            return rowsAffected;
        }

        public override Task<int> SaveChangesAsync(IReadOnlyList<IUpdateEntry> entries, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.FromResult(SaveChanges(entries));
        }
    }
}