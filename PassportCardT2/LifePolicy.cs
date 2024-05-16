using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRating;

namespace PassportCardT2
{
    public class LifePolicy : IPolicy
    {
        public PolicyType PolicyType { get; } = PolicyType.Life;
        public bool IsSmoker { get; set; }
        public decimal Amount { get; set; }
        public string? FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Rating { get; set; }

        public void Rate()
        {

            const int _smokerMultiplier = 2;
            const int _baseLifeRatingDivider = 200;

            Console.WriteLine("Rating LIFE policy...");
            Console.WriteLine("Validating policy.");

            if (ValidatePolicy() == false) return;

            int age = Helpers.CalculateAge(this.DateOfBirth);

            decimal baseRate = this.Amount * age / _baseLifeRatingDivider;
            if (this.IsSmoker)
            {
                Rating = baseRate * _smokerMultiplier;
                return;
            }
            Rating = baseRate;
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
    }
}
