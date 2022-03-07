using System;
using System.Linq;

namespace LangDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Person() {
                FirstName = "Bill",
                LastName = "Gates"
            };

            Console.WriteLine("Hello World!");
        }
    }

    class Person
    {
        public string FirstName { get; init; } = string.Empty;
        public string LastName { get; init; } = string.Empty;
    }
}
