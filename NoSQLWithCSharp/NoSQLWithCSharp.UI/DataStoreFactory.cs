using NoSQLWithCSharp.Data;
using NoSQLWithCSharp.MongoDB;
using NoSQLWithCSharp.MongoDB.Model;
using NoSQLWithCSharp.UI;

namespace NoSqlWithCSharp.UI
{
    public class DataStoreFactory
    {
        public static INoSQLClient GetNoSQLClient()
        {
            return new MongoDBClient(Configuration.ConnectionString);
        }

        public static IDataStore<User> GetUserDataStore(INoSQLDB db)
        {
            return new MongoDataStore<User>(db, Configuration.CollectionName);
        }
    }
}
