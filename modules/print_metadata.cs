using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program {
    static async Task Main(string[] args) {
        var client = new HttpClient();
        string metadata;

        // check if running on AWS
        try {
            metadata = await client.GetStringAsync("http://169.254.169.254/latest/meta-data/");
            Console.WriteLine("Running on AWS, metadata: " + metadata);
        } catch (HttpRequestException) {
            // not running on AWS
        }

        // check if running on Azure
        try {
            metadata = await client.GetStringAsync("http://169.254.169.254/metadata/instance?api-version=2020-09-01");
            Console.WriteLine("Running on Azure, metadata: " + metadata);
        } catch (HttpRequestException) {
            // not running on Azure
        }

        // check if running on GCP
        try {
            metadata = await client.GetStringAsync("http://metadata.google.internal/computeMetadata/v1/");
            Console.WriteLine("Running on GCP, metadata: " + metadata);
        } catch (HttpRequestException) {
            // not running on GCP
        }
    }
}
