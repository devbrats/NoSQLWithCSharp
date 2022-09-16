namespace NoSQLWithCSharp.Contracts
{
    public interface INoSQLClient
    {
        INoSQLDB CreateDB(string dbName);
        List<string> GetAllDBs();
        void DeleteDB(string dbName);
    }
}
