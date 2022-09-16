using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using NoSQLWithCSharp.Contracts;

namespace NoSQLWithCSharp.MongoDB
{
    public class MongoDBClient : INoSQLClient
    {
        private IMongoClient _mongoClient;
        private string _connectionString;

        public MongoDBClient(string connectionString)
        {
            _connectionString = connectionString;
            _mongoClient = new MongoClient(_connectionString);
        }

        public List<string> GetAllDBs()
        {
            return _mongoClient.ListDatabaseNames().ToList();
        }

        public INoSQLDB CreateDB(string dbName)
        {
            var db = _mongoClient.GetDatabase(dbName);
            return new MongoDataBase(db);
        }

        public async void DeleteDB(string dbName)
        {
            await _mongoClient.DropDatabaseAsync(dbName);
        }

        internal Dictionary<string, INoSQLDB> DBs
        {
            get
            {
                var dbs = new Dictionary<string, INoSQLDB>();
                var dbList = GetAllDBs();
                foreach (var dbName in dbList)
                {
                    dbs.Add(dbName, new MongoDataBase(_mongoClient.GetDatabase(dbName)));
                }
                return dbs;
            }
        }

    }

}
