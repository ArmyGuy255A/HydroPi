using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HydroPi.Settings

{
    public class HydroPiDatabaseSettings : IHydroPiDatabaseSettings
    {
        public string SQLiteConnectionString { get; set; }
        public MongoDbCollections Collections { get; set; }
        public string DatabaseName { get; set; }
        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        private string buildConnectionString(string databaseName)
        {
            return String.Format("mongodb://{0}:{1}@{2}", Username, Password, Host);
        }

        public string ConnectionString
        {
            get
            {
                return buildConnectionString(DatabaseName);
            }
        }

    }

    public interface IHydroPiDatabaseSettings
    {
        string SQLiteConnectionString { get; }
        MongoDbCollections Collections { get; set; }
        string DatabaseName { get; set; }
        string Host { get; set; }
        string Username { get; set; }
        string Password { get; set; }
    }
}
