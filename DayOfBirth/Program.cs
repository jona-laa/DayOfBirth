using System;

namespace DayOfBirth
{
    class Program
    {
        public static string inputDate;
        public static DateTime dateOfBirth;



        static void GetInput() 
        {
            Console.WriteLine("What is your birthdate? (yyyy.mm.dd)");
            inputDate = Console.ReadLine();
        }



        static bool ValidateInput()
        {
            DateTime result;

            if (DateTime.TryParse(inputDate, out result))
            {
                dateOfBirth = DateTime.Parse(inputDate);
                return true;
            }

            Console.WriteLine("\nWrong format. Try again!");  
            return false;
        }



        static void GetDayOfBirth()
        {            
            int century = dateOfBirth.Year / 100;
            int year = dateOfBirth.Year % 100;
            int month = dateOfBirth.Month;
            int day = dateOfBirth.Day;
            int weekdayIndex;
            string weekday;

            if (month < 3) {
                month = month + 12;
                year = year - 1;
            }

            // Zeller's Magic Formula
            weekdayIndex = (day + ((13*(month+1))/5) + year + (year/4) + (century/4) + 5*century ) % 7;
            
            // Get Weekday Name
            weekday = Enum.GetName(typeof(DayOfWeek), weekdayIndex -1);

            Console.WriteLine("{0} is a {1}",dateOfBirth.ToShortDateString(), weekday);
        }



        static void Main(string[] args)
        {
            GetInput();

            // Ask for Input Until Valid
            while (!ValidateInput())
            {
                GetInput();
            }

            GetDayOfBirth();
        }
    }
}
