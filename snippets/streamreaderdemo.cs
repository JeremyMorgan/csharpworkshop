using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlServerCe;

namespace test {

	class Reader  {
	
			public static void Main(){
		
			// Read the file and display it line by line.
			//System.IO.StreamReader file = new System.IO.StreamReader(@"c:\\data\control.csv");
			System.IO.StreamReader file = new System.IO.StreamReader(@"c:\\data\inputs\geolite.csv");
			
			string line;
			double counter = 1;
			double ourtotal = 99104;

			string countrycode;
			//string ip;
			
			string ipstart;
			string ipend;
			string countryname;
			
			
			string conString = @"Data Source=C:\data\ipdata.sdf";

								
			SqlCeConnection cn = new SqlCeConnection(conString);
			
			while((line = file.ReadLine()) != null)
			{
			   string[] lineary = line.Split(',');
			   
			    
				ipstart = lineary[0];
				ipend = lineary[1];
				countrycode = lineary[2];
				countryname = lineary[3];
				
				
				//ip = lineary[0];
				//countrycode = lineary[1];
				
				if (cn.State == ConnectionState.Closed)
				{
					cn.Open();
				}
			 
				  SqlCeCommand cmd;
				  
				  string ourSql = "INSERT INTO GeoLite (ipstart, ipend, countrycode, countryname) VALUES (@ipstart, @ipend, @countrycode, @countryname)";
				  //string ourSql = "INSERT INTO tests (ipaddress, expectedcountry) VALUES (@ip, @countrycode)";
					
				  try
				  {
					cmd = new SqlCeCommand(ourSql, cn);
					
					
					// Code for Importing Geo IP data
					cmd.Parameters.AddWithValue( "@ipstart" , ipstart);
					cmd.Parameters.AddWithValue( "@ipend" , ipend);
					cmd.Parameters.AddWithValue( "@countrycode" , countrycode);
					cmd.Parameters.AddWithValue( "@countryname" , countryname);
					
					
					//cmd.Parameters.AddWithValue( "@ip" , ip);
					//cmd.Parameters.AddWithValue( "@countrycode" , countrycode);
					
					
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
				
				//Console.WriteLine(ourSql);
				
				//Console.WriteLine(start + " " + end + " " + countrycode + " " + countryname + "\n");				
				
				counter++;
			}
			
			

			file.Close();
		    
			// Suspend the screen.
			Console.WriteLine("Finished!");
			Console.ReadLine();


		}	
		
		/*
			// Open the same connection with the same connection string.
			using (SqlCeConnection con = new SqlCeConnection(conString))
			{
				con.Open();
				// Read in all values in the table.
				using (SqlCeCommand com = new SqlCeCommand("SELECT ipstart, ipend, countrycode, countryname FROM ipcountries", con))
				{
				SqlCeDataReader reader = com.ExecuteReader();
				while (reader.Read())
				{
					int start = Convert.ToInt32(reader.GetInt32(0));
					//int end = Convert.ToInt32(reader.GetInt32(1));
					//string countrycode = reader.GetString(2).ToString();
					//string countryname = reader.GetString(4).ToString();
					Console.WriteLine(start.ToString());
					
					//Console.WriteLine(start + " " + end + " " + countrycode + " " + countryname  + "\n");
				}
				}
			}
			*/
	}
}
