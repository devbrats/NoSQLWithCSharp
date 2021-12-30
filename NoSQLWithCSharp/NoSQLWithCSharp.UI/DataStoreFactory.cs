using NoSQLWithCSharp.Common;
using NoSQLWithCSharp.Common.Entity;
using NoSQLWithCSharp.MongoDB;

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
