namespace NoSqlWithCSharp.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var mongApp = new MongoApp();
            mongApp.ShowAppFunctionalities();
            mongApp.SelectFunctionality();
        }
    }
}
