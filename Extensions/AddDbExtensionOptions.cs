using System;
using System.Collections.Generic;
using System.Text;

namespace Extensions
{
    public class AddDbExtensionOptions
    {
        public string PostgresConnectionString { get; set; }
        public bool AutoDatabaseUpdate { get; set; } = true;
        public int ConnectionToServerTimeoutWhenAppStartsInMs { get; set; } = 300000;
        public int ConnectionToServerCheckDelayInMs { get; set; } = 30000;
        public int CommandTimeoutInSec { get; set; } = 60;
        public int? MigrationsCommandTimeoutInSeconds { get; set; }
    }
}
