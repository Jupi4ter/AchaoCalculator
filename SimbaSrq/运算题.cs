using System;

namespace perform
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入需生成的计算题个数： \n");
            int n = int.Parse(Console.ReadLine());
            for(int i = 0; i < n; i++) {
                CreateQues();
            }
            Console.ReadLine();
        }

        public static void CreateQues()
        {
            String str = "+-*/";
            int sum = 0;
            int[] arr = new int[4];
            String str1 = "";
            String str2 = "";
            String str3 = "";
            Random rd = new Random();
            int n = rd.Next(2,4);   // 变量n用来随机获取运算符个数（2或者3个）
            if (n == 2) {    //运算符为2个时，需要生成三个数
                arr[0] = rd.Next(0, 100);   //生成第一个随机数
                str1 = str.Substring(rd.Next(0,4), 1);  //以截取字符串的形式获取第一个运算符
                arr[1] = rd.Next(0, 100);   //生成第二个随机数
                str2 = str.Substring(rd.Next(0, 4), 1);   //以截取字符串的形式获取第二个运算符
                arr[2] = rd.Next(0, 100);   //生成第三个随机数
                if (str1 == "*" || str1 == "/")
                {
                    int b = Count(arr[0], arr[1], str1);
                    if (b != -1)
                    {
                        int sum1 = Count(b, arr[2], str2);
                        if (sum1 != -1)
                        {
                            sum = sum1;
                        }
                        else
                        {
                            sum = -1;
                        }
                    }
                    else
                    {
                        sum = -1;
                    }
                }
                else
                {
                    int b = Count(arr[1], arr[2], str2);
                    if (b != -1)
                    {
                        int sum1 = Count(arr[0], b, str1);
                        if (sum1 != -1)
                        {
                            sum = sum1;
                        }
                        else
                        {
                            sum = -1;
                        }
                    }
                    else
                    {
                        sum = -1;
                    }
                }
                
            }
            if (n == 3)   //运算符为3个时，需要生成四个数
            {
                arr[0] = rd.Next(0, 100);   
                str1 = str.Substring(rd.Next(0, 4), 1);  
                arr[1] = rd.Next(0, 100);  
                str2 = str.Substring(rd.Next(0, 4), 1);   
                arr[2] = rd.Next(0, 100);   
                str3 = str.Substring(rd.Next(0, 4), 1);
                arr[3] = rd.Next(0, 100);
                if (str1 == "*" || str1 == "/")  // 0 1 2 3
                {
                    int b = Count(arr[0], arr[1], str1);
                    if (b != -1)
                    {
                        if (str2 == "*" || str2 == "/")
                        {
                            int x = Count(b, arr[2], str2);
                            if (x != -1)
                            {
                                int sum1 = Count(x, arr[3], str3);
                                if (sum1 != -1)
                                {
                                    sum = sum1;
                                }
                                else
                                {
                                    sum = -1;
                                }
                            }
                            else
                            {
                                sum = -1;
                            }
                        }
                        else
                        {
                            int x = Count(arr[2], arr[3], str3);
                            if (x != -1)
                            {
                                int sum1 = Count(b, x, str2);
                                if (sum1 != -1)
                                {
                                    sum = sum1;
                                }
                                else
                                {
                                    sum = -1;
                                }
                            }
                            else
                            {
                                sum = -1;
                            }
                        }
                    }
                    else
                    {
                        sum = -1;
                    }
                }
                else
                {
                    
                }
                
            }
            if (sum >= 0&&n==2)
            {
                Console.WriteLine(arr[0] + str1 + arr[1] + str2 + arr[2] + "=" + sum);
            }
            else if (sum >= 0 && n == 3)
            {
                Console.WriteLine(arr[0] + str1 + arr[1] + str2 + arr[2] + str3 + arr[3] + "=" + sum);
            }
            else
            {
                CreateQues();
            }
        }

        public static int Count(int a, int b, string str) {
            double sum = 0;
            if (str == "+")
            {
                sum = a + b;
            }
            else if (str == "-") {
                sum = a - b;
            }
            else if (str == "*")
            {
                sum = a * b;
            }
            else
            {
                if (b != 0)
                {
                    sum = (double)a / b;
                }
                else { sum = -1; }
            }
            if ((sum%1)!=0)
            {
                sum = -1;
            }
            return (int)sum;
        }
    }
}
