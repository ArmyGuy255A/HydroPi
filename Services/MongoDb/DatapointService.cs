using HydroPi.MongoData.Models;
using HydroPi.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;

namespace HydroPi.Services.MongoDb
{
    public class DataPointService : GenericMongoDbService<Datapoint>
    {
        //private readonly IMongoCollection<Sensor> _sensors;
        //private readonly HydroPiDatabaseSettings _databaseConfig;
        public DataPointService(IOptionsMonitor<HydroPiDatabaseSettings> databaseSettings) : base(databaseSettings, databaseSettings.CurrentValue.Collections.Sensors)
        {
            Console.Write("BREAK");
        }

        //public List<Sensor> Get() =>
        //    _sensors.Find(sensor => true).ToList();

        //public Sensor Get(string id) =>
        //    _sensors.Find<Sensor>(sensor => sensor.Id == id).FirstOrDefault();

        //public Sensor Create(Sensor sensor)
        //{
        //    _sensors.InsertOne(sensor);
        //    return sensor;
        //}

        //public void Update(string id, Sensor sensorIn) =>
        //    _sensors.ReplaceOne(sensor => sensor.Id == id, sensorIn);

        //public void Remove(Sensor sensorIn) =>
        //    _sensors.DeleteOne(sensor => sensor.Id == sensorIn.Id);

        //public void Remove(string id) =>
        //    _sensors.DeleteOne(sensor => sensor.Id == id);
    }
}
