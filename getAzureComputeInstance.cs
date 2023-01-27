using System;
using System.Net;
using Newtonsoft.Json;

public class AzureComputeInstance
{
    public static string GetComputeType()
    {
        try
        {
            var client = new WebClient();
            var json = client.DownloadString("http://169.254.169.254/metadata/instance?api-version=2019-03-11");

            dynamic metadata = JsonConvert.DeserializeObject(json);
            return metadata.compute.offer;
        }
        catch (WebException)
        {
            return "Error: Not running in Azure";
        }
    }
}
