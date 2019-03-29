using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, c, ans = 0;
            char p1, p2;
            string[] s = Console.ReadLine().Split(' ');
            a = int.Parse(s[0]);
            p1 = char.Parse(s[1]);
            b = int.Parse(s[2]);
            p2 = char.Parse(s[3]);
            c = int.Parse(s[4]);
            if ((p1 == '*' || p1 == '/') && (p2 == '*' || p2 == '/'))
            {
                if (p1 == '*')
                    ans = a * b;
                else if (p1 == '/')
                    ans = a / b;
                if (p2 == '*')
                    ans = ans * c;
                else if (p2 == '/')
                    ans = ans / c;
            }
            else if ((p1 != '*' && p1 != '/') && (p2 == '*' || p2 == '/'))
            {
                if (p2 == '*')
                    ans = b * c;
                else if (p2 == '/')
                    ans = b / c;
                if (p1 == '+')
                    ans = ans + a;
                else if (p1 == '-')
                    ans = ans - a;
            }
            else
            {
                if (p1 == '+')
                    ans = a + b;
                else if (p1 == '-')
                    ans = a - b;
                else if (p1 == '*')
                    ans = a * b;
                else if (p1 == '/')
                    ans = a / b;
                if (p2 == '+')
                    ans = ans + c;
                else if (p2 == '-')
                    ans = ans - c;

            }
            Console.WriteLine("{1}+{2}+{3}+{4}+{5}+{6}",a,p1,b,p2,c,ans);
            Console.ReadLine();
        }
    }
}