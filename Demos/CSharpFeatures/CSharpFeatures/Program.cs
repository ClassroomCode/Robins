using System;

namespace CSharpFeatures
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new();
            p.FirstName = "Bill";

            string str1 = "Hello";
            string str2 = "Hello";
            string str3 = "Hello";

            Person p2 = p;

            if (p == p2) {
                //
            }

            string str = "Test";
            str = str.ToUpper();

            DateTime dt = DateTime.Now;
            dt.AddDays(3);


            Console.WriteLine(p.FirstName);
        }
    }

    struct Person
    {
        public string FirstName;
        public string LastName;
    }
}

