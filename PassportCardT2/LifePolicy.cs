using TestRating;

namespace PassportCardT2
{
    public class LifePolicy : IPolicy
    {

        const int _baseLifeRatingDivider = 200;
        const int _smokerMultiplier = 2;

        public PolicyType PolicyType { get; } = PolicyType.Life;
        public bool IsSmoker { get; set; }
        public decimal Amount { get; set; }
        public string? FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Rating { get; set; }

        public decimal Rate()
        {
            Console.WriteLine("Rating LIFE policy...");
            Console.WriteLine("Validating policy.");

            if (ValidatePolicy() == false) return Rating;

            int age = Helpers.CalculateAge(this.DateOfBirth);
            decimal baseRate = CalculateBaseRate(age);
            decimal finalRate = ApplySmokerMultiplier(baseRate,this.IsSmoker);
         
            Rating = finalRate;
            return Rating;
        }

        private bool ValidatePolicy()
        {
            const int _maxEligibleCoverageAge = 100;

            var age = Helpers.CalculateAge(this.DateOfBirth);

            if (this.DateOfBirth == DateTime.MinValue)
            {
                Console.WriteLine("Life policy must include Date of Birth.");
                return false;
            }
            if (age > _maxEligibleCoverageAge)
            {
                Console.WriteLine($"Max eligible age for coverage is {_maxEligibleCoverageAge} years.");
                return false;
            }
            if (this.Amount == 0)
            {
                Console.WriteLine("Life policy must include an Amount.");
                return false;
            }
            return true;
        }

        private decimal CalculateBaseRate(int age)
        {
            return this.Amount * age / _baseLifeRatingDivider;
        }

        private decimal ApplySmokerMultiplier(decimal baseRate, bool isSmoker)
        {
            if (isSmoker)
            {
                baseRate *= _smokerMultiplier;
            }
            return baseRate;
        }

      
    }
}
