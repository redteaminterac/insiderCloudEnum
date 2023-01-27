using Amazon.EC2.Model;
using Amazon.EC2;

public class AWSInstance
{
    public static string GetInstanceType()
    {
        try
        {
            var client = new AmazonEC2Client();
            var request = new DescribeInstancesRequest();
            var response = client.DescribeInstances(request);

            foreach (var reservation in response.Reservations)
            {
                foreach (var instance in reservation.Instances)
                {
                    return instance.InstanceType;
                }
            }
        }
        catch (AmazonEC2Exception e)
        {
            return "Error: Not running in AWS";
        }
    }
}
