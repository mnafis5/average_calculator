using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
//Make a CLI application that outputs the average of data or numbers

//when running the application, the first content that displays on the screen should be an opening text.
//enter the numbers!
//the output
//below the output, there is an alert warning about the continuation from the user

namespace Cs_project
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
             Console.WriteLine("WELCOME TO THE AVE APP!");
             Console.WriteLine("***********************");
             Console.WriteLine("This is an app for calculating a collection of numbers. Made by MNafisdh.");

             Console.WriteLine("1. Average Calculation");
             Console.WriteLine("2. Pytagoras Calculation");
             Console.Write("Guest>>");
             int choice = Convert.ToInt32(Console.ReadLine());
             //handling the input
            if(choice == 1)
            {
             string av_inp = Console.ReadLine();
             Calculation average = new Average();
             average.Calculate(av_inp);
            }else if(choice == 2)
            {
             Console.WriteLine("1. Determine the longest line");
             Console.WriteLine("2. Determine the normal line");
             int py_inp = Convert.ToInt32(Console.ReadLine());
             if(py_inp == 1)
             {
                Calculation pytagoras = new Pytagoras();
                string inp_py = Console.ReadLine();
                pytagoras.Calculate(inp_py);
             }else{
                Pytagoras pytagoras1 = new Pytagoras();
                string inp_py = Console.ReadLine();
                pytagoras1.Reverse_Calculate(inp_py);
             }

            }else{
                Console.WriteLine("input invalid");
            }
             Console.Write("Do you want to continue(y/n)...");
             string conss = Console.ReadLine();
             if (conss == "n")
             {
                break;
             }
            }

        }
        class Calculation
        {
            public virtual void Calculate(string input)
            {
                Console.WriteLine(input);
            }
        }
         class Average : Calculation
         {
            public override void Calculate(string input)
            {
             //split the coma and convert to char
             string[] slice = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            
             //convert to int and array
             double[] numbers = slice.Select(x => Convert.ToDouble(x)).ToArray();

             //output
             double num = numbers.Sum() / numbers.Length;
             Console.WriteLine("The average is" + "  " + num);
             Console.WriteLine($"Sum: {numbers.Sum()}");
             Console.WriteLine($"Count: {numbers.Length}");
             Console.WriteLine($"Largest: {numbers.Max()}");
             Console.WriteLine($"Smallest: {numbers.Min()}");
            }
         }

         class Pytagoras : Calculation
         {
            public override void Calculate(string input)
            {
             string[] slice = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            
             //convert to int and array
             double[] numbers = slice.Select(x => Convert.ToDouble(x)).ToArray();

             //output
             double num = Math.Pow(numbers[0],2) + Math.Pow(numbers[1],2);
             double res = Math.Sqrt(num);

             Console.WriteLine(res + " cm");
            }

            public void Reverse_Calculate(string input)
            {
             string[] slice = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            
             //convert to int and array
             double[] numbers = slice.Select(x => Convert.ToDouble(x)).ToArray();

             //output
             double num = Math.Pow(numbers[0],2) - Math.Pow(numbers[1],2);
             double res = Math.Sqrt(num);

             Console.WriteLine(res + " cm");
            }
         }
    }
}