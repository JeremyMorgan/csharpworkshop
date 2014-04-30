using System;
using System.Threading;
namespace Threader {

	class ThreadTest
	{
		static void Main()
		{
			Thread t = new Thread (WriteY);          // Kick off a new thread
			t.Start();                               // running WriteY()
			
			Thread t2 = new Thread (WriteY);
			t2.Start();
			
			Thread t3 = new Thread (WriteG);
			t3.Start();
		 
			// Simultaneously, do something on the main thread.
			for (int i = 0; i < 100; i++) Console.Write ("x");
		}
		static void WriteG()
		{
			for (int i = 0; i < 100; i++) Console.Write ("g");
		}
		 
		static void WriteY()
		{
			for (int i = 0; i < 100; i++) Console.Write ("y");
		}
	}
}
