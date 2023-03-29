namespace NoSQLWithCSharp.Data
{
    public interface INoSQLDB
    {
        Guid Id { get; }
        string Name { get; }
        List<string> GetAllCollections();
        void DeleteCollection(string collectionName);
    }
}
