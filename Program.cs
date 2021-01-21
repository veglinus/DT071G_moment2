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
            Console.WriteLine("\nWhat is your date of birth? Example: 1998-02-09");
            var userInput = Console.ReadLine();
            Filter(userInput);

            void Filter(string data)
            {
                try
                {
                    DateTime dateTime;
                    if (!DateTime.TryParse(data, out dateTime) || data.Length != 10)
                    { // Test if it compiles to DateTime & checks length
                        Console.Clear();
                        Console.WriteLine("\n Bad input. Did you write it the correct way? Example: 1995-05-15");
                        Filter(Console.ReadLine());
                    }
                    else
                    {

                        string[] dobs = data.Split("-");
                        var c = Int32.Parse(data.Substring(0, 2)); // 19
                        var k = Int32.Parse(data.Substring(2, 2)); // 98
                        var year = Int32.Parse(dobs[0]); // 1998
                        var month = Int32.Parse(dobs[1]); // 02
                        var day = Int32.Parse(dobs[2]); // 09

                        if (month > 12 || month == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("\n Bad input. The month is wrong. Example: 1995-05-15");
                            Filter(Console.ReadLine());
                        }
                        else if (day > 31 || day == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("\n Bad input. The day is wrong. Example: 1995-05-15");
                            Filter(Console.ReadLine());
                        }
                        else if (dobs[0].Length != 4)
                        {
                            Console.Clear();
                            Console.WriteLine("\n Bad input. Write out the entire year. Example: 1995-05-15");
                            Filter(Console.ReadLine());
                        }
                        else if (dobs[1].Length != 2 || dobs[2].Length != 2)
                        {
                            Console.Clear();
                            Console.WriteLine("\n Bad input. Write out the entire month/day with 2 letters. Example: 1995-05-15");
                            Filter(Console.ReadLine());
                        }
                        else
                        {
                            task(data);
                        }
                    }

                }
                catch (System.Exception)
                { // In case of exception, just try again
                    Console.Clear();
                    Console.WriteLine("\n Bad input. Did you write it the correct way? Example: 1995-05-15");
                    Filter(Console.ReadLine());
                }
            }

            void task(string dateOfBirth)
            {
                try
                {
                    string[] dateOfBirthArray = dateOfBirth.Split("-");

                    // If date is 1998-02-09, these variables show the following:
                    var year = Int32.Parse(dateOfBirthArray[0]); // 1998
                    var month = Int32.Parse(dateOfBirthArray[1]); // 02
                    var day = Int32.Parse(dateOfBirthArray[2]); // 09

                    if (month < 3)
                    { // If M is 1 or 2
                        month += 12; // add 12 to M
                        year--; // and subtract 1 from Y.
                    }

                    var c = Math.Floor((double)year / 100); // Two first digits of year
                    var k = year - (100 * c); // Two last digits of year

                    var result1 = Math.Floor(2.6 * month - 5.39); // Add together the integer parts of (2.6M—5.39)
                    var result2 = Math.Floor((double)k / 4); // k/4
                    var result3 = Math.Floor((double)c / 4); // and c/4

                    result1 = Convert.ToInt32(result1); // Converts double to int, removing the decimals
                    result2 = Convert.ToInt32(result2);
                    result3 = Convert.ToInt32(result3);

                    double sum = (result1 + result2 + result3 + day + k) - (2 * c); // Add to this D and K, and subtract 2C. 
                    //Console.WriteLine($"\nSumman är är: {summa}");

                    //Console.WriteLine(sum);
                    double weekday = sum - (7 * Math.Floor(sum / 7)); // Find the remainder when this number is divided by 7
                    //Console.WriteLine($"\nVeckodagen är: {veckodag}");

                    string weekdayOutput = "";
                    switch (weekday)
                    {
                        case 1:
                            weekdayOutput = "monday";
                            break;

                        case 2:
                            weekdayOutput = "tuesday";
                            break;

                        case 3:
                            weekdayOutput = "wednesday";
                            break;

                        case 4:
                            weekdayOutput = "thursday";
                            break;

                        case 5:
                            weekdayOutput = "friday";
                            break;

                        case 6:
                            weekdayOutput = "saturday";
                            break;

                        case 0:
                            weekdayOutput = "sunday";
                            break;

                        default:
                            break;
                    }

                    Console.WriteLine($"\nYou were born on a {weekdayOutput}!");
                    Console.Write("\nPress any key to exit...");
                    Console.ReadKey(true);

                }
                catch (Exception error)
                {
                    throw error;
                }
            }

        }
    }
}
