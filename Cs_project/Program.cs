//Make a CLI application that outputs the average of data or numbers

//when running the application, the first content that displays on the screen should be an opening text.
//enter the numbers!
//the output
//below the output, there is an alert warning about the continuation from the user
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Cs_project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO THE AVE APP!");
            Console.WriteLine("***********************");
            Console.WriteLine("This is an app for calculating the average in a collection of numbers. Made by MNafisdh.");

            Console.Write("Input some numbers here:");
            //handling the input
            Calculate();

            Console.Write("Do you want to continue(y/n)...");
            char ctn = Convert.ToChar(Console.ReadLine());
            string[,] stroke = { {"|_"}, {"_|"} };
            if (ctn == 'y')
            {
                Console.Write("Input some numbers here:");
                Calculate();
            }else
            {
                Console.WriteLine("Bye!");
               foreach (string item in stroke)
               {
                  Console.Write(item);
                  Console.Write(item);
                  Console.WriteLine(item);
                  Console.Write(item);
                  Console.Write(item);
               }
            }

        }
        static void Calculate()
        {
             string input = Console.ReadLine();
            //split the coma and convert to char
            string[] slice = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            
            //convert to int and array
            double[] numbers = slice.Select(x => Convert.ToDouble(x)).ToArray();

            //output
            string output = "The average is:";
            double num = numbers.Sum() / numbers.Length;
            Console.WriteLine(output + " " + num);
            Console.WriteLine($"Sum: {numbers.Sum()}");
            Console.WriteLine($"Count: {numbers.Length}");
            Console.WriteLine($"Largest: {numbers.Max()}");
            Console.WriteLine($"Smallest: {numbers.Min()}");
        }
    }
}