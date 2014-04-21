using System;

namespace csharplearning
{
    class Program
    {
        static void Main(string[] args)
        {
            // initialize an instance with nothing
            test test1 = new test();
            // initialize an instance with an integer
            test test2 = new test(3);
            // initialize an instance with a string
            test test3 = new test("Foo");
            // initialize an instance with a string and integer
            test test4 = new test("Foo", 3);

            // write out the results
            Console.WriteLine("Test 1 Result:" + test1.ourMessage);
            Console.WriteLine("Test 2 Result:" + test2.ourMessage);
            Console.WriteLine("Test 3 Result:" + test3.ourMessage);
            Console.WriteLine("Test 4 Result:" + test4.ourMessage);

            // pause to keep the window open
            Console.Read();

        }
    }
}
