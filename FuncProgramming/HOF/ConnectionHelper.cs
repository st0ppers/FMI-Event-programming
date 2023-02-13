using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace HOF
{
	public static class ConnectionHelper
	{
		public static R Connect<R>(string connString, Func<IDbConnection, R> func)
		{
			using (var con = new SqlConnection(connString))
			{
				con.Open();
				return func(con);
			}
		}
	}
	public class DbLogger
	{
		//	  "ConnectionStrings": {
		//  "Default": "server=localhost\\SQLEXPRESS;database=library;Trusted_connection=true;Encrypt=False"
		//}
		string conString = "server=localhost\\SQLEXPRESS;database=library;Trusted_connection=true;Encrypt=False";
		public void Log(Author author)
		=> ConnectionHelper.Connect(conString, c => c.Execute("insert into [Author](Name) values (@Name)", new { Name = author.Name }, commandType: CommandType.Text));
	}
}
