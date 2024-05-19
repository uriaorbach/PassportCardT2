using PassportCardT2;
using PassportCardT2.IO;
using PassportCardT2.Policy;

namespace PassportCardT2.Main
{
    /// <summary>
    /// The RatingEngine gets the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        public decimal Rating { get; set; }
        public void Rate(string policyJson)
        {
            var policyFactory = new PolicyFactory();

            Logger.WriteLine("Starting rate.");
            Logger.WriteLine("Loading policy.");

            if (string.IsNullOrEmpty(policyJson)) return;

            var policy = policyFactory.CreatePolicy(policyJson);
            if (policy != null)
            {
                Rating = policy.Rate();
            }

            Logger.WriteLine("Rating completed.");
        }
    }
}
