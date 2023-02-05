using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math_Calculator_App
{
    //This class is implemented polymorphism
    class Calculation : Program
    {
        public static double avrg;
        public static double pyta_max;
        public static double pyta_min;
        public virtual void Calculate(string input)
        {
            Console.WriteLine(input);
        }
        //this method is for getting average num
        public double Av_his()
        {
            return avrg;
        }
        //this method is for getting pytagoras max num
        public double Pyta_max_his()
        {
            return pyta_max;
        }
        //this method is for getting pytagoras min num
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
}
