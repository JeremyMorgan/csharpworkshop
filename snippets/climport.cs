using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlServerCe;

namespace test {

	class Reader  {
	
			public static void Main(string[] args){
			
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
			System.IO.StreamReader file = new System.IO.StreamReader(@"c:\\data\geo_ip_countries.csv");
			//System.IO.StreamReader file = new System.IO.StreamReader(@"c:\\data\inputs\" + inputfile);
			
			Console.WriteLine("Reading from " + inputfile + "\n");
			
			string line;
			double counter = 1;			


			
			//string ipstart;
			//string ipend;
			//string countryname;			
			
			//string conString = @"Data Source=C:\data\ipdata.sdf";
			
			
			SqlCeConnection cn = new SqlCeConnection(conString);
			
			while((line = file.ReadLine()) != null)
			{
			   string[] lineary = line.Split(',');			   
			    
				string ipstart = lineary[0];
				string ipend = lineary[1];
				string countrycode = lineary[2];
				//countryname = lineary[3];				
				
				//ip = lineary[0];
				//countrycode = lineary[1];
				
				if (cn.State == ConnectionState.Closed)
				{
					cn.Open();
				}
			 
				  SqlCeCommand cmd;
				  
				  //string ourSql = "INSERT INTO " + table + " (ipstart, ipend, countrycode, countryname) VALUES (@ipstart, @ipend, @countrycode, @countryname)";
				  string ourSql = "INSERT INTO geo_ip_countries (ipstart, ipend, countrycode ) VALUES (@ipstart, @ipend, @countrycode)";
					
				  try
				  {
					cmd = new SqlCeCommand(ourSql, cn);
					
					
					// Code for Importing Geo IP data
					/*
					cmd.Parameters.AddWithValue( "@ipstart" , ipstart);
					cmd.Parameters.AddWithValue( "@ipend" , ipend);
					cmd.Parameters.AddWithValue( "@countrycode" , countrycode);
					cmd.Parameters.AddWithValue( "@countryname" , countryname);
					*/
					
					
					cmd.Parameters.AddWithValue( "@ipstart" , ipstart);
					cmd.Parameters.AddWithValue( "@ipend" , ipend);
					cmd.Parameters.AddWithValue( "@countrycode" , countrycode);
					
					
					cmd.ExecuteNonQuery();
					
					double ourpct = Math.Round( (counter / ourtotal), 2);
					
					Console.WriteLine("Inserted Record " + counter + "- " + ourpct * 100 + "%");
					
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
				
				counter++;
			}

			file.Close();		    
			
			Console.WriteLine("Finished!");
			Console.ReadLine();
		}		
		
	}
}
