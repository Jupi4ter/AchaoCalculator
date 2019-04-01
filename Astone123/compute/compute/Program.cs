using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace compute
{
   
    public class Program
    {
        
        static void Main(string[] args)
        {
            int a, b,c,z;
            string[] va;
            Console.Write("请输入打印题目提数：");
            int n =Convert.ToInt16(Console.ReadLine());
            Random rad = new Random();
            using (StreamWriter sw2 = new StreamWriter(@"F:\vs\github\AchaoCalculator\Astone123\Answer.txt", true))
            using (StreamWriter sw = new StreamWriter(@"F:\vs\github\AchaoCalculator\Astone123\Exercises.txt", true))
            {
                for (int i = 0; i < n; i++)
                {
                    a = rad.Next(1, 101);
                    b = rad.Next(1, 101);
                    c = rad.Next(1, 101);
                    z = rad.Next(1, 5);
                    Calculation ca = new Calculation(a, b, c);
                    va = ca.Getcalculate(z).Split('!');
                    sw.WriteLine(va[0]);
                    sw2.WriteLine(va[1]);
                }
               
            }
            Console.ReadLine();
        }
    }
}
