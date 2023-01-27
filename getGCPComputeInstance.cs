using System;
using System.Net;

public class GCPInstance
{
    public static string GetInstanceType()
    {
        try
        {
            var client = new WebClient();
            client.Headers.Add("Metadata-Flavor", "Google");
            var json = client.DownloadString("http://metadata.google.internal/computeMetadata/v1/instance/");
            return json;
        }
        catch (WebException)
        {
            return "Error: Not running in GCP";
        }
    }
}
