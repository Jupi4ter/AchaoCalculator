using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
     public  class Program
    {
            public  static void Main()
            {
                int Grade_Count = 0;
                Random R = new Random();
                int a;
                for (int i = 0; i < 10; i++)
                {
                    int First_Num;
                    int Second_Num;
                    First_Num = R.Next(100);
                label: Second_Num = R.Next(100);
                    int Res;
                    string s;
                    a = R.Next(4) + 1;
                    switch (a)
                    {
                        case 1:
                            Console.WriteLine(First_Num + "+" + Second_Num + "=");
                            s = Console.ReadLine();
                            Res = int.Parse(s);
                            if (First_Num + Second_Num == Res)
                            {
                                Console.WriteLine("回答正确");
                                Grade_Count++;
                            }
                            else
                            {
                                Console.WriteLine("回答错误");
                                Console.WriteLine("正确答案为：" + (First_Num + Second_Num));
                            }
                            break;
                        case 2:
                            Console.WriteLine(First_Num + "-" + Second_Num + "=");
                            s = Console.ReadLine();
                            Res = int.Parse(s);
                            if (First_Num - Second_Num == Res)
                            {
                                Console.WriteLine("回答正确");
                                Grade_Count++;
                            }
                            else
                            {
                                Console.WriteLine("回答错误");
                                Console.WriteLine("正确答案为：" + (First_Num - Second_Num));
                            }
                            break;
                        case 3:
                            Console.WriteLine(First_Num + "*" + Second_Num + "=");
                            s = Console.ReadLine();
                            Res = int.Parse(s);
                            if (First_Num * Second_Num == Res)
                            {
                                Console.WriteLine("回答正确");
                                Grade_Count++;
                            }
                            else
                            {
                                Console.WriteLine("回答错误");
                                Console.WriteLine("正确答案为：" + (First_Num * Second_Num));
                            }
                            break;
                        case 4:
                            {
                                Console.WriteLine(First_Num + "/" + Second_Num + "=");
                                s = Console.ReadLine();
                            }
                            break;
                    }
                }
            }
        }


    }


