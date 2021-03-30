using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HydroPi.Settings
{
    public class MongoDbCollections : IMongoDbCollections
    {
        public string Sensors { get; set; }
        public string SensorGroups { get; set; }
        public string Outputs { get; set; }
        public string OutputGroups { get; set; }
        public string DataPoints { get; set; }
        public string Settings { get; set; }
        public string Users { get; set; }
        public string Tasks { get; set; }
        public string Functions { get; set; }
    }

    public interface IMongoDbCollections
    {
        string Sensors { get; set; }
        string SensorGroups { get; set; }
        string Outputs { get; set; }
        string OutputGroups { get; set; }
        string DataPoints { get; set; }
        string Settings { get; set; }
        string Users { get; set; }
        string Tasks { get; set; }
        string Functions { get; set; }

    }
}
