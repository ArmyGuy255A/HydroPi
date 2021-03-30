using HydroPi.Models;
using HydroPi.Models.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HydroPi.Services
{
    public class SensorService
    {
        private readonly IMongoCollection<Sensor> _sensors;
        //private readonly HydroPiDatabaseSettings _databaseConfig;
        public SensorService(IOptionsMonitor<HydroPiDatabaseSettings> databaseSettings)
        {
            var client = new MongoClient(databaseSettings.CurrentValue.MongoDb);
            var database = client.GetDatabase(databaseSettings.CurrentValue.DatabaseName);
            
            _sensors = database.GetCollection<Sensor>(databaseSettings.CurrentValue.SensorCollectionName);
        }

        public List<Sensor> Get() =>
            _sensors.Find(sensor => true).ToList();

        public Sensor Get(string id) =>
            _sensors.Find<Sensor>(sensor => sensor.Id == id).FirstOrDefault();

        public Sensor Create(Sensor sensor)
        {
            _sensors.InsertOne(sensor);
            return sensor;
        }

        public void Update(string id, Sensor sensorIn) =>
            _sensors.ReplaceOne(sensor => sensor.Id == id, sensorIn);

        public void Remove(Sensor sensorIn) =>
            _sensors.DeleteOne(sensor => sensor.Id == sensorIn.Id);

        public void Remove(string id) =>
            _sensors.DeleteOne(sensor => sensor.Id == id);
    }
}
