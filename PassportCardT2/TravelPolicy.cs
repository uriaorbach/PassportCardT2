using TestRating;

namespace PassportCardT2
{
    public class TravelPolicy : IPolicy
    {
        private const decimal _baseRatingMultiplier = 2.5m;
        private const decimal _italyMultiplier = 3m;

        public PolicyType PolicyType { get; } = PolicyType.Travel;
        public string? Country { get; set; }
        public int Days { get; set; }
        public string? FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Rating { get; set; }


        public decimal Rate()
        {
            Console.WriteLine("Rating TRAVEL policy...");
            Console.WriteLine("Validating policy.");
            if (ValidatePolicy() == false) return Rating;

            decimal baseRate = CalculateBaseRate();
            decimal finalRate = ApplyItalyMultiplier(baseRate);
            Rating = finalRate;

            return Rating;
        }
      
        private bool ValidatePolicy()
        {

            const int _minTravelDays = 0;
            const int _maxTravelDays = 180;

            if (Days <= _minTravelDays)
            {
                Console.WriteLine("Travel policy must specify Days.");
                return false;
            }
            if (Days > _maxTravelDays)
            {
                Console.WriteLine($"Travel policy cannot be more than {_maxTravelDays} Days.");
                return false;
            }
            if (String.IsNullOrEmpty(Country))
            {
                Console.WriteLine("Travel policy must specify country.");
                return false;
            }
            return true;
        }

        private decimal CalculateBaseRate()
        {
            return Days * _baseRatingMultiplier;

        }
        private decimal ApplyItalyMultiplier(decimal baseRate)
        {
            if (Country == "Italy")
            {
                baseRate *= _italyMultiplier;
            }
            return baseRate;
        }
    }
}
