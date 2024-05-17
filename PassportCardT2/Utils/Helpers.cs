using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassportCardT2.Utils
{
    public static class Helpers
    {
        public static int CalculateAge(DateTime birthDay)
        {
            int age = DateTime.Today.Year - birthDay.Year;

            if (IsBirthdayNotYetOccurredThisYear(birthDay))
            {
                age--;
            }

            return age;
        }
        private static bool IsBirthdayNotYetOccurredThisYear(DateTime birthDay)
        {
            return birthDay.Month == DateTime.Today.Month &&
               DateTime.Today.Day < birthDay.Day ||
               DateTime.Today.Month < birthDay.Month;
        }
    }
}
