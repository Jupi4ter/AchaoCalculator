using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace 四则运算生成器
{
    class Program
    {
        static void Main(string[] args)
        {
            subProduce(100);
        }

        /// <summary>
        ///  随机生成n道四则运算题目和答案并输出至“subject.txt”文件中
        /// </summary>
        /// <param name="n">要生成的题目数</param>
        public static void subProduce(int n)
        {
            Subject sb = new Subject();                                     //创建一个储存题目数据的对象
            Random r = new Random(Guid.NewGuid().GetHashCode());
            List<double> num = new List<double>();                          //创建一个双精度集合储存随机生成的数
            List<int> symbol = new List<int>();                             //用于储存随机生成的运算符号
            string path = @"D:\四则运算题.txt";                              //文件的路径
            FileStream fs1 = new FileStream(path, FileMode.Create);         //若文件不存在则创建文件，若存在则覆盖内容
            fs1.Close();
            FileStream fs = new FileStream(path, FileMode.Append);          //以追加方式打开文件
            StreamWriter sw = new StreamWriter(fs);
            //生成n道题目和答案并输出
            for(int i = 0;i < n;)                                           
            {
                int m = r.Next(3, 5);                                       //因为要生成的四则运算至少有三个数，最多有四个数
                num = numProduce(m);                                        //生成随机数
                symbol = symbolProduce(m - 1);                              //生成m-1个运算符号
                sb.set(num, symbol);                                        //储存数据到类中
                //构造要输出的四则运算字符串
                StringBuilder s = new StringBuilder();
                s.Append(string.Format("({0}) ", i + 1));
                s.Append(sb.num[0].ToString());
                for(int j = 0;j<sb.symbol.Count;j++)
                {
                    s.Append(" ");
                    s.Append(whichSymbol(sb.symbol[j]));
                    s.Append(" ");
                    s.Append(sb.num[j + 1]);
                }
                //计算结果并添加到字符串中
                s.Append(" = " + CalculateResult(sb).result.ToString());
                if (CalculateResult(sb).result < 0 || (CalculateResult(sb).result % 1) != 0 || CalculateResult(sb).result > 500)
                    continue;
                else
                {
                    i++;
                    Console.WriteLine(s.ToString());
                    sw.WriteLine(s.ToString());         //写入文件
                }
            }
            sw.Close();
            fs.Close();
        }

        /// <summary>
        /// 随机生成m个0-100之间的数
        /// </summary>
        /// <param name="m">要生成的个数</param>
        /// <returns>一个双精度小数集合</returns>
        public static List<double> numProduce(int m)
        {
            List<double> num = new List<double>();
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < m;i++ )
                num.Add(rand.Next(101));
            return num;
        }

        /// <summary>
        /// 随机生成x个+.-.*./符号分别用0.1.2.3代替并储存在一个整型集合中返回
        /// </summary>
        /// <param name="x">要生成的符号个数</param>
        /// <returns>一个整型集合</returns>
        public static List<int> symbolProduce(int x)
        {
            List<int> symbol = new List<int>();
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < x; i++)
                symbol.Add(rand.Next(4));
            return symbol;
        }

        /// <summary>
        /// 计算两个数的+.-.*./结果
        /// </summary>
        /// <param name="a">运算符，0.1.2.3分别代表+.-.*./运算符</param>
        /// <param name="x">第一个运算数据</param>
        /// <param name="y">第二个运算数据</param>
        /// <returns></returns>
        public static double Calculate(int a, double x, double y)
        {
            double result = 0;
            if (a == 0)
                result = x + y;
            else if (a == 1)
                result = x - y;
            else if (a == 2)
                result = x * y;
            else if (a == 3)
                result = x / y;
            return result;
        }
        /// <summary>
        /// 判断运算符
        /// </summary>
        /// <param name="a">0.1.2.3分别代表+ - * /运算符</param>
        /// <returns></returns>
        public static string whichSymbol(int a)
        {
            if (a == 0)
                return "+";
            else if (a == 1)
                return "-";
            else if (a == 2)
                return "*";
            else
                return "/";
        }
        /// <summary>
        /// 递归计算四则运算题目的结果并返回
        /// </summary>
        /// <param name="sb"></param>
        /// <returns>一个题目类</returns>
        public static Subject CalculateResult(Subject sb)
        {
            double result_1 = 0;            //临时计算结果
            if (sb.num.Count == 1)          //若计算完毕返回结果
            {
                sb.result = sb.num[0];
                return sb;
            }
            else if (sb.symbol.Exists(x => x == 2) || sb.symbol.Exists(x => x == 3))    //若运算中有*或/运算优先计算掉
            {
                for (int i = 0; i < sb.symbol.Count; i++)
                {
                    if (sb.symbol[i] == 2 || sb.symbol[i] == 3)                         //找到第一个为*或/的运算符
                    {
                        result_1 = Calculate(sb.symbol[i], sb.num[i], sb.num[i + 1]);   //将这个运算符计算掉
                        //将计算结果保存并生成一个新的四则运算
                        sb.num[i] = result_1;
                        sb.num.RemoveAt(i+1);
                        sb.symbol.RemoveAt(i);
                        return CalculateResult(sb);
                    }
                }
            }
            else                                                                        //运算中只有+.-运算
            {
                result_1 = Calculate(sb.symbol[0], sb.num[0], sb.num[1]);
                //将计算结果保存并生成一个新的四则运算
                sb.num[0] = result_1;
                sb.num.RemoveAt(1);
                return CalculateResult(sb);
            }
            return CalculateResult(sb);
        }
    }

    /// <summary>
    /// 自定义题目类
    /// </summary>
    class Subject
    {
        public List<double> num;                //用于储存题目中的计算数
        public List<int> symbol;                //用于储存题目中的计算符号
        public double result;                   //用于储存题目计算结果
        public Subject()                        //无参构造
        {
            num = new List<double>();
            symbol = new List<int>();
            result = 0;
        }
        public void set(List<double> num, List<int> symbol)//赋值函数
        {
            this.num = num;
            this.symbol = symbol;
        }
    }
}
