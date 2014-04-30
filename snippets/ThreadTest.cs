using System;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

class stringGen
{
    private readonly Random _rng = new Random();
    private const string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public void buildDummyFile(string fileName)
    {
        string inputtext = RandomString(100000000);
        writeFile(fileName, inputtext);
    }

    public string RandomString(int size)
    {
        char[] buffer = new char[size];

        for (int i = 0; i < size; i++)
        {
            buffer[i] = _chars[_rng.Next(_chars.Length)];
        }
        return new string(buffer);
    }

    private void writeFile(string filename, string inputtext)
    {
        TextWriter tw = new StreamWriter(filename);
        tw.WriteLine(inputtext);
        tw.Close();
    }

}

class threadTest
{

    public static void Main(string[] args)
    {

        // start a timer
        var watch = Stopwatch.StartNew();

        // create string generator object
        stringGen sg1 = new stringGen();

        if (args.Length == 0)
        {
            Console.WriteLine("\n\nUsage: threadtest [n]\n\nn = number of threads (1,2,4,8)\n");
        }
        else
        {

            int threads = Convert.ToInt32(args[0]);

            switch (threads)
            {

                case 1:

                    Console.WriteLine("Writing with a single thread");
                    Console.WriteLine("Writing File 1");
                    sg1.buildDummyFile("test1.txt");
					Console.WriteLine("Writing File 2");
                    sg1.buildDummyFile("test2.txt");
					Console.WriteLine("Writing File 3");
                    sg1.buildDummyFile("test3.txt");
					Console.WriteLine("Writing File 4");
                    sg1.buildDummyFile("test4.txt");
					Console.WriteLine("Writing File 5");
                    sg1.buildDummyFile("test5.txt");
					Console.WriteLine("Writing File 6");
                    sg1.buildDummyFile("test6.txt");
					Console.WriteLine("Writing File 7");
                    sg1.buildDummyFile("test7.txt");
					Console.WriteLine("Writing File 8");
                    sg1.buildDummyFile("test8.txt");

                    break;

                case 2:

                    Console.WriteLine("Writing with 2 Threads");

                    Parallel.Invoke(() =>
                    {
                        Console.WriteLine("Writing File 1");
                        sg1.buildDummyFile("test1.txt");
                    },

                    () =>
                    {
                        Console.WriteLine("Writing File 2");
                        sg1.buildDummyFile("test2.txt");
                    });

                    Parallel.Invoke(() =>
                    {
                        Console.WriteLine("Writing File 3");
                        sg1.buildDummyFile("test3.txt");
                    },

                    () =>
                    {
                        Console.WriteLine("Writing File 4");
                        sg1.buildDummyFile("test4.txt");
                    });

                    Parallel.Invoke(() =>
                    {
                        Console.WriteLine("Writing File 5");
                        sg1.buildDummyFile("test5.txt");
                    },

                    () =>
                    {
                        Console.WriteLine("Writing File 6");
                        sg1.buildDummyFile("test6.txt");
                    });

                    Parallel.Invoke(() =>
                    {
                        Console.WriteLine("Writing File 7");
                        sg1.buildDummyFile("test7.txt");
                    },

                    () =>
                    {
                        Console.WriteLine("Writing File 8");
                        sg1.buildDummyFile("test8.txt");
                    }

                    );
                    break;

                case 4:

                    Console.WriteLine("Writing with 4 Threads");

                    Parallel.Invoke(() =>
                    {
                        Console.WriteLine("Writing File 1");
                        sg1.buildDummyFile("test1.txt");
                    },
                    () =>
                    {
                        Console.WriteLine("Writing File 2");
                        sg1.buildDummyFile("test2.txt");
                    },
                    () =>
                    {
                        Console.WriteLine("Writing File 3");
                        sg1.buildDummyFile("test3.txt");
                    },

                    () =>
                    {
                        Console.WriteLine("Writing File 4");
                        sg1.buildDummyFile("test4.txt");
                    });

                    Parallel.Invoke(() =>
                    {
                        Console.WriteLine("Writing File 5");
                        sg1.buildDummyFile("test5.txt");
                    },

                    () =>
                    {
                        Console.WriteLine("Writing File 6");
                        sg1.buildDummyFile("test6.txt");
                    },
                    () =>
                    {
                        Console.WriteLine("Writing File 7");
                        sg1.buildDummyFile("test7.txt");
                    },

                    () =>
                    {
                        Console.WriteLine("Writing File 8");
                        sg1.buildDummyFile("test8.txt");
                    }

                    );
                    break;
                case 8:

                    Console.WriteLine("Writing with 8 Threads");
                    Parallel.Invoke(() =>
                    {
                        Console.WriteLine("Writing File 1");
                        sg1.buildDummyFile("test1.txt");
                    },

                    () =>
                    {
                        Console.WriteLine("Writing File 2");
                        sg1.buildDummyFile("test2.txt");
                    },

                    () =>
                    {
                        Console.WriteLine("Writing File 3");
                        sg1.buildDummyFile("test3.txt");
                    },

                    () =>
                    {
                        Console.WriteLine("Writing File 4");
                        sg1.buildDummyFile("test4.txt");
                    },

                    () =>
                    {
                        Console.WriteLine("Writing File 5");
                        sg1.buildDummyFile("test5.txt");
                    },

                    () =>
                    {
                        Console.WriteLine("Writing File 6");
                        sg1.buildDummyFile("test6.txt");
                    },

                    () =>
                    {
                        Console.WriteLine("Writing File 7");
                        sg1.buildDummyFile("test7.txt");
                    },

                    () =>
                    {
                        Console.WriteLine("Writing File 8");
                        sg1.buildDummyFile("test8.txt");
                    }

                    );
                    break;
					
				case 32:
				
				 Console.WriteLine("Writing with 8 Threads");
                    Parallel.Invoke(() =>
                    {
                        Console.WriteLine("Writing File 1");
                        sg1.buildDummyFile("test1.txt");
                    },

                    () =>
                    {
                        Console.WriteLine("Writing File 2");
                        sg1.buildDummyFile("test2.txt");
                    },

                    () =>
                    {
                        Console.WriteLine("Writing File 3");
                        sg1.buildDummyFile("test3.txt");
                    },

                    () =>
                    {
                        Console.WriteLine("Writing File 4");
                        sg1.buildDummyFile("test4.txt");
                    },

                    () =>
                    {
                        Console.WriteLine("Writing File 5");
                        sg1.buildDummyFile("test5.txt");
                    },

                    () =>
                    {
                        Console.WriteLine("Writing File 6");
                        sg1.buildDummyFile("test6.txt");
                    },

                    () =>
                    {
                        Console.WriteLine("Writing File 7");
                        sg1.buildDummyFile("test7.txt");
                    },

                    () =>
                    {
                        Console.WriteLine("Writing File 8");
                        sg1.buildDummyFile("test8.txt");
                    },
					
					() =>
                    {
                        Console.WriteLine("Writing File 9");
                        sg1.buildDummyFile("test9.txt");
                    },

                    () =>
                    {
                        Console.WriteLine("Writing File 10");
                        sg1.buildDummyFile("test10.txt");
                    },

					 () =>
                    {
                        Console.WriteLine("Writing File 11");
                        sg1.buildDummyFile("test11.txt");
                    },

					 () =>
                    {
                        Console.WriteLine("Writing File 12");
                        sg1.buildDummyFile("test12.txt");
                    },

					 () =>
                    {
                        Console.WriteLine("Writing File 13");
                        sg1.buildDummyFile("test13.txt");
                    },

					 () =>
                    {
                        Console.WriteLine("Writing File 14");
                        sg1.buildDummyFile("test14.txt");
                    },

					 () =>
                    {
                        Console.WriteLine("Writing File 15");
                        sg1.buildDummyFile("test15.txt");
                    },

					 () =>
                    {
                        Console.WriteLine("Writing File 16");
                        sg1.buildDummyFile("test16.txt");
                    },

					 () =>
                    {
                        Console.WriteLine("Writing File 17");
                        sg1.buildDummyFile("test17.txt");
                    },

					 () =>
                    {
                        Console.WriteLine("Writing File 18");
                        sg1.buildDummyFile("test18.txt");
                    },

					 () =>
                    {
                        Console.WriteLine("Writing File 19");
                        sg1.buildDummyFile("test19.txt");
                    },

					
					
					
					  () =>
                    {
                        Console.WriteLine("Writing File 20");
                        sg1.buildDummyFile("test20.txt");
                    },

					 () =>
                    {
                        Console.WriteLine("Writing File 21");
                        sg1.buildDummyFile("test21.txt");
                    },

					 () =>
                    {
                        Console.WriteLine("Writing File 22");
                        sg1.buildDummyFile("test22.txt");
                    },

					 () =>
                    {
                        Console.WriteLine("Writing File 23");
                        sg1.buildDummyFile("test23.txt");
                    },

					 () =>
                    {
                        Console.WriteLine("Writing File 24");
                        sg1.buildDummyFile("test24.txt");
                    },

					() =>
                    {
                        Console.WriteLine("Writing File 25");
                        sg1.buildDummyFile("test25.txt");
                    },

					() =>
                    {
                        Console.WriteLine("Writing File 26");
                        sg1.buildDummyFile("test16.txt");
                    },

					() =>
                    {
                        Console.WriteLine("Writing File 27");
                        sg1.buildDummyFile("test17.txt");
                    },

					() =>
                    {
                        Console.WriteLine("Writing File 28");
                        sg1.buildDummyFile("test28.txt");
                    },

					() =>
                    {
                        Console.WriteLine("Writing File 29");
                        sg1.buildDummyFile("test29.txt");
                    },
					
					() =>
                    {
                        Console.WriteLine("Writing File 30");
                        sg1.buildDummyFile("test30.txt");
                    },
					
					() =>
                    {
                        Console.WriteLine("Writing File 31");
                        sg1.buildDummyFile("test31.txt");
                    },
					
					() =>
                    {
                        Console.WriteLine("Writing File 32");
                        sg1.buildDummyFile("test32.txt");
                    }
                   
                    );                    
				
				break;
            }

        }
        // stop timer
        watch.Stop();

        Console.WriteLine("\n\nExecution Time: " + watch.ElapsedMilliseconds + " ms");
    }

}
