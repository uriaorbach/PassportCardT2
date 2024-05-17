namespace TestRating
{
    class Program
    {
        static void Main(string[] args)
        {

            // load policy - open file policy.json
            var policyJson = File.ReadAllText("policy.json");

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
    }
}
