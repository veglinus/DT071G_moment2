using System;

namespace moment2
{
    class Program
    {
        static void Main(string[] args)
        {
            // dotnet run
            Console.WriteLine("Let's find out what weekday you were born!");

            Console.WriteLine("\nWhat is your DOB? Example: 1998-02-09");
            var dob = Console.ReadLine();

            string[] dobs = dob.Split("-");

            // TODO: Check if string is 10 or 8 characters long
            // Check if year is 
            // Check if month =< 12 

            var c = Int32.Parse(dob.Substring(0, 2));
            var y = Int32.Parse(dobs[0]);
            var m = Int32.Parse(dobs[1]);
            var d = Int32.Parse(dobs[2]);

            if (m < 3) {
                m = m + 12;
            }
            //y++;

            var veckodag = (d + ((13*(m+1))/5) + y + (y/4) + (c/4) + 5*c ) % 7;
            string veckodagen = "";

            //veckodag--;

            switch (veckodag)
            {
                case 0:
                veckodagen = "måndag";
                break;

                case 1:
                veckodagen = "tisdag";
                break;

                case 2:
                veckodagen = "onsdag";
                break;

                case 3:
                veckodagen = "torsdag";
                break;

                case 4:
                veckodagen = "fredag";
                break;

                case 5:
                veckodagen = "lördag";
                break;

                case 6:
                veckodagen = "lördag";
                break;

                default:
                break;
            }

            Console.WriteLine($"\nVeckodagen du föddes är: {veckodagen}");





/*
            var year = Int32.Parse(dobs[0]);
            var month = Int32.Parse(dobs[1]);
            var day = Int32.Parse(dobs[2]);
            Console.WriteLine($"\n{year}-{month}-{day}");

            if (month < 3) {
                month = month + 12;
            }
            year++;

            double insertyear = year / 100; 
            var talet = Math.Floor(insertyear);
            //Console.WriteLine($"\n{talet}");
            int century = year % 100;

            // Hitta veckodag då seklet började genom nedanstående operation.
            var dayOfWeek = Math.Floor(talet / 4) + 5 * talet;


            //Beräkna veckodag året började på enligt nedan.
            var DayOfWeek = dayOfWeek + c + Math.Floor(c / 4);
*/


            //Console.WriteLine($"\nHello, {dob}");
            Console.Write("\nPress any key to exit...");
            Console.ReadKey(true);
        }
    }
}
