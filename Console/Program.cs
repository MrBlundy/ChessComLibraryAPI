using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessComLibraryAPI;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            for (int i = 0; i < 100; i++)
            {
                random = new Random(random.Next(1000));
                System.Console.WriteLine(random.Next(1000));
            }


            //blah();
        }

        static async void blah()
        {
            var availMonths =  await ChessAPI.GetAvailableMonthlyArchivesAsync("hikaru");
            System.Console.WriteLine();

        }
    }
}
