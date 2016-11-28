using System;
using System.Text;
using System.Collections.Generic;
using BangazonFinancials.Actions;

namespace Bangazon.Menu
{
	public class MenuSystem
	{
		// Representation of each item that will be displayed in the main menu of choices
		private struct MenuItem {
			public string prompt;
			public delegate void MenuAction ();
			public MenuAction Action;
		};

		// A collection for storing the menu items
		private Dictionary<int, MenuItem> _MenuItems = new Dictionary<int, MenuItem>();

		// Get the customer factory instance
		private CustomerFactory customerFactory = CustomerFactory.Instance;
		private ProductFactory productFactory = ProductFactory.Instance;

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
				prompt = "Create an account",
				Action = CreateCustomerAction.ReadInput
			});

			_MenuItems.Add (2, new MenuItem (){
				prompt = "Choose active customer",
				Action = ChooseActiveCustomerAction.ReadInput
			});

			_MenuItems.Add (3, new MenuItem (){
				prompt = "Create a payment option",
				Action = CreatePaymentOptionAction.ReadInput
			});
					
			_MenuItems.Add (4, new MenuItem (){
				prompt = "Add product to shopping cart",
				Action = OrderProductAction.ReadInput
			});

			_MenuItems.Add (5, new MenuItem (){
				prompt = "Complete order",
				Action = CompleteOrderAction.ReadInput
			});

			_MenuItems.Add (6, new MenuItem (){
				prompt = "Leave Bangazon!",
				Action = MarkDone
			});
		}

		public void Start()
		{
			Console.BackgroundColor = ConsoleColor.DarkGreen;
			Console.ForegroundColor = ConsoleColor.Black;

			while (!done) 
			{
				ShowMainMenu ();
			}
		}

		// Display the main menu of choices for Bangazon
		public void ShowMainMenu ()
		{
			Console.Clear ();

			string border = "*********************************************************";
			StringBuilder mainMenu = new StringBuilder ();
			mainMenu.AppendLine ("\n");
			mainMenu.AppendLine (border);
			mainMenu.AppendLine ("**  Welcome to Bangazon! Command Line Ordering System  **");
			mainMenu.AppendLine (border);

			// If there is an active customer, display a prompt welcoming them
			if (customerFactory.ActiveCustomer != null) {
				Customer c = customerFactory.ActiveCustomer;
				mainMenu.AppendLine (string.Format( "\n >>> Welcome {0} {1}\n", c.FirstName, c.LastName));

				// Show items in the shopping cart, if some exist
				if (productFactory.ShoppingCart.Count > 0) {
					StringBuilder bag = new StringBuilder ();
					bag.Append("     Products in your shopping cart: ");
					foreach (Product p in productFactory.ShoppingCart) {
						bag.Append (string.Format ("{0},", p.Name));
					}
					bag.Remove (bag.Length - 1, 1);
					mainMenu.AppendLine (bag.ToString());
					mainMenu.AppendLine ("");
				}

			}

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

