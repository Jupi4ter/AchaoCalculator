using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace ConsoleApplication2
{
    class Program
    {
        public static char[] op = { '+', '-', '*', '/' };

        public static void Main(string[] args)
        {
            print();
        }

        public static string MakeFormula()
        {
            string biuld = null;
            Random rd = new Random();
            int number1 = (int)rd.Next(0, 101);
            int count = (int)rd.Next(2, 4);
            biuld = biuld + number1;

            for (int i = 0; i < count; i++)
            {
                int number2 = (int)rd.Next(0, 101);
                int operation = (int)rd.Next(0, 4);
                biuld = biuld + op[operation] + number2;
            }

            return biuld;
        }

        public static string Solve(string formula)
        {
            DataTable dt = new DataTable();
            object ob = dt.Compute(formula, "");
            while (ob.ToString().Contains("."))
            {
                formula = MakeFormula();
                ob = dt.Compute(formula, "");
            }
            return formula + "=" + ob.ToString();

        }
        public static void print()
        {
            int len = 0;
            string finalResult = null;

            len = int.Parse(Console.ReadLine());
            for (int i = 0; i < len; i++)
            {
                finalResult = finalResult + Solve(MakeFormula()) + "\n";
                System.Threading.Thread.Sleep(50);
            }
            Console.WriteLine(finalResult);
            

        }


    }


}
