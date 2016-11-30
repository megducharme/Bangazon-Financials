using System;
using System.Text;
using System.Collections.Generic;
using BangazonFinancials.Actions;

namespace BangazonFinancials.Menu
{
	public class MenuSystem
	{
		private struct MenuItem {
			public string prompt;
			public delegate void MenuAction ();
			public MenuAction Action;
		};

		// A collection for storing the menu items
		private Dictionary<int, MenuItem> _MenuItems = new Dictionary<int, MenuItem>();

		// Simple boolean to check whether to keep displaying the main menu
		private bool done = false;

		// To signal that the user is done with Bangazon
		private void MarkDone()
		{
			done = true;
		}

		public MenuSystem()
		{
			_MenuItems.Add (1, new MenuItem (){
				prompt = "Weekly Report",
				Action = GenerateWeeklyReportAction.ReadInput
			});

			_MenuItems.Add (2, new MenuItem (){
				prompt = "Monthy Report",
				Action = GenerateMonthlyReportAction.ReadInput
			});

			_MenuItems.Add (3, new MenuItem (){
				prompt = "Quartly Report",
				Action = GenerateQuartlyReportAction.ReadInput
			});
					
			_MenuItems.Add (4, new MenuItem (){
				prompt = "Customer Revenue Report",
				Action = GenerateCustomerReportAction.ReadInput
			});

			_MenuItems.Add (5, new MenuItem (){
				prompt = "Product Revenue Report",
				Action = GenerateProductReportAction.ReadInput
			});

			_MenuItems.Add (6, new MenuItem (){
				prompt = "Get me out of here!",
				Action = MarkDone
			});
		}

		public void Start()
		{
			while (!done) 
			{
				ShowMainMenu ();
			}
		}

		public void ShowMainMenu ()
		{
			Console.Clear ();

			string border = "===========================";
			StringBuilder mainMenu = new StringBuilder ();
			mainMenu.AppendLine ("\n");
			mainMenu.AppendLine (border);
			mainMenu.AppendLine ("BANGAZON FINANCIAL REPORTS");
			mainMenu.AppendLine (border);


			// Display each menu item
			foreach (KeyValuePair<int, MenuItem> item in _MenuItems) {
				mainMenu.AppendLine (string.Format("{0}. {1}", item.Key, item.Value.prompt));
			}

			Console.WriteLine (mainMenu);
			Console.Write ("> ");

			// Read in the user's choice
			int choice;
			Int32.TryParse (Console.ReadLine(), out choice);

			// Based on their choice, execute the appropriate action
			MenuItem menuItem;
			_MenuItems.TryGetValue (choice, out menuItem);
			menuItem.Action ();
		}
	}
}