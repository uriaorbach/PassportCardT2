using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRating;

namespace PassportCardT2
{
    public class TravelPolicy : IPolicy
    {
        private const decimal _baseRatingMultiplier = 2.5m;
        private const decimal _italyMultiplier = 3;

        public PolicyType PolicyType { get; } = PolicyType.Travel;
        public string? Country { get; set; }
        public int Days { get; set; }
        public string? FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Rating { get; set; }


        public void Rate()
        {
            Console.WriteLine("Rating TRAVEL policy...");
            Console.WriteLine("Validating policy.");
            if (ValidatePolicy() == false) return;

            Rating = this.Days * _baseRatingMultiplier;
            if (this.Country == "Italy")
            {
                Rating *= _italyMultiplier;
            }
        }

        private bool ValidatePolicy()
        {

            const int _minTravelDays = 0;
            const int _maxTravelDays = 180;

            if (this.Days <= _minTravelDays)
            {
                Console.WriteLine("Travel policy must specify Days.");
                return false;
            }
            if (this.Days > _maxTravelDays)
            {
                Console.WriteLine($"Travel policy cannot be more than {_maxTravelDays} Days.");
                return false;
            }
            if (String.IsNullOrEmpty(this.Country))
            {
                Console.WriteLine("Travel policy must specify country.");
                return false;
            }
            return true;
        }
    }
}
