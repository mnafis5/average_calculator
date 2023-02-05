using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Npgsql;


namespace Math_Calculator_App
{
    internal class Program
    {
        static void Main(string[] args)
        {           
            Console.WriteLine("WELCOME TO THE AVE APP!");
            Console.WriteLine("***********************");
            Console.WriteLine("This is an app for calculating a collection of numbers. Made by MNafisdh.");
            Console.WriteLine("1. Average Calculation");
            Console.WriteLine("2. Pytagoras Calculation");
            Console.WriteLine("3. History");
            Console.WriteLine("4. Exit");
            Db_connection db = new Db_connection();          
            while (true)
            {
              //  Console.Write("As user or guest:");
              //  string su = Console.ReadLine();  
                Console.Write("Guest>>");
                var choice = Convert.ToInt32(Console.ReadLine());
                //handling the input
                switch(choice)
                {
                    case 1:
                        Console.Write("Guest>>average>>");
                        string av_inp = Console.ReadLine(); //input numbers for average
                        Calculation average = new Average(); //inisializing an object
                        average.Calculate(av_inp); //calculating input numbers
                        double av_his = average.Av_his(); //get the average num from class Average
                        var av_out = av_inp + " = " + Convert.ToString(av_his); //history variable for storing data
                        // histories.Add(new History { Average = av_out });  store to list history
                        db.Db_Insert(av_out);
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
                            db.Db_Insert(py_out);
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
                            db.Db_Insert(py_out);
                        }
                        break;
                    case 3:
                        Console.WriteLine("the List of inputten numbers and the results: ");
                        Console.WriteLine("To clear history input DELETE,to exit input EXIT.");
                        Console.WriteLine(".............................................");
                        Console.Write("No|History\t\t|Created_at\n");

                        db.Db_retrieve();
                        Console.Write("Guest>>History>>");
                        string delete = Console.ReadLine();                       
                        if(delete == "DELETE")
                        {
                        db.Db_Delete();
                        }else if(delete == "EXIT")
                        {
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine("wrong input");
                        }
                        break;
                        
                    case 4:
                        Console.WriteLine("See you again, bye!");
                        Environment.Exit(0);
                        break;
                    
                    default: 
                        Console.WriteLine("input invalid");
                        break;
                }
              
            }
        }

        
       

    }
}