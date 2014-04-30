using System;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

class Parallel2
{	
	static void Main(string[] args) 
	{
		// start a timer
        var watch = Stopwatch.StartNew();
	
		for (int i = 0; i < 7; i++){		
			
			FileWriter fw = new FileWriter();
			fw.iteration = i;
			threadDelegate = new ThreadStart(w.WriteFile);
			newThread = new Thread(threadDelegate);
			newThread.Start();			
		}
		
		// stop timer
        watch.Stop();
        Console.WriteLine("\n\nExecution Time: " + watch.ElapsedMilliseconds + " ms");
	}
	
}

class StringGen {

	private readonly Random _rng = new Random();
    private const string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
	
	public void buildDummyFile(string fileName)
    {
        string inputtext = RandomString(100000000);
        writeFile(fileName, inputtext);
    }

    private string RandomString(int size)
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

class FileWriter {
	
	public int iteration;

	public void WriteFile()
	{
		Console.WriteLine("Running Thread {0} ...", Thread.CurrentThread.ManagedThreadId);
		StringGen oursg = new StringGen();
		oursg.buildDummyFile("test" + iteration + ".txt");
	}		

}
