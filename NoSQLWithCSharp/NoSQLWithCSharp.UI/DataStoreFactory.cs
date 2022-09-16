using NoSQLWithCSharp.Contracts;
using NoSQLWithCSharp.MongoDB;
using NoSQLWithCSharp.UI;
using NoSQLWithCSharp.UI.Model;

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
