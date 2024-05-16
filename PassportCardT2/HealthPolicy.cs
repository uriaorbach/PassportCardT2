using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRating;

namespace PassportCardT2
{
    public class HealthPolicy : IPolicy
    {
      
        public PolicyType PolicyType { get; } = PolicyType.Health;
        public string? Gender { get; set; }
        public decimal Deductible { get; set; }
        public string? FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Rating { get; set; }


        public void Rate()
        {
            Console.WriteLine("Rating HEALTH policy...");
            Console.WriteLine("Validating policy.");
            if (ValidatePolicy() == false) return;

            if (this.Gender == "Male")
            {
                if (this.Deductible < 500)
                {
                    Rating = 1000m;
                }
                Rating = 900m;
            }
            else
            {
                if (this.Deductible < 800)
                {
                    Rating = 1100m;
                }
                Rating = 1000m;
            }
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
    }
}
