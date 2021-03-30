﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HydroPi.Models.Settings

{
    public class HydroPiDatabaseSettings : IHydroPiDatabaseSettings
    {
        public string MongoDb { get; set; }
        public string ConnectionString { get; set; }
        public string SensorCollectionName { get; set; }
        public string DatabaseName { get; set; }
        public string Username { get; set; }
        public string Secret { get; set; }

    }

    public interface IHydroPiDatabaseSettings
    {
        string MongoDb { get; set; }
        string ConnectionString { get; set; }
        string SensorCollectionName { get; set; }
        string DatabaseName { get; set; }
        string Username { get; set; }
        string Secret { get; set; }
    }
}