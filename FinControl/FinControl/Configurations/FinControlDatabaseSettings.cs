using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinControl.Configurations
{
    public class FinControlDatabaseSettings : IFinControlDatabaseSettings
    {
        public string FinControlCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IFinControlDatabaseSettings
    {
        string FinControlCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
