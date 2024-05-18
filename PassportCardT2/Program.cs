using PassportCardT2.Main;
using System.Net.WebSockets;

namespace PassportCardT2
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = "policy.json";
            try
            {

                // load policy - open file policy.json
                var policyJson = File.ReadAllText(filePath);

                Console.WriteLine("Insurance Rating System Starting...");

                var engine = new RatingEngine();
                engine.Rate(policyJson);

                if (engine.Rating > 0)
                {
                    Console.WriteLine($"Rating: {engine.Rating}");
                }
                else
                {
                    Console.WriteLine("No rating produced.");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
