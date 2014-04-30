using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlServerCe;
//using System.Diagnostics;

namespace test {

	class Reader  {
	
		public static void Main(string[] args){
			
			// C:\Program Files (x86)\Microsoft SQL Server Compact Edition\v3.5\Desktop\System.Data.SqlServerCe.dll
			
			string inputfile = args[0];
			string table = args[1];
			double ourtotal = 0;
			
			using (StreamReader r = new StreamReader(@"c:\\data\inputs\" + inputfile))
			{
				string ourline;
				
				while ((ourline = r.ReadLine()) != null)
				{
				ourtotal++;
				}
			}			
		
			// Read the file and display it line by line.
			//System.IO.StreamReader file = new System.IO.StreamReader(@"c:\\data\control.csv");
			System.IO.StreamReader file = new System.IO.StreamReader(@"c:\\data\inputs\" + inputfile);
			
			Console.WriteLine("Reading from " + inputfile + "\n");
			
			string line;
			double counter = 1;
			

			string countrycode;
			//string ip;
			
			string ipstart;
			string ipend;
			//string countryname;
			
			
			string conString = @"Data Source=C:\data\ipdata.sdf";
								
			SqlCeConnection cn = new SqlCeConnection(conString);
			
			//string ourSql = "INSERT INTO " + table + " (ipstart, ipend, countrycode, countryname) VALUES (@ipstart, @ipend, @countrycode, @countryname)";
			
			string ourSql = "INSERT INTO " + table + " (ipstart, ipend, countrycode, countryname) VALUES ";
			string newSql = ourSql;
			
			while((line = file.ReadLine()) != null)
			{
			   string[] lineary = line.Split(',');
			   		    
				ipstart = lineary[0];
				ipend = lineary[1];
				countrycode = lineary[2];
				
				// every 10k rows we do this
				if (counter % 10000 == 0){
					//System.Diagnostics.Debugger.Break();
										
					Console.WriteLine("Wrote " + counter.ToString());
					
					newSql += "(" + ipstart +","+ ipend +","+ countrycode + ");";
					
					//Console.WriteLine(newSql);
					//return;
					 
					if (cn.State == ConnectionState.Closed)
					{
						cn.Open();
					}
				 
					 SqlCeCommand cmd;					
						
					  try
					  {
						
						cmd = new SqlCeCommand(newSql, cn);			
									
						Console.WriteLine(ourSql.ToString());
						
						// execute query
						cmd.ExecuteNonQuery();				
						
					  }
					  catch (SqlCeException sqlexception)
					  {
						Console.WriteLine("Fail" + sqlexception.ToString());
						
					  }
					  catch (Exception ex)
					  {
						Console.WriteLine("Fail" + ex.ToString());
					  }
					  finally
					  {
						cn.Close();
					  }
					
					newSql = ourSql;
				
				}else {				
				
					newSql += "(" + ipstart +","+ ipend +","+ countrycode + "),";
				
				}		
				
				//countryname = lineary[3];
				counter++;
			}
				//ip = lineary[0];
				//countrycode = lineary[1];
				
				
				
				
			file.Close();
		    
			
			Console.WriteLine("Finished!");
			Console.ReadLine();


		}	
		
		
	}
}
