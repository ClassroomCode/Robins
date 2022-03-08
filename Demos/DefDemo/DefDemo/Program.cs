using System;
using System.Collections.Generic;
using System.Linq;

namespace DefDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };

            var evens = nums.Where(n => n % 2 == 0);
            evens = evens.Where(n => n > 4);

            evens.ToList().ForEach(e => Console.WriteLine(e));

            Console.WriteLine("--------");

            nums.Add(12);

            evens.ToList().ForEach(e => Console.WriteLine(e));

            Console.ReadKey();
        }
    }
}
