using System.Collections.Generic;

namespace NoSQLWithCSharp.Common
{
    public interface INoSQLClient
    {
        INoSQLDB CreateDB(string dbName);
        List<string> GetAllDBs();
        void DeleteDB(string dbName);
    }
}
