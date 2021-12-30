namespace NoSQLWithCSharp.Common
{
    public class Configuration
    {
        public static string ConnectionString
        {
            get
            {
                return "mongodb://127.0.0.1:27017/ServiceName=mongodb";
            }
        }

        public static string DBName
        {
            get { return "NoSQLDemoDB"; }
        }

        public static string CollectionName
        {
            get { return "Users"; }
        }
    }
}
