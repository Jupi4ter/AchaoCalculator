using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace CalculatorUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
           
        }
        static void Main(string[] args)
        {
            string filename = @"C:\00001\subject.txt";
            Console.Write("请输入生成的算术数量:");
            StreamWriter fs = new StreamWriter(filename, true);
            int n = int.Parse(Console.ReadLine());
            Random rd = new Random();
            int opnumber = rd.Next(2, 4);
            int[] intstore = new int[opnumber + 1];
            char[] charstore = new char[opnumber];
            double ans;
            char[] ops = { '+', '-', '*', '/' };
            for (int i = 0; i < n; i++)
            {
                opnumber = rd.Next(2, 4);//用于判断生成的运算符个数
                intstore = new int[opnumber + 1];
                charstore = new char[opnumber];
                if (opnumber == 2)
                {
                    int temp = 0;
                vv: while (temp == 0)//此循环用于对一个算式的检测
                    {
                        //将随机生成的数字和运算符存入数组
                        for (int j = 0; j < opnumber + 1; j++)
                        {
                            intstore[j] = rd.Next(0, 101);
                        }
                        for (int k = 0; k < opnumber; k++)
                        {
                            charstore[k] = ops[rd.Next(0, 4)];
                        }
                        //对除号进行检测，筛选不会出现相除得非整数的算式
                        int p = 0;
                        for (int t = 0; t < opnumber; t++)
                        {
                            ans = intstore[p];
                            if (charstore[t] == '/')
                            {
                                if (p > 0 && ans == 0) goto vv;
                                ans = ans / intstore[t + 1];
                                int a = (int)ans;
                                if (a == ans)
                                {
                                    continue;
                                }
                                else
                                {
                                    goto vv;
                                }
                            }
                            else p++;
                            if (t == opnumber - 1) temp = 1;
                        }
                    }
                    //将筛选好的存入文件
                    fs.Write(intstore[0].ToString(), Encoding.UTF8);
                    fs.Write(charstore[0]);
                    fs.Write(intstore[1].ToString(), Encoding.UTF8);
                    fs.Write(charstore[1]);
                    fs.Write(intstore[2].ToString(), Encoding.UTF8);
                    fs.Write("=");
                    //得出答案，并将答案存入文档
                    int reans = intstore[0];
                    switch (charstore[0])
                    {
                        case '+':
                            switch (charstore[1])
                            {
                                case '+':
                                    reans = intstore[0] + intstore[1] + intstore[2];
                                    break;
                                case '-':
                                    reans = intstore[0] + intstore[1] - intstore[2];
                                    break;
                                case '*':
                                    reans = intstore[0] + intstore[1] * intstore[2];
                                    break;
                                case '/':
                                    reans = intstore[0] + intstore[1] / intstore[2];
                                    break;
                            }
                            break;
                        case '-':
                            switch (charstore[1])
                            {
                                case '+':
                                    reans = intstore[0] - intstore[1] + intstore[2];
                                    break;
                                case '-':
                                    reans = intstore[0] - intstore[1] - intstore[2];
                                    break;
                                case '*':
                                    reans = intstore[0] - intstore[1] * intstore[2];
                                    break;
                                case '/':
                                    reans = intstore[0] - intstore[1] / intstore[2];
                                    break;

                            }
                            break;
                        case '*':
                            switch (charstore[1])
                            {
                                case '+':
                                    reans = intstore[0] * intstore[1] + intstore[2];
                                    break;
                                case '-':
                                    reans = intstore[0] * intstore[1] - intstore[2];
                                    break;
                                case '*':
                                    reans = intstore[0] * intstore[1] * intstore[2];
                                    break;
                                case '/':
                                    reans = intstore[0] * intstore[1] / intstore[2];
                                    break;

                            }
                            break;
                        case '/':
                            switch (charstore[1])
                            {
                                case '+':
                                    reans = intstore[0] / intstore[1] + intstore[2];
                                    break;
                                case '-':
                                    reans = intstore[0] / intstore[1] - intstore[2];
                                    break;
                                case '*':
                                    reans = intstore[0] / intstore[1] * intstore[2];
                                    break;
                                case '/':
                                    reans = intstore[0] / intstore[1] / intstore[2];
                                    break;
                            }
                            break;
                    }

                    fs.WriteLine(reans.ToString(), Encoding.UTF8);
                }
                if (opnumber == 3)
                {
                    int temp = 0;
                vv: while (temp == 0)
                    {
                        for (int j = 0; j < opnumber + 1; j++)
                        {
                            intstore[j] = rd.Next(0, 101);
                        }
                        for (int k = 0; k < opnumber; k++)
                        {
                            charstore[k] = ops[rd.Next(0, 4)];
                        }
                        int p = 0;
                        for (int t = 0; t < opnumber; t++)
                        {
                            ans = intstore[p];
                            if (charstore[t] == '/')
                            {
                                if (ans == 0 && p > 0) goto vv;
                                ans = ans / intstore[t + 1];
                                int a = (int)ans;

                                if (a == ans)
                                {

                                    continue;
                                }
                                else goto vv;
                            }
                            else p++;
                            if (t == opnumber - 1) temp = 1;
                        }
                    }
                    fs.Write(intstore[0].ToString(), Encoding.UTF8);
                    fs.Write(charstore[0]);
                    fs.Write(intstore[1].ToString(), Encoding.UTF8);
                    fs.Write(charstore[1]);
                    fs.Write(intstore[2].ToString(), Encoding.UTF8);
                    fs.Write(charstore[2]);
                    fs.Write(intstore[3].ToString(), Encoding.UTF8);
                    fs.Write("=");
                    int reans = intstore[0];
                    switch (charstore[0])
                    {
                        case '+':
                            switch (charstore[1])
                            {
                                case '+':
                                    switch (charstore[2])
                                    {
                                        case '+':
                                            reans = intstore[0] + intstore[1] + intstore[2] + intstore[3];
                                            break;
                                        case '-':
                                            reans = intstore[0] + intstore[1] + intstore[2] - intstore[3];
                                            break;
                                        case '*':
                                            reans = intstore[0] + intstore[1] + intstore[2] * intstore[3];
                                            break;
                                        case '/':
                                            reans = intstore[0] + intstore[1] + intstore[2] / intstore[3];
                                            break;
                                    }
                                    break;
                                case '-':
                                    switch (charstore[2])
                                    {
                                        case '+':
                                            reans = intstore[0] + intstore[1] - intstore[2] + intstore[3];
                                            break;
                                        case '-':
                                            reans = intstore[0] + intstore[1] - intstore[2] - intstore[3];
                                            break;
                                        case '*':
                                            reans = intstore[0] + intstore[1] - intstore[2] * intstore[3];
                                            break;
                                        case '/':
                                            reans = intstore[0] + intstore[1] - intstore[2] / intstore[3];
                                            break;
                                    }
                                    break;
                                case '*':
                                    switch (charstore[2])
                                    {
                                        case '+':
                                            reans = intstore[0] + intstore[1] * intstore[2] + intstore[3];
                                            break;
                                        case '-':
                                            reans = intstore[0] + intstore[1] * intstore[2] - intstore[3];
                                            break;
                                        case '*':
                                            reans = intstore[0] + intstore[1] * intstore[2] * intstore[3];
                                            break;
                                        case '/':
                                            reans = intstore[0] + intstore[1] * intstore[2] / intstore[3];
                                            break;
                                    }
                                    break;
                                case '/':
                                    switch (charstore[2])
                                    {
                                        case '+':
                                            reans = intstore[0] + intstore[1] / intstore[2] + intstore[3];
                                            break;
                                        case '-':
                                            reans = intstore[0] + intstore[1] / intstore[2] - intstore[3];
                                            break;
                                        case '*':
                                            reans = intstore[0] + intstore[1] / intstore[2] * intstore[3];
                                            break;
                                        case '/':
                                            reans = intstore[0] + intstore[1] / intstore[2] / intstore[3];
                                            break;
                                    }
                                    break;
                            }
                            break;
                        case '-':
                            switch (charstore[1])
                            {
                                case '+':
                                    switch (charstore[2])
                                    {
                                        case '+':
                                            reans = intstore[0] - intstore[1] + intstore[2] + intstore[3];
                                            break;
                                        case '-':
                                            reans = intstore[0] - intstore[1] + intstore[2] - intstore[3];
                                            break;
                                        case '*':
                                            reans = intstore[0] - intstore[1] + intstore[2] * intstore[3];
                                            break;
                                        case '/':
                                            reans = intstore[0] - intstore[1] + intstore[2] / intstore[3];
                                            break;
                                    }
                                    break;
                                case '-':
                                    switch (charstore[2])
                                    {
                                        case '+':
                                            reans = intstore[0] - intstore[1] - intstore[2] + intstore[3];
                                            break;
                                        case '-':
                                            reans = intstore[0] - intstore[1] - intstore[2] - intstore[3];
                                            break;
                                        case '*':
                                            reans = intstore[0] - intstore[1] - intstore[2] * intstore[3];
                                            break;
                                        case '/':
                                            reans = intstore[0] - intstore[1] - intstore[2] / intstore[3];
                                            break;
                                    }
                                    break;
                                case '*':
                                    switch (charstore[2])
                                    {
                                        case '+':
                                            reans = intstore[0] - intstore[1] * intstore[2] + intstore[3];
                                            break;
                                        case '-':
                                            reans = intstore[0] - intstore[1] * intstore[2] - intstore[3];
                                            break;
                                        case '*':
                                            reans = intstore[0] - intstore[1] * intstore[2] * intstore[3];
                                            break;
                                        case '/':
                                            reans = intstore[0] - intstore[1] * intstore[2] / intstore[3];
                                            break;
                                    }
                                    break;
                                case '/':
                                    switch (charstore[2])
                                    {
                                        case '+':
                                            reans = intstore[0] - intstore[1] / intstore[2] + intstore[3];
                                            break;
                                        case '-':
                                            reans = intstore[0] - intstore[1] / intstore[2] - intstore[3];
                                            break;
                                        case '*':
                                            reans = intstore[0] - intstore[1] / intstore[2] * intstore[3];
                                            break;
                                        case '/':
                                            reans = intstore[0] - intstore[1] / intstore[2] / intstore[3];
                                            break;
                                    }
                                    break;
                            }
                            break;
                        case '*':
                            switch (charstore[1])
                            {
                                case '+':
                                    switch (charstore[2])
                                    {
                                        case '+':
                                            reans = intstore[0] * intstore[1] + intstore[2] + intstore[3];
                                            break;
                                        case '-':
                                            reans = intstore[0] * intstore[1] + intstore[2] - intstore[3];
                                            break;
                                        case '*':
                                            reans = intstore[0] * intstore[1] + intstore[2] * intstore[3];
                                            break;
                                        case '/':
                                            reans = intstore[0] * intstore[1] + intstore[2] / intstore[3];
                                            break;
                                    }
                                    break;
                                case '-':
                                    switch (charstore[2])
                                    {
                                        case '+':
                                            reans = intstore[0] * intstore[1] - intstore[2] + intstore[3];
                                            break;
                                        case '-':
                                            reans = intstore[0] * intstore[1] - intstore[2] - intstore[3];
                                            break;
                                        case '*':
                                            reans = intstore[0] * intstore[1] - intstore[2] * intstore[3];
                                            break;
                                        case '/':
                                            reans = intstore[0] * intstore[1] - intstore[2] / intstore[3];
                                            break;
                                    }
                                    break;
                                case '*':
                                    switch (charstore[2])
                                    {
                                        case '+':
                                            reans = intstore[0] * intstore[1] * intstore[2] + intstore[3];
                                            break;
                                        case '-':
                                            reans = intstore[0] * intstore[1] * intstore[2] - intstore[3];
                                            break;
                                        case '*':
                                            reans = intstore[0] * intstore[1] * intstore[2] * intstore[3];
                                            break;
                                        case '/':
                                            reans = intstore[0] * intstore[1] * intstore[2] / intstore[3];
                                            break;
                                    }
                                    break;
                                case '/':
                                    switch (charstore[2])
                                    {
                                        case '+':
                                            reans = intstore[0] * intstore[1] * intstore[2] + intstore[3];
                                            break;
                                        case '-':
                                            reans = intstore[0] * intstore[1] / intstore[2] - intstore[3];
                                            break;
                                        case '*':
                                            reans = intstore[0] * intstore[1] / intstore[2] * intstore[3];
                                            break;
                                        case '/':
                                            reans = intstore[0] * intstore[1] / intstore[2] / intstore[3];
                                            break;
                                    }
                                    break;
                            }
                            break;
                        case '/':
                            switch (charstore[1])
                            {
                                case '+':
                                    switch (charstore[2])
                                    {
                                        case '+':
                                            reans = intstore[0] / intstore[1] + intstore[2] + intstore[3];
                                            break;
                                        case '-':
                                            reans = intstore[0] / intstore[1] + intstore[2] - intstore[3];
                                            break;
                                        case '*':
                                            reans = intstore[0] / intstore[1] + intstore[2] * intstore[3];
                                            break;
                                        case '/':
                                            reans = intstore[0] / intstore[1] + intstore[2] / intstore[3];
                                            break;
                                    }
                                    break;
                                case '-':
                                    switch (charstore[2])
                                    {
                                        case '+':
                                            reans = intstore[0] / intstore[1] - intstore[2] + intstore[3];
                                            break;
                                        case '-':
                                            reans = intstore[0] / intstore[1] - intstore[2] - intstore[3];
                                            break;
                                        case '*':
                                            reans = intstore[0] / intstore[1] - intstore[2] * intstore[3];
                                            break;
                                        case '/':
                                            reans = intstore[0] / intstore[1] - intstore[2] / intstore[3];
                                            break;
                                    }
                                    break;
                                case '*':
                                    switch (charstore[2])
                                    {
                                        case '+':
                                            reans = intstore[0] / intstore[1] * intstore[2] + intstore[3];
                                            break;
                                        case '-':
                                            reans = intstore[0] / intstore[1] * intstore[2] - intstore[3];
                                            break;
                                        case '*':
                                            reans = intstore[0] / intstore[1] * intstore[2] * intstore[3];
                                            break;
                                        case '/':
                                            reans = intstore[0] / intstore[1] * intstore[2] / intstore[3];
                                            break;
                                    }
                                    break;
                                case '/':
                                    switch (charstore[2])
                                    {
                                        case '+':
                                            reans = intstore[0] / intstore[1] / intstore[2] + intstore[3];
                                            break;
                                        case '-':
                                            reans = intstore[0] / intstore[1] / intstore[2] - intstore[3];
                                            break;
                                        case '*':
                                            reans = intstore[0] / intstore[1] / intstore[2] * intstore[3];
                                            break;
                                        case '/':
                                            reans = intstore[0] / intstore[1] / intstore[2] / intstore[3];
                                            break;
                                    }
                                    break;
                            }
                            break;
                    }
                    fs.WriteLine(reans.ToString(), Encoding.UTF8);
                }
            }
            fs.Close();
        }
    
}
}
