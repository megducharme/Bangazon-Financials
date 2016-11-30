using System;
using System.Collections.Generic;
using System.Data;
using BangazonFinancials.Menu;
using BangazonProductRevenueReports;
using Microsoft.Data.Sqlite;

namespace BangazonFinancials
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var connectionString = $"Filename={System.Environment.GetEnvironmentVariable("REPORTING_DB_PATH")}";

            // DatabaseGenerator gen = new DatabaseGenerator();
            // gen.CreateDatabase();

            SqliteCommand cs = new SqliteCommand();
            cs.Connection = new SqliteConnection(connectionString);
            cs.CommandType = CommandType.Text;
            SqliteDataReader reader;
            

            MenuSystem menu = new MenuSystem ();
			menu.Start();
            }
        }
}
