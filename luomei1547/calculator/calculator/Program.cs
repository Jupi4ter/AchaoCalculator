using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace calculator
{


    public class Program
    {

        //Add中的参数：totle为接受的命令行输入数
        //Add的返回值表示成功生成四则运算的个数
        //调用Auto函数，每调用一次，生成一个四则运算
        static public int Add(int totle)
        {
            try
            {
                int temp;
                for (temp = 0; temp < totle;)
                {
                    if (Auto(2, 3, 0, 100) == true)
                    {
                        temp++;
                    }
                }
                return temp;
            }
            catch
            {
                return -1;
            }
        }


        //被Add()调用，按条件随机生成一个四则运算表达式的字符串。
        //Auto中的参数：[i,j]为操作符个数范围，[a,b]为操作数范围。
        //Auto中的返回值代表四则运算表达式是否成功存入文件。
        static public bool Auto(int i, int j, int a, int b)
        {
            int count = 0;
            while (count == 0)
            {
                //提高随机数的随机性，给定种子值iSeed
                byte[] buffer = Guid.NewGuid().ToByteArray();
                int iSeed = BitConverter.ToInt32(buffer, 0);
                Random rand = new Random(iSeed);

                string expression = null;
                List<char> operat = new List<char>
                {
                   '+',
                   '-',
                   '*',
                   '/'
                };
                int t = rand.Next(i, j + 1);
                if (t == 3)
                {
                    char k = operat[rand.Next(0, 4)];
                    char n = operat[rand.Next(0, 4)];
                    while (!(k.ToString() == n.ToString() && k.ToString() == "/"))
                    {
                        expression = rand.Next(a, b + 1).ToString() + k + rand.Next(a, b + 1).ToString() + operat[rand.Next(0, 4)]+ rand.Next(a, b + 1) + n + rand.Next(a, b + 1).ToString();
                        break;
                    }
                }
                else
                {
                    for (int m = 1; m <= t; m++)
                    {
                        expression += rand.Next(a, b + 1).ToString() + operat[rand.Next(0, 4)];
                    }
                    expression += rand.Next(a, b + 1).ToString();
                }

                if (Save(expression) != null)
                {
                    return true;
                }

            }
            return false;
        }


        //被Auto(int i,int j,int a,int b)调用，
        //Save中的参数：anwser为四则运算表达式的字符串。
        //Save中的返回值代表参数的实际运算值,如果不符合要求就返回null。
        static public string Save(string expression)
        {
            try
            {
                DataTable dt = new DataTable();
                double answer = Convert.ToDouble(dt.Compute(expression, "false"));

                if (Convert.ToDouble(Convert.ToInt32(answer)) == answer && answer >= 0)
                {
                    File.AppendAllText(@".\subject.txt", expression + "=" + answer + "\r\n");
                    return answer.ToString();
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        //程序主入口
        static void Main(string[] args)
        {
            File.WriteAllText(@".\subject.txt", string.Empty);
            int totle = int.Parse(Console.ReadLine());
            Add(totle);
        }
    }
}
