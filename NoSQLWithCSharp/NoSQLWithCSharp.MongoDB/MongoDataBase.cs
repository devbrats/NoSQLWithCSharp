using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using NoSQLWithCSharp.Contracts;

namespace NoSQLWithCSharp.MongoDB
{
    public class MongoDataBase : INoSQLDB
    {
        private IMongoDatabase _db;

        public MongoDataBase(IMongoDatabase mongodb)
        {
            _db = mongodb;
        }

        public Guid Id
        {
            get { return Guid.Empty; }
        }

        public string Name
        {
            get { return _db.DatabaseNamespace.DatabaseName; }
        }

        public void DeleteCollection(string collectionName)
        {
            _db.DropCollection(collectionName);
        }

        public List<string> GetAllCollections()
        {
            return _db.ListCollectionNames().ToList();
        }

        internal IMongoDatabase Database()
        {
            return _db;
        }
    }

}
