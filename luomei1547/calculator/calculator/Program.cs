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
        //调用Auto函数，每调用一次，生成一个符合要求的四则运算
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
                string expression_double = null;
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
                    int number1 = rand.Next(a, b + 1);
                    int number2 = rand.Next(a, b + 1);
                    int number3 = rand.Next(a, b + 1);
                    int number4 = rand.Next(a, b + 1);
                    char s = operat[rand.Next(0, 4)];
                    char k = operat[rand.Next(0, 4)];
                    char l = operat[rand.Next(0, 4)];
                    if (!(s == '/' && k == '/' && l != '/'))
                    {
                        if (s == '/' && k != '/' && l != '/')
                        {
                            if (Convert.ToDouble(Convert.ToInt32(number1 * 1.0 / number2)) == number1 * 1.0 / number2 && number2 != 0)
                            {
                                expression_double = (number1).ToString("F") + s + (number2).ToString("F") + k + (number3).ToString("F") + l + (number4).ToString("F");
                                expression = (number1).ToString() + s + (number2).ToString() + k + (number3).ToString() + l + (number4).ToString();
                            }
                            else break;
                        }
                        else if (s != '/' && k == '/' && l != '/')
                        {
                            if (Convert.ToDouble(Convert.ToInt32(number2 * 1.0 / number3)) == number2 * 1.0 / number3 && number3 != 0)
                            {
                                expression_double = (number1).ToString("F") + s + (number2).ToString("F") + k + (number3).ToString("F") + l + (number4).ToString("F");
                                expression = (number1).ToString() + s + (number2).ToString() + k + (number3).ToString() + l + (number4).ToString();
                            }
                            else break;
                        }
                        else if (s != '/' && k != '/' && l == '/')
                        {
                            if (Convert.ToDouble(Convert.ToInt32(number3 * 1.0 / number4)) == number3 * 1.0 / number4 && number4 != 0)
                            {
                                expression_double = (number1).ToString("F") + s + (number2).ToString("F") + k + (number3).ToString("F") + l + (number4).ToString("F");
                                expression = (number1).ToString() + s + (number2).ToString() + k + (number3).ToString() + l + (number4).ToString();
                            }
                            else break;
                        }
                        else
                        {
                            expression_double = (number1).ToString("F") + s + (number2).ToString("F") + k + (number3).ToString("F") + l + (number4).ToString("F");
                            expression = (number1).ToString() + s + (number2).ToString() + k + (number3).ToString() + l + (number4).ToString();
                        }

                    }
                }
                else
                {
                    for (int m = 1; m <= t; m++)
                    {
                        int number = rand.Next(a, b + 1);
                        int operat_number = rand.Next(0, 4);
                        expression_double+= number.ToString("F") + operat[operat_number];
                        expression += number.ToString() + operat[operat_number];
                    }
                    int number3= rand.Next(a, b + 1);
                    expression_double += number3.ToString("F");
                    expression += number3.ToString();
                }

                if (Save(expression,expression_double) != null)
                {
                    return true;
                }

            }
            return false;
        }


        //被Auto(int i,int j,int a,int b)调用，
        //Save中的参数：anwser为四则运算表达式的字符串。
        //Save中的返回值代表参数的实际运算值,如果不符合要求就返回null。
        static public string Save(string expression,string expression_double)
        {
            try
            {
                if (expression != null && expression != null)
                {
                    DataTable dt = new DataTable();
                    double answer = Convert.ToDouble(dt.Compute(expression_double, "false"));

                    if (Convert.ToDouble(Convert.ToInt32(answer)) == answer && answer >= 0)
                    {
                        File.AppendAllText(@".\subject.txt", expression + "=" + (int)answer + "\r\n");
                        return answer.ToString();
                    }
                    return null;
                }
                else return null;
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
