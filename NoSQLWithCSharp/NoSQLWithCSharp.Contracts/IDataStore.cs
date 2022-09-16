namespace NoSQLWithCSharp.Contracts
{
    public interface IDataStore<T>
    {
        void AddItem(T user);

        Task<List<T>> GetAllItems();

        void DeleteItem(string id);

        T GetItem(string id);

        void Update(T updatedItem);
    }
}
