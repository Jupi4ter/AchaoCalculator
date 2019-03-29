using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp14
{
    class Program
    {

        static void Main(string[] args)
        {
            int x, y, z, n, i, j, k;
            double t = 0;
            string w = "";
            string file = @"D:\LLL.txt";//写入文件地址
            StreamWriter f = new StreamWriter(file);
            Console.WriteLine("请输入出题数量（以回车结束）");
            n = Convert.ToInt32(Console.ReadLine());
            Random R = new Random();
            for (j = 0; j < n; j++)
            {
                w = "";
                z = R.Next(2, 4);//运算符个数
                for (i = 1; i <= z + 1; i++)
                {
                    x = R.Next(0, 100);//计算所参与的数字
                    y = R.Next(1, 5);//符号种类
                    if (i == z + 1)
                    {
                        w = w + Convert.ToString(x);
                        break;
                    }
                    else
                    {
                        switch (y)//运算符随机筛选
                        {
                            case 1:
                                w = w + Convert.ToString(x) + "+";
                                break;
                            case 2:
                                w = w + Convert.ToString(x) + "-";
                                break;
                            case 3:
                                w = w + Convert.ToString(x) + "*";
                                break;
                            case 4:
                                w = w + Convert.ToString(x) + "/";
                                break;
                        }
                    }
                }
                object a = new System.Data.DataTable().Compute(w, "");//计算所得式子并取得结果
                t = Convert.ToDouble(a);
                k = Convert.ToInt32(t);
                if (t < 0 || (t - k) != 0)//排除负数和分数的可能
                {
                    n++;
                }
                else//打印并将结果录入文档中
                {
                    w = w + "=";
                    Console.Write(w);
                    Console.Write(t);
                    Console.WriteLine();
                    f.WriteLine("{0}{1}", w, t);
                    f.Flush();
                }
            } 
            Console.ReadLine();   
            
        }
    }

}
