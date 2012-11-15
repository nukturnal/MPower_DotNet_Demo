using System;
using MPowerPayments;

namespace MPowerTest
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			// Generate API keys from mpower and setup
//			MPowerSetup setup = new MPowerSetup {
//				MasterKey = "82403450-ee3a-4c57-9564-a8fbe30c5fb7",
//				PrivateKey = "test_private_jKxSyaylcQdrQcuxAOFAbxvK5w4",
//				PublicKey = "test_public_M6-fRS1RCnzlGqgeLaBF5vLLoKs",
//				Token = "7f6c81c1ea223674416e",
//				Mode = "test"
//			};

			MPowerSetup setup = new MPowerSetup {
				MasterKey = "82403450-ee3a-4c57-9564-a8fbe30c5fb7",
				PrivateKey = "live_private_15O3webVPJoCXA6Z0m5d4VyZMwk",
				PublicKey = "live_public_zE0Ob-JtkKgVBYrIsa5h9tp6_KY",
				Token = "17a2aab97fc48052a49c",
				Mode = "live"
			};
			
			MPowerStore store = new MPowerStore {
				Name = "DotNet Online Store",
				Tagline = "This is my awesome tagline",
				PhoneNumber = "0244124660",
				PostalAddress = "P. O. Box 10770 Accra North Ghana",
				LogoUrl = "http://www.mylogourl.com/photo.png",
//				CancelUrl = "http://www.google.com",
//				ReturnUrl = "http://www.returnurl.com/"
			};

			MPowerOnsiteInvoice invoice = new MPowerOnsiteInvoice (setup, store);
			if (invoice.Charge ("OPR-cd28584202305f04", "XYDQLZ")) {
				Console.WriteLine(invoice.Status);
				Console.WriteLine(invoice.ResponseText);
				Console.WriteLine(invoice.GetReceiptUrl());
			} else {
				Console.WriteLine(invoice.Status);
				Console.WriteLine(invoice.ResponseText);
			}

//			invoice.AddItem ("A Big Bag of Rice", 2, 20.99, 41.89,"Salutana premium size bag of rice");
//			invoice.AddItem ("Huge Bag of Chocolates", 2, 20.99, 41.89,"Golden tree TRX-100 Agentina");
//			invoice.AddItem ("Pair of trousers", 2, 20.99, 41.89);
//
//			invoice.SetTotalAmount (100.50);
//			invoice.SetCustomData("Name","Alfred Rowe");
//			invoice.AddTax("VAT (5%)",30);
//			invoice.AddTax("NHIL (15%)",30);
//
//			if (invoice.Create("0244124660")) {
//				Console.WriteLine (invoice.Token);
//				Console.WriteLine (invoice.InvoiceToken);
//				Console.WriteLine (invoice.Status);
//				Console.WriteLine (invoice.ResponseText);
//				Console.WriteLine (invoice.GetInvoiceUrl());
//			} else {
//				Console.WriteLine (invoice.ResponseText);
//				Console.WriteLine (invoice.Status);
//			}
		}
	}
}
