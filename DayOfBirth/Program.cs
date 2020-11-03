using System;

namespace DayOfBirth
{
    class Program
    {
        public static string inputDate;
        public static DateTime dateOfBirth;


        static bool ValidateInput()
        {
            DateTime result;

            if (DateTime.TryParse(inputDate, out result))
            {
                dateOfBirth = DateTime.Parse(inputDate);
                return true;
            }
            Console.WriteLine("Wrong date format");

            return false;
        }

        static void Main(string[] args)
        {
            while (!ValidateInput())
            {
                Console.WriteLine("Birthdate?(yyyy.mm.dd)");
                inputDate = Console.ReadLine();
            }

            // Algorithm to get day
            Console.WriteLine(dateOfBirth.Day + " " + dateOfBirth.Month + " " + dateOfBirth.Year);
        }
    }
}
