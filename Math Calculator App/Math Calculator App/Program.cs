using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Math_Calculator_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var histories = new List<History>();
           
            while (true)
            {
                Console.WriteLine("WELCOME TO THE AVE APP!");
                Console.WriteLine("***********************");
                Console.WriteLine("This is an app for calculating a collection of numbers. Made by MNafisdh.");

                Console.WriteLine("1. Average Calculation");
                Console.WriteLine("2. Pytagoras Calculation");
                Console.WriteLine("3. History");
                Console.WriteLine("4. Save");
                Console.WriteLine("5. Exit");
                Console.Write("Guest>>");

                var choice = Convert.ToInt32(Console.ReadLine());
                //ndling the input
                switch (choice)
                {
                    case 1:
                        Console.Write("Guest>>average>>");
                        string av_inp = Console.ReadLine();
                        Calculation average = new Average();
                        average.Calculate(av_inp);
                        double av_his = average.Av_his();
                        var av_out = av_inp + " = " + Convert.ToString(av_his);
                        histories.Add(new History { Average = av_out });

                        break;
                    case 2:
                        Console.WriteLine("1. Determine the longest line");
                        Console.WriteLine("2. Determine the normal line");
                        Console.Write("Guest>>Pytagoras>>");
                        int py_inp = Convert.ToInt32(Console.ReadLine());
                        if (py_inp == 1)
                        {
                            Calculation pytagoras = new Pytagoras();
                            Console.Write("Guest>>Pytagoras>>long>>");
                            string inp_py = Console.ReadLine();
                            pytagoras.Calculate(inp_py);
                            double py_max_inp_his = Convert.ToDouble(inp_py);
                            double py_his = pytagoras.Pyta_max_his();
                            string py_out = inp_py + " = " + Convert.ToString(py_his);
                            histories.Add(new History { Pytagoras = py_out });
                        }
                        else
                        {
                            Pytagoras pytagoras1 = new Pytagoras();
                            Console.Write("Guest>>Pytagoras>>normal>>");
                            string inp_py = Console.ReadLine();
                            pytagoras1.Reverse_Calculate(inp_py);
                            double py_max_inp_his = Convert.ToDouble(inp_py);
                            double py_his = pytagoras1.Pyta_min_his();
                            string py_out = inp_py + " = " + Convert.ToString(py_his);
                            histories.Add(new History { Pytagoras_min = py_out });
                        }
                        break;
                    case 3:
                        Console.WriteLine("the List of inputten numbers and the results: ");
                        Console.WriteLine(".............................................");               
                            foreach (var history in histories)
                            {
                                Console.Write($"{history.Average}\n{history.Pytagoras}\n{history.Pytagoras_min}");
                            }                     
                        break;
                    case 4:
                        Console.Write("Input filename: ");
                        string input = Console.ReadLine();
                        File_ save = new File_(input);
                        break;
                    case 5:
                        Console.WriteLine("See you again, bye!");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("input invalid");
                        break;
                }





            }
        }

        class Calculation
        {
            public static double avrg;
            public static double pyta_max;
            public static double pyta_min;
            public virtual void Calculate(string input)
            {
                Console.WriteLine(input);
            }

            public double Av_his()
            {
                return avrg;
            }

            public double Pyta_max_his()
            {
                return pyta_max;
            }

            public double Pyta_min_his()
            {
                return pyta_min;
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

                avrg = num;
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
                double res = (int)Math.Sqrt(numbers[0] * numbers[0] + numbers[1] * numbers[1]);
                res = Math.Round(res, 4);

                pyta_max = res;
                Console.WriteLine(res + " cm");
            }

            public void Reverse_Calculate(string input)
            {
                string[] slice = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                //convert to int and array
                double[] numbers = slice.Select(x => Convert.ToDouble(x)).ToArray();

                //output
                double res = Math.Sqrt(numbers[0] * numbers[0] - numbers[1] * numbers[1]);
                res = Math.Round(res, 4);

                pyta_min = res;
                Console.WriteLine(res + " cm");
            }


        }

        class History
        {
            public string Average { get; set; }
            public string Pytagoras { get; set; }
            public string Pytagoras_min { get; set; }
        }

        class File_ : History
        {
            public static string filename;
            public File_(string input)
            {
                //input the input filename variable
                filename = input;

                //Join the History properties
                string text = $"{Average}\n{Pytagoras}\n{Pytagoras_min}";

                //Write to the file
                if (filename != null)
                {
                    if (text.Length > 0)
                    {
                        using (var writer = new StreamWriter(filename+".txt"))
                        {
                            writer.Write(text);
                        }
                        Console.WriteLine("Data saved");
                    }
                    else
                    {
                        Console.WriteLine("No data stored");
                    }
                }
                else
                {
                    Console.WriteLine("Input the filename first!");
                }

            }

            

            

        }



    }
}