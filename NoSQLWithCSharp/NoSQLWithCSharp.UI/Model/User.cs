using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace NoSQLWithCSharp.UI.Model
{
    public class User
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string ID { get; set; }
        public string Name { get; set; }
        public string Team { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}, Age: {Age}, Team: {Team}";
        }
    }

    public enum Team
    {
        Icecles,
        Mavericks,
        Innovation
    }
}
