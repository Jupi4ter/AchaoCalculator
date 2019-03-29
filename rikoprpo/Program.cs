using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
namespace ConsoleApp3
{
    public class Program
    {

       
       
        public static string Solve(string a)
        {
            DataTable dt = new DataTable();

            Object ob;

            ob = dt.Compute(a, "");

            while (ob.ToString().Contains(".") || a.Contains("/0") || Convert.ToInt32(ob) < 0)
            {
                a = suanfa();
                ob = dt.Compute(a, "");
            }
            return a + "=" + ob.ToString();
        }
        public static string suanfa()
        {
            StringBuilder sb = new StringBuilder();

            String[] smbl = { "+", "-", "*", "/" };

            var seed = Guid.NewGuid().GetHashCode();

            Random sd = new Random(seed);

            int count = sd.Next(1, 3);

            int start = 0;

            int num1 = sd.Next(0, 101);

            sb.Append(num1);

            while (start <= count)
            {
                int operation = sd.Next(0, 4);
                int number2 = sd.Next(0, 101);
                sb.Append(smbl[operation]).Append(number2);
                start++;
            }
            return sb.ToString();

        }
        public static void Main(string[] args)
        {
            
            int s;

            Console.WriteLine("Please Input How Many exercise do you want to:");

            s = int.Parse(Console.ReadLine());

            StreamWriter lh = new StreamWriter(@"D:\英雄时刻\liuhao\subject.txt");

            for (int i = 0; i < 1000000; i++)
            {
                string a = suanfa();
                String ret = Solve(a);
                Console.WriteLine(ret);

                lh.WriteLine(ret);

                a = null;
                ret = null;
            }
            lh.Close();
           
        }
    }
}
