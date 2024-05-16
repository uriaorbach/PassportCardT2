using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using PassportCardT2;
using System;
using System.IO;

namespace TestRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        public decimal Rating { get; set; }
        public void Rate(string policyJson)
        {
            var policyFactory = new PolicyFactory();
            // log start rating
            Console.WriteLine("Starting rate.");
            Console.WriteLine("Loading policy.");

            if(string.IsNullOrEmpty(policyJson)) return;

            var policy = policyFactory.CreatePolicy(policyJson);

            if (policy != null)
            {
                policy.Rate();
            }

            Console.WriteLine("Rating completed.");
        }
    }
}
