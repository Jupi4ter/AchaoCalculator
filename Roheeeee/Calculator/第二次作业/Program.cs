using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace 第二次作业
{
    public class Program
    {
        //生成四则运算式
        public static char[] op = { '+', '-', '*', '/' };
        public static string Exam()
        {
            Random num = new Random();
            int num1, num2,operators,opnum, i;
            num1=num.Next(0, 101);
            operators=num.Next(2, 4);
            string equation = null;
            equation += num1;
            for (i = 0; i < operators; i++)
            {
                num2 = num.Next(0, 101);
                opnum = num.Next(0, 4);
                equation=equation+op[opnum] + num2;
            }

            return equation;
        }
        //生成答案
        public static string operation(string equation)
        {

            object o = new DataTable().Compute(equation, "");
            while (o.ToString().Contains("."))
            {
                equation = Exam();
                o = new DataTable().Compute(equation, "");
            }
            string result = equation + "=" + o.ToString();
            return result;
        }
        public static void Main(string[] args)
        {

            int n;
            string result = null;
            Console.WriteLine("请输入题目数量：");
            n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                result = result + operation(Exam()) + "\n";
            }
            Console.WriteLine(result);
            FileStream fs = new FileStream(@"D:\subject.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write("operation");
            sw.Close();
            fs.Close();

        }
      
    }
}

