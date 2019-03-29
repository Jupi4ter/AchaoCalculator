using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace 四则运算
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = @"C:\1111\1.txt";
            string answer = @"C:\1111\2.txt";
            Random sj = new Random();
            char[] fh = { '+', '-', '*', '/' };
            char a, b, c;
            StreamWriter ss = new StreamWriter(filename, true);
            StreamWriter aa = new StreamWriter(answer, true);
            int x;
            int[] num = new int[4];
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int fhs = sj.Next(2, 4);

                if (fhs == 2)
                {
                    num[0] = sj.Next(0, 101);
                    num[1] = sj.Next(0, 101);
                    num[2] = sj.Next(0, 101);
                    ss.Write(num[0].ToString(), Encoding.UTF8);
                    a = fh[sj.Next(0, 4)];
                    ss.Write(a);
                    ss.Write(num[1].ToString(), Encoding.UTF8);
                    b = fh[sj.Next(0, 4)];
                    ss.Write(fh[sj.Next(0, 4)]);
                    ss.Write(num[2].ToString(), Encoding.UTF8);
                    ss.WriteLine("=");
                    switch (a)
                    {
                        case '+':
                            switch (b)
                            {
                                case '+':
                                    x = num[0] + num[1] + num[2];
                                    aa.WriteLine(x);
                                    break;
                                case '-':
                                    x = num[0] + num[1] - num[2];
                                    aa.WriteLine(x);
                                    break;
                                case '*':
                                    x = num[0] + num[1] * num[2];
                                    aa.WriteLine(x);
                                    break;
                                case '/':
                                    x = num[0] + num[1] / num[2];
                                    aa.WriteLine(x);
                                    break;
                            }
                            break;
                        case '-':
                            switch (b)
                            {
                                case '+':
                                    x = num[0] - num[1] + num[2];
                                    aa.WriteLine(x);
                                    break;
                                case '-':
                                    x = num[0] - num[1] - num[2];
                                    aa.WriteLine(x);
                                    break;
                                case '*':
                                    x = num[0] - num[1] * num[2];
                                    aa.WriteLine(x);
                                    break;
                                case '/':
                                    x = num[0] - num[1] / num[2];
                                    aa.WriteLine(x);
                                    break;
                            }
                            break;
                        case '*':
                            switch (b)
                            {
                                case '+':
                                    x = num[0] * num[1] + num[2];
                                    aa.WriteLine(x);
                                    break;
                                case '-':
                                    x = num[0] * num[1] - num[2];
                                    aa.WriteLine(x);
                                    break;
                                case '*':
                                    x = num[0] * num[1] * num[2];
                                    aa.WriteLine(x);
                                    break;
                                case '/':
                                    x = num[0] * num[1] / num[2];
                                    aa.WriteLine(x);
                                    break;
                            }
                            break;
                        case '/':
                            switch (b)
                            {
                                case '+':
                                    x = num[0] / num[1] + num[2];
                                    aa.WriteLine(x);
                                    break;
                                case '-':
                                    x = num[0] / num[1] - num[2];
                                    aa.WriteLine(x);
                                    break;
                                case '*':
                                    x = num[0] / num[1] * num[2];
                                    aa.WriteLine(x);
                                    break;
                                case '/':
                                    x = num[0] / num[1] / num[2];
                                    aa.WriteLine(x);
                                    break;
                            }
                            break;
                    }
                }
                if (fhs == 3)
                {
                    num[0] = sj.Next(0, 101);
                    num[1] = sj.Next(0, 101);
                    num[2] = sj.Next(0, 101);
                    num[3] = sj.Next(0, 101);
                    ss.Write(num[0].ToString(), Encoding.UTF8);
                    a = fh[sj.Next(0, 4)];
                    ss.Write(a);
                    ss.Write(num[1].ToString(), Encoding.UTF8);
                    b = fh[sj.Next(0, 4)];
                    ss.Write(b);
                    ss.Write(num[2].ToString(), Encoding.UTF8);
                    c = fh[sj.Next(0, 4)];
                    ss.Write(c);
                    ss.Write(num[3].ToString(), Encoding.UTF8);
                    ss.WriteLine('=');
                    switch (a)
                    {
                        case '+':
                            switch (b)
                            {
                                case '+':
                                    switch (c)
                                    {
                                        case '+':
                                            x = num[0] + num[1] + num[2] + num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '-':
                                            x = num[0] + num[1] + num[2] - num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '*':
                                            x = num[0] + num[1] + num[2] * num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '/':
                                            x = num[0] + num[1] + num[2] / num[3];
                                            aa.WriteLine(x);
                                            break;
                                    }
                                    break;
                                case '-':
                                    switch (c)
                                    {
                                        case '+':
                                            x = num[0] + num[1] - num[2] + num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '-':
                                            x = num[0] + num[1] - num[2] - num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '*':
                                            x = num[0] + num[1] - num[2] * num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '/':
                                            x = num[0] + num[1] - num[2] / num[3];
                                            aa.WriteLine(x);
                                            break;
                                    }
                                    break;
                                case '*':
                                    switch (c)
                                    {
                                        case '+':
                                            x = num[0] + num[1] * num[2] + num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '-':
                                            x = num[0] + num[1] * num[2] - num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '*':
                                            x = num[0] + num[1] * num[2] * num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '/':
                                            x = num[0] + num[1] * num[2] / num[3];
                                            aa.WriteLine(x);
                                            break;
                                    }
                                    break;
                                case '/':
                                    switch (c)
                                    {
                                        case '+':
                                            x = num[0] + num[1] / num[2] + num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '-':
                                            x = num[0] + num[1] / num[2] - num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '*':
                                            x = num[0] + num[1] / num[2] * num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '/':
                                            x = num[0] + num[1] / num[2] / num[3];
                                            aa.WriteLine(x);
                                            break;
                                    }
                                    break;
                            }
                            break;
                        case '-':
                            switch (b)
                            {
                                case '+':
                                    switch (c)
                                    {
                                        case '+':
                                            x = num[0] - num[1] + num[2] + num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '-':
                                            x = num[0] - num[1] + num[2] - num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '*':
                                            x = num[0] - num[1] + num[2] * num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '/':
                                            x = num[0] - num[1] + num[2] / num[3];
                                            aa.WriteLine(x);
                                            break;
                                    }
                                    break;
                                case '-':
                                    switch (c)
                                    {
                                        case '+':
                                            x = num[0] - num[1] - num[2] + num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '-':
                                            x = num[0] - num[1] - num[2] - num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '*':
                                            x = num[0] - num[1] - num[2] * num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '/':
                                            x = num[0] - num[1] - num[2] / num[3];
                                            aa.WriteLine(x);
                                            break;
                                    }
                                    break;
                                case '*':
                                    switch (c)
                                    {
                                        case '+':
                                            x = num[0] - num[1] * num[2] + num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '-':
                                            x = num[0] - num[1] * num[2] - num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '*':
                                            x = num[0] - num[1] * num[2] * num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '/':
                                            x = num[0] - num[1] * num[2] / num[3];
                                            aa.WriteLine(x);
                                            break;
                                    }
                                    break;
                                case '/':
                                    switch (c)
                                    {
                                        case '+':
                                            x = num[0] - num[1] / num[2] + num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '-':
                                            x = num[0] - num[1] / num[2] - num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '*':
                                            x = num[0] - num[1] / num[2] * num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '/':
                                            x = num[0] - num[1] / num[2] / num[3];
                                            aa.WriteLine(x);
                                            break;
                                    }
                                    break;
                            }
                            break;
                        case '*':
                            switch (b)
                            {
                                case '+':
                                    switch (c)
                                    {
                                        case '+':
                                            x = num[0] * num[1] + num[2] + num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '-':
                                            x = num[0] * num[1] + num[2] - num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '*':
                                            x = num[0] * num[1] + num[2] * num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '/':
                                            x = num[0] * num[1] + num[2] / num[3];
                                            aa.WriteLine(x);
                                            break;
                                    }
                                    break;
                                case '-':
                                    switch (c)
                                    {
                                        case '+':
                                            x = num[0] * num[1] - num[2] + num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '-':
                                            x = num[0] * num[1] - num[2] - num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '*':
                                            x = num[0] * num[1] - num[2] * num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '/':
                                            x = num[0] * num[1] - num[2] / num[3];
                                            aa.WriteLine(x);
                                            break;
                                    }
                                    break;
                                case '*':
                                    switch (c)
                                    {
                                        case '+':
                                            x = num[0] * num[1] * num[2] + num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '-':
                                            x = num[0] * num[1] * num[2] - num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '*':
                                            x = num[0] * num[1] * num[2] * num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '/':
                                            x = num[0] * num[1] * num[2] / num[3];
                                            aa.WriteLine(x);
                                            break;
                                    }
                                    break;
                                case '/':
                                    switch (c)
                                    {
                                        case '+':
                                            x = num[0] * num[1] / num[2] + num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '-':
                                            x = num[0] * num[1] / num[2] - num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '*':
                                            x = num[0] * num[1] / num[2] * num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '/':
                                            x = num[0] * num[1] / num[2] / num[3];
                                            aa.WriteLine(x);
                                            break;
                                    }
                                    break;
                            }
                            break;
                        case '/':
                            switch (b)
                            {
                                case '+':
                                    switch (c)
                                    {
                                        case '+':
                                            x = num[0] / num[1] + num[2] + num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '-':
                                            x = num[0] / num[1] + num[2] - num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '*':
                                            x = num[0] / num[1] + num[2] * num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '/':
                                            x = num[0] / num[1] + num[2] / num[3];
                                            aa.WriteLine(x);
                                            break;
                                    }
                                    break;
                                case '-':
                                    switch (c)
                                    {
                                        case '+':
                                            x = num[0] / num[1] - num[2] + num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '-':
                                            x = num[0] / num[1] - num[2] - num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '*':
                                            x = num[0] / num[1] - num[2] * num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '/':
                                            x = num[0] / num[1] - num[2] / num[3];
                                            aa.WriteLine(x);
                                            break;
                                    }
                                    break;
                                case '*':
                                    switch (c)
                                    {
                                        case '+':
                                            x = num[0] / num[1] * num[2] + num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '-':
                                            x = num[0] / num[1] * num[2] - num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '*':
                                            x = num[0] / num[1] * num[2] * num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '/':
                                            x = num[0] / num[1] * num[2] / num[3];
                                            aa.WriteLine(x);
                                            break;
                                    }
                                    break;
                                case '/':
                                    switch (c)
                                    {
                                        case '+':
                                            x = num[0] / num[1] / num[2] + num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '-':
                                            x = num[0] / num[1] / num[2] - num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '*':
                                            x = num[0] / num[1] / num[2] * num[3];
                                            aa.WriteLine(x);
                                            break;
                                        case '/':
                                            x = num[0] / num[1] / num[2] / num[3];
                                            aa.WriteLine(x);
                                            break;
                                    }
                                    break;
                            }
                            break;

                    }
                }
            }
            ss.Close();
            aa.Close();

        }
    }
}
