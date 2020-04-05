using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorytmyZajecia05042020
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Podaj liczbe wyrazow ciagu");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"\n\tIteracyjnie obliczona liczba wyrazow ciagu podczas sumowania liczb naturalnych != 0 od 1 do {choice} (wlacznie)");
            Console.Write("\n\t\t\t\t\t");
            SumaIteracyjnie(choice);
            Console.WriteLine();


            Console.WriteLine("\tTa sama suma wykonana rekurencyjnie:");
            Console.Write("\n\t\t\t\t\t");
            int rekRez = SumaRekurencyjnie(choice);
            Console.WriteLine(rekRez);
            using (StreamWriter file = new StreamWriter(@"SumaRekurencyjnie.txt", true))
            {
                file.WriteLine("{0}\t{1}", choice, rekRez);
            }


            Console.WriteLine("\n\tPliki z wynikami zostana teraz otworzone:");
            Process.Start("cmd.exe", "/C start SumaRekurencyjnie.txt && start SumaIteracyjnie.txt");


            Console.WriteLine($"\n\n\tTeraz zostana zsumowane tylko liczby parzyste w zakresie od 1 do {choice}, jak wybrano wczesniej");
            Console.WriteLine("\t\t\t\t\tIteracyjnie");
            Console.WriteLine("\t\t\t\t\t" + SumaParzystych_Iteracyjnie(choice));
            Console.WriteLine("\n\t\t\t\t\tRekurencyjnie");
            Console.WriteLine("\t\t\t\t\t" + SumaParzystych_Rekurencyjnie(choice));


            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\t\t\t\t\tEsc wylacza.");
            ConsoleKey quiting;
            do
            {
                quiting = Console.ReadKey(true).Key;

            } while (quiting != ConsoleKey.Escape);
        }

        private static int SumaParzystych_Rekurencyjnie(int input)
        {
            if (input < 1)
            {
                return 0;
            }

            if (input %2 != 0)
            {
                input = input - 1;
            }
            
                return input + SumaParzystych_Rekurencyjnie(input - 2);
        }

        private static int SumaParzystych_Iteracyjnie(int choice)
        {
            int suma = 0;
            for (int i = 1; i <= choice; i++)
            {
                if (i%2==0)
                suma += i;
            }

            return suma;
        }

        private static int SumaRekurencyjnie(int input)
        {
            if (input < 1)
            {
                return 0;
            }
            else
            {
                return input + SumaRekurencyjnie(input - 1);
            }

        }

        private static void SumaIteracyjnie(int liczbaLiczbNaturalnychRoznychOdZeraDoZsumowania)
        {
            int suma = 0;
            for (int i = 1; i <= liczbaLiczbNaturalnychRoznychOdZeraDoZsumowania; i++)
            {
                suma += i;
            }

            Console.WriteLine(suma);
            using (StreamWriter file = new StreamWriter(@"SumaIteracyjnie.txt", true))
            {
                file.WriteLine("{0}\t{1}", liczbaLiczbNaturalnychRoznychOdZeraDoZsumowania, suma);
            }
        }
    }
}
