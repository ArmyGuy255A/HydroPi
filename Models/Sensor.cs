using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HydroPi.Models
{
    public class Sensor
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string SensorName { get; set; }
    }
}
