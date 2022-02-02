using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Enter the number of elements for collection");
            int count = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter "+count+" integers for collection");
            List<int> intlist = new List<int>();
            for(int i= 0;i<count;i++)
            {
                intlist.Add(Int32.Parse(Console.ReadLine()));
            }
            Console.WriteLine("Enter " + count + " string for collection");
            Dictionary<int, string> dicstring = new Dictionary<int, string>();
            for(int i=0;i<count;i++)
            {
                dicstring.Add(intlist[i], Console.ReadLine());
            }

            ArrayList arrobj = new ArrayList();
            
            
            Queue queobj = new Queue();
            queobj.Enqueue("This is for queue object");
            queobj.Enqueue("this is second line");
            arrobj.AddRange(queobj);
            for (int i = 0; i < queobj.Count; i++)
            {
                Console.WriteLine(queobj.Dequeue());
            }

            Stack staobj = new Stack();
            staobj.Push("This is for stack obj");
            staobj.Push("This is line 2 of stack obj");
            staobj.Push("This is line 3 of stack obj");
            arrobj.AddRange(staobj);
            for (int i = 0; i < staobj.Count; i++)
            {
                Console.WriteLine(staobj.Pop());
            }

            arrobj.Add("This is a string object");
            arrobj.Add(1);
            for (int i = 0; i < arrobj.Count; i++)
            {
                Console.WriteLine(arrobj[i]);
            }
        }
    }
}
