using System;
using System.Collections.Generic;

namespace NoSQLWithCSharp.Common
{
    public interface INoSQLDB
    {
        Guid Id { get; }
        string Name { get; }
        List<string> GetAllCollections();
        void DeleteCollection(string collectionName);
    }
}
