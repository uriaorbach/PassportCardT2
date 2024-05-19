using PassportCardT2.IO;
using PassportCardT2.Main;
using System.Net.WebSockets;

namespace PassportCardT2
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = "policy.json";
            var fileReader = new FileReader();

            try
            {
                var policyJson = fileReader.ReadFileContent(filePath);
                if (string.IsNullOrEmpty(policyJson))
                {
                    Logger.WriteError($"file {filePath} is empty, could not read policy");
                    return;
                }
                Logger.WriteLine("Insurance Rating System Starting...");

                var engine = new RatingEngine();
                engine.Rate(policyJson);

                Logger.WriteLine(engine.Rating > 0 ? $"Rating: {engine.Rating}" : "No rating produced.");

            }
            catch (IOException ex)
            {
                Logger.WriteError(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.WriteError(ex.Message);
            }

        }
    }
}
