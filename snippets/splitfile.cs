using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Data;
using System.Collections.Generic;

namespace test {

	class SplitFile  {

			public static void Main(string[] args){
			int ourtotal = 0;
			string inputfile = args[0];
			string outputname = args[1];
			int split = Convert.ToInt32(args[2]);
			int filecounter = 1;
			string folder = @"c:\\data\inputs\";
			int breakcount = 1;
			
			using (StreamReader r = new StreamReader(folder + inputfile))
			{
				string ourline;
				
				List<string> list1 = new List<string>();
				List<string> list2 = new List<string>();
				List<string> list3 = new List<string>();
				List<string> list4 = new List<string>();
				List<string> list5 = new List<string>();
				List<string> list6 = new List<string>();
				
				// read the file
				string filename = "";
				
				while ((ourline = r.ReadLine()) != null)
				{
					switch (breakcount){
						
						case 1:
							list1.Add(ourline);
							filename = folder + outputname + "-1.csv";
						break;
						
						case 2:
							list2.Add(ourline);	
							filename = folder + outputname + "-2.csv";							
						break;
						
						case 3:
							list3.Add(ourline);
							filename = folder + outputname + "-3.csv";
						break;
						
						case 4:
							list4.Add(ourline);
							filename = folder + outputname + "-4.csv";
						break;
						
						case 5:
							list5.Add(ourline);
							filename = folder + outputname + "-5.csv";
						break;
					
					}
				
					if(ourtotal % split == 0){
					
						Console.WriteLine("Split at " + ourtotal + "\n");
					    Console.WriteLine("Created " + filename + "\n");
						breakcount++;
						
					}
					
					ourtotal++;
				}
			}	
			
			}
			
	}
}
