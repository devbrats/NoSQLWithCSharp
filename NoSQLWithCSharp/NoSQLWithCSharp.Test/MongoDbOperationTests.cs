using NoSQLWithCSharp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NoSQLWithCSharp.MongoDB.Model;
using NoSQLWithCSharp.MongoDB;

namespace NoSQLWithCSharp.Test
{

    [TestClass]
    public class MongoDbOperationTests
    {
        private IDataStore<User> _userDataStore;
        private INoSQLDB _db;
        private INoSQLClient _client;

        [TestInitialize]
        public void Init()
        {
            _client = new MongoDBClient(TestConfiguration.ConnectionString);
            _db = _client.CreateDB(TestConfiguration.DBName);
            _userDataStore = new MongoDataStore<User>(_db, TestConfiguration.CollectionName);
            SeedUsersData();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _db.DeleteCollection(TestConfiguration.CollectionName);
            _client.DeleteDB(TestConfiguration.DBName);
            _client = null;
        }

        [TestMethod]
        public void TestDbCreation()
        {
            var db =_client.GetAllDBs().FirstOrDefault(x=>x.Equals(TestConfiguration.DBName));
            Assert.IsNotNull(db);
            Assert.AreEqual(TestConfiguration.DBName, db);
        }

        [TestMethod]
        public void TestDbDeletion()
        {
            var db = _client.GetAllDBs().FirstOrDefault(x => x.Equals(TestConfiguration.DBName));
            Assert.IsNotNull(db);
            Assert.AreEqual(TestConfiguration.DBName, db);

            _client.DeleteDB(TestConfiguration.DBName);

            db = _client.GetAllDBs().FirstOrDefault(x => x.Equals(TestConfiguration.DBName));
            Assert.IsNull(db);
        }


        [TestMethod]
        public void TestAddingNewUser()
        {
            var newUser = new User()
            {
                Name = "Jon",
                Age = 28,
                Team = Team.Innovation.ToString(),
            };

            _userDataStore.AddItem(newUser);

            var user = FetchAllUsers().FirstOrDefault(x => x.Name.Equals(newUser.Name));

            Assert.IsTrue(!string.IsNullOrEmpty(user.ID));
            Assert.AreEqual(newUser.Name, user.Name);
            Assert.AreEqual(newUser.Age, user.Age);
            Assert.AreEqual(newUser.Team, user.Team);
        }

        [TestMethod]
        public void TestDeleteUser()
        {
            // we will try deleting first user.
            var user = FetchAllUsers().FirstOrDefault();

            Assert.IsTrue(!string.IsNullOrEmpty(user.ID));

            _userDataStore.DeleteItem(user.ID);

            Assert.IsNull(_userDataStore.GetItem(user.ID));

        }

        private List<User> FetchAllUsers()
        {
            var users = _userDataStore.GetAllItems().Result;
            return users;
        }

        private void SeedUsersData()
        {
            var ageGenerator = new Random();
            var users = new List<string> { "Anil", "Aditya", "Subham", "Harsh", "Shilpi", "Gayathri", "Devbrat", "Ashish" };

            int index = 0;
            foreach (var user in users)
            {
                _userDataStore.AddItem(new User()
                {
                    Name = user,
                    Age = ageGenerator.Next(25, 40),
                    Team = ((Team)(index % 3)).ToString()
                });
                index++;
            }

        }
    }
}