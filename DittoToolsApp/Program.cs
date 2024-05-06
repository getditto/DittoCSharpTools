using DittoSDK;
using DittoTools_Heartbeat;

namespace DittoToolsApp
{
    class Program
    {
        static Ditto? ditto;

        public static void Main(params string[] args)
        {
            ditto = new Ditto(identity: DittoIdentity.OnlinePlayground("<App_ID>", "TOKEN"));

            try 
            {
                ditto.StartSync();
            }
            catch (DittoException ex)
            {
                Console.WriteLine("There was an error starting Ditto.");
                Console.WriteLine("Here's the following error");
                Console.WriteLine(ex.ToString());
                Console.WriteLine("Ditto cannot start sync but don't worry.");
                Console.WriteLine("Ditto will still work as a local database.");
            }
            Console.WriteLine("Welcome to DittoToolsApp2");

            Action<DittoHeartbeatInfo> callback = (info) =>
            {
                Console.WriteLine($"Heartbeat info: {info}");
            };

            DittoHeartbeatConfig config =  new DittoHeartbeatConfig("abc123456", 10);
            DittoHeartbeat heartbeat= new DittoHeartbeat();

            heartbeat.StartHeartbeat(ditto, config, callback);

            Console.WriteLine("Heartbeat started. Press 'q' to stop.");

            // Read user input
            string input = "";
            while (input.ToLower() != "q")
            {
                input = Console.ReadLine();
            }

            // Stop the heartbeat
            heartbeat.StopHeartbeat();

            Console.WriteLine("Heartbeat stopped.");


        }
    }
}

