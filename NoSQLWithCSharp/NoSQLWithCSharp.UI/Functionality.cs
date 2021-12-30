using System;

namespace NoSqlWithCSharp.UI
{
    public class Functionality
    {
        public Functionality(string name, Action function)
        {
            Name = name;
            Function = function;
        }

        public string Name { get; }
        public Action Function { get; }
    }
}
