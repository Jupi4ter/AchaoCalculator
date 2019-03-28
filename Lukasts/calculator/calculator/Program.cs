using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    class Program
    {
        static void Main(string[] args)
        {


            for (int i = 0; i < 20; i++)
            {
                byte[] buffer = Guid.NewGuid().ToByteArray();
                int iSeed = BitConverter.ToInt32(buffer, 0);
                Random random = new Random(iSeed);
                int num_ops1 = random.Next(1, 5);
                int num1, num2, num3, num_ops2;
                num_ops2 = random.Next(1, 5);
                int result;
                num1 = random.Next(1, 100);
                num2 = random.Next(1, 100);
                num3 = random.Next(1, 100);
                if (num1 == num2 || num1 == num2 || num1 == num3)
                {
                    num1 = random.Next(1, 100);
                    num2 = random.Next(1, 100);
                    num3 = random.Next(1, 100);
                }



                char ops1, ops2;
                if (num_ops1 == 1)
                {
                    ops1 = '+';
                    result = num1 + num2;
                }
                else if (num_ops1 == 2)
                {
                    ops1 = '-';
                    if (num1 < num2)
                    {
                        int temp1 = num1;
                        num1 = num2;
               
                        num2 = temp1;
                    }
                    result = num1 - num2;
                }
                else if (num_ops1 == 3)
                {
                    ops1 = '*';
                    result = num1 * num2;
                }
                else
                {
                    ops1 = '/';
                    if (num1 < num2)
                    {
                        int temp2 = num1;
                        num1 = num2;

                        num2 = temp2;
                    }
                    if (num1 % num2 != 0)
                    {
                        num1 = num1 + (num2 - (num1 % num2));

                    }
                    result = num1 / num2;

                }
                if (num_ops2 == 1)
                {
                    ops2 = '+';
                   
                    Console.WriteLine("{0}{1}{2}{3}{4}=", num1, ops1, num2, ops2, num3); ;
                }
                else if (num_ops2 == 2)
                {
                    ops2 = '-';
                ;
                    if (result < num3)
                    {
                        int temp3 = num3;
                        num3 = num2;
                        num2 = num1;
                        num1 = temp3;
                        char opstemp1 = ops1;
                        ops1 = ops2;
                        ops2 = opstemp1;

                    }
                    Console.WriteLine("{0}{1}{2}{3}{4}=", num1, ops1, num2, ops2, num3);
                }
                else if (num_ops2 == 3)
                {
                    ops2 = '*';
                    if(ops1==1||ops1==2)
                    Console.WriteLine("({0}{1}{2}){3}{4}=", num1, ops1, num2, ops2, num3);
                }
                else
                {
                    ops2 = '/';

                    if (result < num3)
                    {
                        int temp4 = num3;
                        num3 = num2;
                        num2 = num1;
                        num1 = temp4;
                        char opstemp2 = ops1;
                        ops1 = ops2;
                        ops2 = opstemp2;
                        if (num1 % result != 0)
                        {
                            num1 = num1 + (result - (num1 % result));
                        }

                    }
                    else
                    { 
                       if (result % num3 != 0)
                      {
                            if (ops1 == '+' || ops1 == '-')
                            {
                                num1 = num1 + num3 - (result % num3);
                                Console.WriteLine("({0}{1}{2}){3}{4}=", num1, ops1, num2, ops2, num3);
                            }
                            else if (ops1 == '*')
                            {
                                num1 = num1 + (num3 - (result % num3)) / num2;
                                Console.WriteLine("{0}{1}{2}{3}{4}=", num1, ops1, num2, ops2, num3);
                            }
                            else
                            {
                                num1 = num1 + (num3 - (result % num3)) * num2;
                                Console.WriteLine("{0}{1}{2}{3}{4}=", num1, ops1, num2, ops2, num3);
                            }
                        }
                    }
                   
                }   
            }
         }
        
    }
}
