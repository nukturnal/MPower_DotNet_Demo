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

			MPowerDirectCard card = new MPowerDirectCard (setup);
			if (card.Charge (20.0, "Alfred R. Rowe", "378282246310005", "123", "06", "2014")) {
				Console.WriteLine (card.ResponseText);
			} else {
				Console.WriteLine (card.ResponseText);
			}

//			Performing an MPower Checkout Request
			MPowerCheckoutInvoice checkout_invoice = new MPowerCheckoutInvoice (setup, store);
			checkout_invoice.AddItem ("A Big Bag of Rice", 2, 20.99, 41.89,"Salutana premium size bag of rice");
			checkout_invoice.AddItem ("Huge Bag of Chocolates", 2, 20.99, 41.89,"Golden tree TRX-100 Agentina");
			checkout_invoice.AddItem ("Pair of trousers", 2, 20.99, 41.89);
			
			checkout_invoice.SetTotalAmount (100.50);
			checkout_invoice.SetCustomData("Name","Alfred Rowe");
			checkout_invoice.AddTax("VAT (5%)",30);
			checkout_invoice.AddTax("NHIL (15%)",30);

			Console.WriteLine("MPower Checkout Request Test");

			if (checkout_invoice.Create()) {
				Console.WriteLine (checkout_invoice.Token);
				Console.WriteLine (checkout_invoice.Status);
				Console.WriteLine (checkout_invoice.ResponseText);
				Console.WriteLine (checkout_invoice.GetInvoiceUrl());
			} else {
				Console.WriteLine (checkout_invoice.ResponseText);
				Console.WriteLine (checkout_invoice.Status);
			}


//			Performing an MPower OPR Request & Charge

			MPowerOnsiteInvoice opr_invoice = new MPowerOnsiteInvoice (setup, store);
			opr_invoice.AddItem ("A Big Bag of Rice", 2, 20.99, 41.89,"Salutana premium size bag of rice");
			opr_invoice.AddItem ("Huge Bag of Chocolates", 2, 20.99, 41.89,"Golden tree TRX-100 Agentina");
			opr_invoice.AddItem ("Pair of trousers", 2, 20.99, 41.89);
			
			opr_invoice.SetTotalAmount (100.50);
			opr_invoice.SetCustomData("Name","Alfred Rowe");
			opr_invoice.AddTax("VAT (5%)",30);
			opr_invoice.AddTax("NHIL (15%)",30);

//			The Request
			Console.WriteLine("MPower OPR Request Test");

			if (opr_invoice.Create("MPOWER_CUSTOMER_USERNAME_OR_PHONENO")) {
				Console.WriteLine (opr_invoice.Token);
				Console.WriteLine (opr_invoice.Status);
				Console.WriteLine (opr_invoice.ResponseText);
			} else {
				Console.WriteLine (opr_invoice.ResponseText);
				Console.WriteLine (opr_invoice.Status);
			}

//			The Charge
			Console.WriteLine("MPower OPR Charge Test");
			MPowerOnsiteInvoice opr_invoice2 = new MPowerOnsiteInvoice (setup, store);
			if (opr_invoice2.Charge ("OPR-cd28584202305f04", "XYDQLZ")) {
				Console.WriteLine (opr_invoice2.Status);
				Console.WriteLine (opr_invoice2.ResponseText);
				Console.WriteLine (opr_invoice2.GetReceiptUrl ());
			} else {
				Console.WriteLine (opr_invoice2.Status);
				Console.WriteLine (opr_invoice2.ResponseText);
			}

//			Paying an MPower Account holder using MPowerDirectPay
			Console.WriteLine("MPower DirectPay Test");
			MPowerDirectPay direct_pay = new MPowerDirectPay (setup);
			if(direct_pay.CreditAccount("MPOWER_CUSTOMER_USERNAME_OR_PHONENO",50)){
				Console.WriteLine(direct_pay.Description);
				Console.WriteLine (direct_pay.Status);
				Console.WriteLine (direct_pay.ResponseText);
			}else{
				Console.WriteLine(direct_pay.ResponseText);
				Console.WriteLine (direct_pay.Status);
			}
		}
	}
}
