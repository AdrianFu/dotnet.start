var addresses = new string[] {
    "time-a-g.nist.gov",
    "time-b-g.nist.gov",
    "time-c-g.nist.gov",
    "time-d-g.nist.gov",
    "time-e-g.nist.gov",
    "time-a-wwv.nist.gov",
    "time-b-wwv.nist.gov",
    "time-c-wwv.nist.gov",
    "time-d-wwv.nist.gov",
    "time-e-wwv.nist.gov",
    "time-a-b.nist.gov",
    "time-b-b.nist.gov",
    "time-c-b.nist.gov",
    "time-d-b.nist.gov",
    "time-e-b.nist.gov",
    "utcnist.colorado.edu",
    "utcnist2.colorado.edu"
};

// For more info
// https://www.nist.gov/pml/time-and-frequency-division/time-distribution/internet-time-service-its
//
// The generic name time.nist.gov will continue to point to all of our servers on a round-robin basis,
// and users are encouraged to access the service using this name.
var address_all_server = "time.nist.gov";

var address_of_call = address_all_server;

var client = new System.Net.Sockets.TcpClient(address_of_call, 13);
Console.WriteLine($"TimeBefore:{DateTime.Now.ToString("yy-MM-dd HH:mm:ss")}");
using (var streamReader = new StreamReader(client.GetStream()))
{
    var response = streamReader.ReadToEnd().Trim();
    Console.WriteLine($"ServerName:{address_of_call}");
    Console.WriteLine($"Response:{response}");
    Console.WriteLine($"ResponseLength:{response.Length}");

    if (response.Length >= 48) {
        var time = response.Substring(6, 17);
        Console.WriteLine($"Time:{time}");
        var serverHealthy = response[29];
        if (serverHealthy == '0') {
            Console.WriteLine("ServerIsHealthy:TRUE");
        }
        else
        {
            Console.WriteLine("ServerIsHealthy:FALSE");
        }
    }
}
Console.WriteLine($"TimeAfter:{DateTime.Now.ToString("yy-MM-dd HH:mm:ss")}");
