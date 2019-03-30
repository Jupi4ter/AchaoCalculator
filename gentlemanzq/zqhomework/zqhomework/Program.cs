using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zqhomework
{
   public class Program
    {
       public static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            
            char[] s = new char[4] { '+', '-', '*', '/' };

             Random random1 = new Random();
            StreamWriter sw1 = new StreamWriter(@"D:\ce.txt");
            for (int i = 0; i < n; i++)
            {

                int x = random1.Next(0, 2);
                if (x == 0)//两个运算符
                {
                    int x1 = random1.Next(0, 100);
                    int x2 = random1.Next(0, 100);
                    int x3 = random1.Next(0, 100);
                    int s1 = random1.Next(0, 4);
                    int s2 = random1.Next(0, 4);
                    if ((s[s1] == '+' || s[s1] == '-') && (s[s2] == '*' || s[s2] == '/'))
                    {
                        double sum = counter(x2, x3, s2);
                        if (sum < 0)
                        {
                            i--;
                        }
                        else
                        {
                            if (ansx(sum))
                            {
                                double temp = counter(x1, (int)sum, s1);
                                if (temp < 0)
                                {
                                    i--;
                                }
                                else
                                {
                                    if (ansx(temp))
                                    {
                                        Console.WriteLine(x1 + "" + s[s1] + "" + x2 + "" + s[s2] + "" + x3 + "=" + (int)temp);
                                        sw1.Write(x1 + "" + s[s1] + "" + x2 + "" + s[s2] + "" + x3 + "=" + (int)temp + "\r\n");
                                    }
                                    else
                                    {
                                        i--;
                                    }
                                }
                            }
                            else
                            {
                                i--;
                            }

                        }
                    }
                    else
                    {
                        double sum = counter(x1, x2, s1);
                        if (sum < 0)
                        {
                            i--;
                        }
                        else
                        {
                            if (ansx(sum))
                            {
                                double temp = counter((int)sum, x3, s2);
                                if (temp < 0)
                                {
                                    i--;
                                }
                                else
                                {
                                    if (ansx(temp))
                                    {
                                        Console.WriteLine(x1 + "" + s[s1] + "" + x2 + "" + s[s2] + "" + x3 + "=" + (int)temp);

                                        sw1.Write(x1 + "" + s[s1] + "" + x2 + "" + s[s2] + "" + x3 + "=" + (int)temp + "\r\n");
                                    }
                                    else
                                    {
                                        i--;
                                    }
                                }


                            }
                            else
                            {
                                i--;
                            }

                        }
                    }

                }
                else//三个运算符
                {
                   
                    int x1 = random1.Next(0, 100);
                    int x2 = random1.Next(0, 100);
                    int x3 = random1.Next(0, 100);
                    int x4 = random1.Next(0, 100);
                    int s3 = random1.Next(0, 4);
                    int s1 = random1.Next(0, 4);
                    int s2 = random1.Next(0, 4);
                    if ((s[s1] == '+' || s[s1] == '-') && (s[s2] == '*' || s[s2] == '/') && (s[s3] == '*' || s[s3] == '/'))
                    {
                        double sum = counter(x2, x3, s2);
                        if (sum < 0)
                        {
                            i--;
                        }
                        else
                        {
                            if (ansx(sum))
                            {
                                double temp = counter((int)sum, x4, s3);
                                if (temp < 0)
                                {
                                    i--;
                                }
                                else
                                {
                                    
                                     double temp1 = counter(x1, (int)temp, s1);
                                    
                                    if (temp1 < 0)
                                    {
                                        i--;
                                    }
                                    else
                                    {
                                        if (ansx(temp1))
                                        {
                                            Console.WriteLine(x1 + "" + s[s1] + "" + x2 + "" + s[s2] + "" + x3 + "" + s[s3] + x4 + "=" + (int)temp1);
                                            sw1.Write(x1 + "" + s[s1] + "" + x2 + "" + s[s2] + "" + x3 + "" + s[s3] + x4 + "=" + (int)temp1 + "\r\n");
                                        }
                                        else
                                        {
                                            i--;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                i--;
                            }
                        }

                    }
                    else if ((s[s1] == '+' || s[s1] == '-') && (s[s2] == '*' || s[s2] == '/') && (s[s3] == '-' || s[s3] == '+'))
                    {
                        double sum = counter(x2, x3, s2);
                        if (sum < 0)
                        {
                            i--;
                        }
                        else
                        {
                            if (ansx(sum))
                            {

                                
                                double  temp = counter(x1, (int)sum, s1);
                               
                                if (temp < 0)
                                {
                                    i--;
                                }
                                else
                                {
                                    double temp1 = counter((int)temp, x4, s3);
                                    if (temp1 < 0)
                                    {
                                        i--;
                                    }
                                    else
                                    {
                                        if (ansx(temp1))
                                        {
                                            Console.WriteLine(x1 + "" + s[s1] + "" + x2 + "" + s[s2] + "" + x3 + "" + s[s3] + x4 + "=" + (int)temp1);
                                            sw1.Write(x1 + "" + s[s1] + "" + x2 + "" + s[s2] + "" + x3 + "" + s[s3] + x4 + "=" + (int)temp1 + "\r\n");
                                        }
                                        else
                                        {
                                            i--;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                i--;
                            }
                        }

                    }
                    else if ((s[s1] == '+' || s[s1] == '-') && (s[s2] == '+' || s[s2] == '-') && (s[s3] == '*' || s[s3] == '/'))
                    {
                        double sum = counter(x3, x4, s3);
                        if (sum < 0)
                        {
                            i--;
                        }
                        else
                        {
                            if (ansx(sum))
                            {
                                double temp = counter(x1, x2, s1);
                                if (temp < 0)
                                {
                                    i--;
                                }
                                else
                                {
                                    double temp1 = counter((int)temp,(int)sum , s2);
                                    if (temp1 < 0)
                                    {
                                        i--;
                                    }
                                    else
                                    {
                                        if (ansx(temp1))
                                        {
                                            Console.WriteLine(x1 + "" + s[s1] + "" + x2 + "" + s[s2] + "" + x3 + "" + s[s3] + x4 + "=" + (int)temp1);
                                            sw1.Write(x1 + "" + s[s1] + "" + x2 + "" + s[s2] + "" + x3 + "" + s[s3] + x4 + "=" + (int)temp1 + "\r\n");
                                        }
                                        else
                                        {
                                            i--;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                i--;
                            }
                        }

                    }
                    else if ((s[s1] == '*' || s[s1] == '/')&& (s[s2] == '+' || s[s2] == '-') && (s[s3] == '*'||s[s3]=='/'))
                    {
                        double sum = counter(x1, x2, s1);
                        if (sum < 0)
                        {
                            i--;
                        }
                        else
                        {
                            if (ansx(sum))
                            {
                                double temp = counter(x3, x4, s3);
                                if (temp < 0)
                                {
                                    i--;
                                }
                                else
                                {
                                    double temp1 = counter((int )sum, (int )temp, s2);
                                    if (temp1 < 0)
                                    {
                                        i--;
                                    }
                                    else
                                    {
                                        if (ansx(temp1))
                                        {
                                            Console.WriteLine(x1 + "" + s[s1] + "" + x2 + "" + s[s2] + "" + x3 + "" + s[s3] + x4 + "=" + (int)temp1);
                                            sw1.Write(x1 + "" + s[s1] + "" + x2 + "" + s[s2] + "" + x3 + "" + s[s3] + x4 + "=" + (int)temp1 + "\r\n");
                                        }
                                        else
                                        {
                                            i--;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                i--;
                            }
                        }

                    }
                    else
                    {
                        double sum = counter(x1, x2, s1);
                        if (sum < 0)
                        {
                            i--;
                        }
                        else
                        {
                            if (ansx(sum))
                            {
                                double temp = counter((int)sum, x3, s2);
                                if (temp < 0)
                                {
                                    i--;
                                }
                                else
                                {
                                    double temp1 = counter((int)temp, x4, s3);
                                    if (temp1 < 0)
                                    {
                                        i--;
                                    }
                                    else
                                    {
                                        if (ansx(temp1))
                                        {
                                            Console.WriteLine(x1 + "" + s[s1] + "" + x2 + "" + s[s2] + "" + x3 + "" + s[s3] + x4 + "=" + (int)temp1);
                                            sw1.Write(x1 + "" + s[s1] + "" + x2 + "" + s[s2] + "" + x3 + "" + s[s3] + x4 + "=" + (int)temp1 + "\r\n");
                                        }
                                        else
                                        {
                                            i--;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                i--;
                            }
                        }

                    }

                   
                }
            }
            sw1.Close();
            Console.ReadKey();
        }
        public static bool ansx(double sum)
        {
            if (sum == (int)sum)
                return true;
            else
                return false;
        }
        public static double  counter(int x,int y,int z)
        {
            if (z == 0)
                return x + y;
            else if (z == 1)
                return x - y;
            else if (z == 2)
                return x * y;
            else
            {
                if(y!=0)
                {
                    int m = x / y;
                    if(m*y==x) 
                    return x / y;
                    else
                    {
                        return -1;
                    }
                    
                }
                else
                {
                    return -1;
                }
            }   
        }
          

    }
   

}
