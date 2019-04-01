using System;
using System.Data;
using System.IO;

namespace Calculator
{
    public class Program
    {
        public static string[] Operation = { "+", "-", "*", "/" };

        public static string Make_Formula()//产生式子
        {
            string formula = null;
            var seed = Guid.NewGuid().GetHashCode();//C#中默认以时间作为随机数种子，那么随机生成的运算式子很多都是相同的（伪随机），用这种方法生成随机数种子使随机生成的式子不相同
            Random random = new Random(seed);
            int number_1 = random.Next(0, 101);//运算数字的取值范围为[0,100]
            int number_2 = random.Next(2, 4);//运算符个数
            formula = number_1.ToString();
            for (int i = 1; i <= number_2; i++)
            {
                number_1 = random.Next(0, 101);//运算数字的取值范围为[0,100]
                int operation = random.Next(0, 4);//随机产生运算符
                formula = formula + Operation[operation] + number_1.ToString();
            }
            return formula;
        }

        public static string Calculate(string formula)//计算式子
        {
            DataTable dt = new DataTable();
            string result = dt.Compute(formula, "").ToString();//利用DataTable提供方法对随机产生的字符串式子进行运算
            while (formula.Contains("/0") || result.Contains(".") || Convert.ToInt32(result) < 0)//检查运算过程中是否有除0操作、运算结果是否有小数或负数。
            {
                formula = Make_Formula();
                result = dt.Compute(formula, "").ToString();
            }
            return result;
        }

        static void Main(string[] args)
        {
            Console.Write("请输入您需要的算术个数（输入后按Enter键继续）：");
            int n = Convert.ToInt32(Console.ReadLine());
            StreamWriter sw = new StreamWriter(@"E:\QQPCMgr(1)\Desktop\第二次作业\AchaoCalculator\subject.txt");
            for (int i = 0; i < n; i++)
            {
                string formula = Make_Formula();//需运算式子的左边部分
                string result = Calculate(formula);//计算式子的结果
                string final_MathFormula = formula + "=" + result;//整个数学等式
                Console.WriteLine(final_MathFormula);//在屏幕上打印用户想要的n个四则运算式子
                sw.WriteLine(final_MathFormula);//将运算式子写入TXT文件“subject.txt”中
            }
            sw.Close();//关闭文件
        }
    }
}
