using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using NoSQLWithCSharp.Common;

namespace NoSQLWithCSharp.MongoDB
{
    public class MongoDataStore<T> : IDataStore<T>
    {
        private IMongoCollection<T> _collection;

        public MongoDataStore(INoSQLDB db, string collectionName)
        {
            // if collection does not exists then create it.
            _collection = (db as MongoDataBase).Database().GetCollection<T>(collectionName);
        }

        public void AddItem(T user)
        {
            _collection.InsertOne(user);
        }

        public Task<List<T>> GetAllItems()
        {
            var result = _collection.Find(_ => true).ToListAsync();
            return result;
        }

        public void DeleteItem(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            _collection.DeleteOne(filter);
        }

        public T GetItem(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            return _collection.FindSync(filter).FirstOrDefault();
        }
    }
  
}
