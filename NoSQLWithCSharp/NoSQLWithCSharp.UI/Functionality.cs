using System;

namespace NoSqlWithCSharp.UI
{
    public class AppFunctionality
    {
        public AppFunctionality(string name, Action function)
        {
            Name = name;
            Function = function;
        }

        public string Name { get; }
        public Action Function { get; }
    }
}
