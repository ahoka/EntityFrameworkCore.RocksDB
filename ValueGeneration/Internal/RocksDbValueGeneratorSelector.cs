using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace EntityFrameworkCore.RocksDB.ValueGeneration.Internal
{
    public class RocksDbValueGeneratorSelector : ValueGeneratorSelector
    {
        public RocksDbValueGeneratorSelector(ValueGeneratorSelectorDependencies dependencies)
            : base(dependencies)
        {
        }
    }
}