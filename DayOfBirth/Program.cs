using System;

namespace DayOfBirth
{
    class Program
    {
        public static string inputDate;
        public static DateTime dateOfBirth;



        static void GetInput() 
        {
            Console.WriteLine("What is your birth date? (yyyy.mm.dd)");
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



        // Get Week day Index
        static int GetWeekdayIndex(int day, int month, int year, int century) => (day + ((13*(month+1))/5) + year + (year/4) + (century/4) + 5*century ) % 7;



        // Get Week day Name
        static string GetWeekdayName(int weekdayIndex) => Enum.GetName(typeof(DayOfWeek), weekdayIndex -1);



        static void GetDayOfBirth()
        {            
            int century = dateOfBirth.Year / 100;
            int year = dateOfBirth.Year % 100;
            int month = dateOfBirth.Month;
            int day = dateOfBirth.Day;

            if (month < 3) {
                month = month + 12;
                year = year - 1;
            }       

            Console.WriteLine($"{dateOfBirth.ToShortDateString()} is a {GetWeekdayName(GetWeekdayIndex(day, month, year, century))}");
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
