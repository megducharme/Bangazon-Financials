using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.Sqlite;

namespace BangazonProductRevenueReports
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MenuSystem menu = new MenuSystem ();
			menu.Start ();
        }
    }
}
