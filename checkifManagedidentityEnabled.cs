using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Create an HttpClient to access the Azure Instance Metadata Service
        var client = new HttpClient();

        // Use the client to send a GET request to the metadata endpoint
        var response = client.GetAsync("http://169.254.169.254/metadata/identity/").Result;

        // If the request is successful, parse the JSON response to check for Managed Identities
        if (response.IsSuccessStatusCode)
        {
            var json = JObject.Parse(response.Content.ReadAsStringAsync().Result);

            // Check if Managed Identities are enabled by looking for the "identity" property
            if (json.ContainsKey("identity"))
            {
                Console.WriteLine("Managed Identities are enabled on this instance.");
            }
            else
            {
                Console.WriteLine("Managed Identities are not enabled on this instance.");
            }
        }
        else
        {
            Console.WriteLine("An error occurred while trying to access the Instance Metadata Service.");
        }
    }
}
