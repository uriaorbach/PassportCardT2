namespace PassportCardT2.Utils
{
    public static class Helpers
    {
        public static int CalculateAge(DateTime birthDay)
        {
            var age = DateTime.Today.Year - birthDay.Year;

            if (IsBirthdayNotYetOccurredThisYear(birthDay))
            {
                age--;
            }

            return age;
        }
        private static bool IsBirthdayNotYetOccurredThisYear(DateTime birthDay)
        {
            return (birthDay.Month == DateTime.Today.Month &&
               DateTime.Today.Day < birthDay.Day) ||
               DateTime.Today.Month < birthDay.Month;
        }
    }
}
