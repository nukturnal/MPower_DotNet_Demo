using System;
using MPowerPayments;

namespace MPowerTest
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			// Generate API keys from mpower and setup
			MPowerSetup setup = new MPowerSetup {
				MasterKey = "82403450-ee3a-4c57-9564-a8fbe30c5fb7",
				PrivateKey = "test_private_jKxSyaylcQdrQcuxAOFAbxvK5w4",
				PublicKey = "test_public_M6-fRS1RCnzlGqgeLaBF5vLLoKs",
				Token = "7f6c81c1ea223674416e",
				Mode = "test"
			};
			
			MPowerStore store = new MPowerStore {
				Name = "DotNet Online Store",
				Tagline = "This is my awesome tagline",
				PhoneNumber = "0244124660",
				PostalAddress = "P. O. Box 10770 Accra North Ghana",
				LogoUrl = "http://www.mylogourl.com/photo.png",
				CancelUrl = "http://www.google.com",
				ReturnUrl = "http://www.returnurl.com/",
			};

			MPowerCheckoutInvoice invoice = new MPowerCheckoutInvoice (setup, store);
			
			invoice.AddItem ("A Big Bag of Rice", 1, 20.99, 41.89);
			invoice.AddItem ("Huge Bag of Chocolates", 1, 20.99, 41.89);
			invoice.AddItem ("Pair of trousers", 1, 20.99, 41.89);

			invoice.SetTotalAmount (100.50);
			invoice.SetCustomData("Name","Alfred Rowe");

			if (invoice.Create ()) {
				Console.WriteLine (invoice.Status);
				Console.WriteLine (invoice.ResponseText);
				Console.WriteLine (invoice.GetInvoiceUrl ());
			} else {
				Console.WriteLine (invoice.ResponseText);
				Console.WriteLine (invoice.Status);
			}
		}
	}
}
