/* 
DT071G - Moment 2
Lösning av Linus Hvenfelt
Använder följande algoritm: https://www.interactive-maths.com/uploads/1/1/3/4/11345755/zellers_algorithm.pdf
*/

using System;

namespace moment2
{
    class Program
    {
        static void Main(string[] args)
        {
            // dotnet run
            Console.Clear();
            Console.WriteLine("Let's find out what weekday you were born!");
            Console.WriteLine("\nWhat is your DOB? Example: 1998-02-09");
            var dob = Console.ReadLine();
            Filterme(dob);

            void Filterme(string data) {
                if (data.Length != 10) {
                    Console.Clear();
                    Console.WriteLine("\n Bad input. Did you write it the correct way? Example: 1995-05-15");
                    Filterme(Console.ReadLine());
                } else {
                    task(data);
                }
            }

            void task(string dob) {
                try {
                string[] dobs = dob.Split("-");

                // If date is 1998-02-09, these variables show the following:
                var c = Int32.Parse(dob.Substring(0, 2)); // 19
                var k = Int32.Parse(dob.Substring(2, 2)); // 98
                var y = Int32.Parse(dobs[0]); // 1998
                var m = Int32.Parse(dobs[1]); // 02
                var d = Int32.Parse(dobs[2]); // 09

                // TODO: Check if string is 10 or 8 characters long
                // Check if year is 
                // Check if month =< 12 

                if (m < 3) { // If M is 1 or 2
                    m = m + 12; // add 12 to M
                    y--; // and subtract 1 from Y.
                }

                var result1 = Math.Floor(2.6 * m - 5.39); // Add together the integer parts of (2.6M—5.39)
                var result2 = Math.Floor((double)k / 4); // k/4
                var result3 = Math.Floor((double)c / 4); // and c/4

                double summa = (result1 + result2 + result3 + d + k) - 2 * c; // Add to this D and K, and subtract 2C. 
                //Console.WriteLine($"\nSumman är är: {summa}");
                double veckodag = summa % 7; // Find the remainder when this number is divided by 7
                //Console.WriteLine($"\nVeckodagen är: {veckodag}");

                string veckodagen = "";
                switch (veckodag)
                {
                    case 1:
                    veckodagen = "monday";
                    break;

                    case 2:
                    veckodagen = "tuesday";
                    break;

                    case 3:
                    veckodagen = "wednesday";
                    break;

                    case 4:
                    veckodagen = "thursday";
                    break;

                    case 5:
                    veckodagen = "friday";
                    break;

                    case 6:
                    veckodagen = "saturday";
                    break;

                    case 0:
                    veckodagen = "sunday";
                    break;

                    default:
                    break;
                }

                Console.WriteLine($"\nYou were born on a {veckodagen}!");
                Console.Write("\nPress any key to exit...");
                Console.ReadKey(true);

                } catch(Exception error) {
                    throw error;
                }
            }

        }
    }
}
