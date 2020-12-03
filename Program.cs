using System;
using RestSharp;

namespace RTX3080
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Clear();
			
			int reqnum = 0;
			string response2;
			
			Console.WriteLine("getting ready to send request");
			
			var client = new RestClient("https://www.bestbuy.com/site/nvidia-geforce-rtx-3080-10gb-gddr6x-pci-express-4-0-graphics-card-titanium-and-black/6429440.p?skuId=6429440&ref=186&loc=nvidia_6429440");
			var request = new RestRequest(Method.GET);
			
			request.AddHeader("User-Agent","Mozilla/5.0 (Windows NT 10.0; Win64; x64;");;
			
			Console.WriteLine("ready to send request, starting loop");
			
			while(true){
				IRestResponse response = client.Execute(request);
				reqnum += 1;
				response2 = response.Content.ToString();
				
				Console.Write("(request number " + reqnum + ") NVIDIA GeForce RTX 3080 : ");
				if (response.IsSuccessful)
				{
					if(response2.Contains("Sold Out")){
						Console.Write("Out of stock\n");
					} else {
						Console.Write("In stock\n");
					}
				} else {
					Console.WriteLine("Failed to send request");
				}
			}
		}
	}
}
