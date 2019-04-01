using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Program
    {
        public static char[] op = { '+','-','*','/'};
        public static void Main(string[] args)
        {
            string result = null;
            int n;
            Console.WriteLine("请输入您想生成的四则运算题目数：");
            n = int.Parse(Console.ReadLine());
            for (int i=0;i<n;i++)
            {
                result += Calculate(Command())+"\r\n" ;
            }
            Console.WriteLine(result);
            string filename = @"./subject.txt";
            try
            {
                StreamWriter sw = new StreamWriter(filename);
                sw.Write(result+"\n");
                sw.Flush();
                sw.Close();
            }
            catch
            {
                Console.WriteLine("存储文件时出错！");
            }
        }
        public static string Command()//用于生成四则运算式
        {       
            string result = null;
            var randomseed = Guid.NewGuid().GetHashCode();
            Random random = new Random(randomseed);//用随机数种子来生成随机数，避免可能出现的重复
            int num = random.Next(0, 101);
            int opern = random.Next(2, 4);
            result += num;
            for(int i=0;i<opern;i++)
            {
                int opn = random.Next(0, 4);
                num = random.Next(0, 101);
                result = result + op[opn] + num;
            }
            return result;
        }
        public static string Calculate(string question)//计算生成的四则运算式
        {
            DataTable data = new DataTable();
            string r = data.Compute(question, "").ToString();
            while(r.Contains(".")||question.Contains("/0"))
            {
                question = Command();
                r = data.Compute(question, "").ToString();
            }
            while(r.Contains("."))
            {
                question = Command();
                r = data.Compute(question, "").ToString();
            }
            return question + "=" + r;
        }
    }
}
