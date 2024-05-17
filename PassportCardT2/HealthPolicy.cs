using TestRating;

namespace PassportCardT2
{
    public class HealthPolicy : IPolicy
    {

        private const int _smallDeductible = 500;
        private const int _majorDeductible = 800;
        private const decimal _lowRating = 900m;
        private const decimal _midRating = 1000m;
        private const decimal _highRating = 1100m;

        public PolicyType PolicyType { get; } = PolicyType.Health;
        public string? Gender { get; set; }
        public decimal Deductible { get; set; }
        public string? FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Rating { get; set; }


        public decimal Rate()
        {
            Console.WriteLine("Rating HEALTH policy...");
            Console.WriteLine("Validating policy.");
            if (ValidatePolicy() == false) return Rating; ;

            decimal baseRate = CalculateBaseRate();
            Rating = baseRate;

            return Rating;
        }

        private bool ValidatePolicy()
        {
            if (String.IsNullOrEmpty(this.Gender))
            {
                Console.WriteLine("Health policy must specify Gender");
                return false;
            }
            return true;
        }

        private decimal CalculateBaseRate()
        {
            if (this.Gender == "Male")
            {
                if (this.Deductible < _smallDeductible)
                {
                    return _midRating;
                }
                return _lowRating;
            }
            else
            {
                if (this.Deductible < _majorDeductible)
                {
                    return 1100m;
                }
                return _highRating;
            }
        }
    }
}
