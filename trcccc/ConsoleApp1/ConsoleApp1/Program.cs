using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace ConsoleApp1
{
    public class Program
    {
        static public void Main(string[] args)
        {
          
            DataTable dt = new DataTable();
            int n;
            double a, b, c, d;
            char fu1,fu2,fu3;
            char[] sym = { '+', '-', '*', '/' };
            Random num = new Random();//定义随机数函数
            Console.WriteLine("请输入题目的个数：");
            StreamWriter sw = new StreamWriter("D:\\obj5ect.txt");
            //Console.WriteLine(t.gets());检测随即符号是否正常生成

            n = int.Parse(Console.ReadLine());//输入题目个数
            for(int f=0;f<n;f++)
            {
                switch (num.Next(2, 4))
                {
                    case 2:
                        {
                            a = num.Next(0, 100);
                            b = num.Next(0, 100);
                            c = num.Next(0, 100);
                            /*  fu1 = t.gets();
                              fu2 = t.gets();直接调用类中的方法生成的随机数是一样的*/
                            fu1 = sym[num.Next(0, 4)];
                            fu2 = sym[num.Next(0, 4)];    
                            string p= (a + char.ToString(fu1) + b + char.ToString(fu2) + c );
                            double h =Convert.ToDouble(dt.Compute(p, null));//使用compute计算字符串的四则运算
                            
                            if (h >= 0&&h==(int)h)
                            {
                                Console.WriteLine(a + char.ToString(fu1) + b + char.ToString(fu2) + c + " = " + h);
                                sw.Write(p);//写入文件
                            }

                            else
                            {
                                f = f - 1;
                            }
                            break;
                            
                        }
                    case 3:
                        {
                            a = num.Next(0, 100);
                            b = num.Next(0, 100);
                            c = num.Next(0, 100);
                            d = num.Next(0, 100);
                            fu1 = sym[num.Next(0, 4)];
                            fu2 = sym[num.Next(0, 4)];
                            fu3 = sym[num.Next(0, 4)];
                            string p = (a + char.ToString(fu1) + b + fu2 + c + fu3 + d);
                            double h = Convert.ToDouble(dt.Compute(p, null));
                            if (h >= 0 && h == (int)h)
                            {
                                Console.WriteLine(a + char.ToString(fu1) + b + fu2 + c + fu3 + d + " = " + h);
                                sw.Write(p) ;
                            }
                            else
                            {
                                f = f - 1;
                            }
                            break;
                        }
                       
                }
                
            }
            ss m = new ss();
            
            Console.ReadLine();
        }
    }
    public class ss
    {
        public ss()
        {
            for (int i = 0; i < 10000000; i++)
            {
                int h;
            }
        
        }
    }
}
