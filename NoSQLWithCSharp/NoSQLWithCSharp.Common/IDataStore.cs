using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoSQLWithCSharp.Common
{
    public interface IDataStore<T>
    {
        void AddItem(T user);

        Task<List<T>> GetAllItems();

        void DeleteItem(string id);

        T GetItem(string id);
    }
}
