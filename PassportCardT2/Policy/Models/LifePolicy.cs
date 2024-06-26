﻿using PassportCardT2.Enums;
using PassportCardT2.IO;
using PassportCardT2.Utils;

namespace PassportCardT2.Policy.Models
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
            Logger.WriteLine("Rating LIFE policy...");
            Logger.WriteLine("Validating policy.");

            if (ValidatePolicy() == false) return Rating;

            var age = Helpers.CalculateAge(DateOfBirth);
            var baseRate = CalculateBaseRate(age);
            var finalRate = ApplySmokerMultiplier(baseRate, IsSmoker);

            Rating = finalRate;
            return Rating;
        }

        private bool ValidatePolicy()
        {
            const int _maxEligibleCoverageAge = 100;

            var age = Helpers.CalculateAge(DateOfBirth);

            if (DateOfBirth == DateTime.MinValue)
            {
                Logger.WriteError("Life policy must include Date of Birth.");
                return false;
            }
            if (age > _maxEligibleCoverageAge)
            {
                Logger.WriteError($"Max eligible age for coverage is {_maxEligibleCoverageAge} years.");
                return false;
            }
            if (Amount == 0)
            {
                Logger.WriteError("Life policy must include an Amount.");
                return false;
            }
            return true;
        }

        private decimal CalculateBaseRate(int age)
        {
            return Amount * age / _baseLifeRatingDivider;
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
