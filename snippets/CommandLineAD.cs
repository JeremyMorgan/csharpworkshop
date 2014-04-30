using System;
using System.DirectoryServices;

class Auth
{

	public static void Main(){

		string path= "LDAP://DC=[DOMAIN],DC=local";
		string strAccountId = "[USERNAME]";
		string strPassword = "[PASSWORD]";
		bool bSucceeded;
		string strError;
		
		DirectoryEntry adsEntry = new DirectoryEntry(path, strAccountId, strPassword);
		
		DirectorySearcher adsSearcher = new DirectorySearcher( adsEntry );
		adsSearcher.Filter = "(sAMAccountName=" + strAccountId + ")";

		try 
		 {
		  SearchResult adsSearchResult = adsSearcher.FindOne();
		  bSucceeded = true;		  
		  strError = "User has been authenticated by Active Directory.";
		  adsEntry.Close();
		 }
		catch ( Exception ex )
		 {
			bSucceeded = false;
			strError = ex.Message;
			adsEntry.Close();
		 }		 
		 
		 if (bSucceeded){
			Console.WriteLine("Great Success");
		 }else {
			Console.WriteLine("Great Fail");
		 }
		
	 
	 }
 }
