using DevFramework.Core.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Northwind.Business.Constants
{
	public class Messages
	{
		public static string CategoryAdded = "Category Added";
		public static string CategoryDeleted = "Category Deleted";
		public static string CategoryListed = "Category Listed";
		public static string CategoryUpdated = "Category Updated";

		public static string ProductUpdated = "Product Updated";
		public static string ProductListed = "Product Listed";
		public static string ProductDeleted = "Product Deleted";
		public static string ProductAdded = "Product Added";
		public static string ProductDetailsListed = "Product Details Listed";

		public static string TransactionCompleted = "Transaction Completed";

		public static string AccessTokenCreated = "Access Token Created";

		public static string UserRegistered = "User Registered";
		public static string UserNotFound = "Invalid email or password";
		public static string LoginSuccessful = "Login Successful";
		public static string UserExists = "This User AlreadyExists";
		public static string AuthorizationDenied = "Authorization Denied";
		public static string UserAdded = "User Added";

		public static string ProductNameAlreadyExists = "This Product Name Already Exists";
		public static string MaintenanceHour = "This is Maintenance Hour";
		public static string TooManyProductsForCategory = "Too Many Products For This Category";
	}
}
