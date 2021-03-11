using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            LinkedListClass<int> list = new LinkedListClass<int>();
            list.AddFirst(6);
            list.AddLast(2);
            list.AddLast(8);  
        }
    }
}
