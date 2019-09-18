using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 阿超家里的孩子上小学一年级了
/// 这个暑假老师给家长们布置了一个作业
/// 家长每天要给孩子出一些合理的
/// 但要有些难度的四则运算题目
/// 并且家长要对孩子的作业打分记录
/// 作为程序员的阿超心想
/// 既然每天都需要出题
/// 那何不做一个可以自动生成小学四则运算题目与解决题目的命令行 “软件”呢
/// 他把老师的话翻译一下
/// 就形成了这个软件的需求
/// 程序接收一个命令行参数 n
/// 然后随机产生 n道加减乘除（分别使用符号+-*/来表示）练习题
/// 每个数字在 0 和 100 之间，运算符在 2 个 到3 个之间。
/// 由于阿超的孩子才上一年级，并不知道分数。
/// 所以软件所出的练习题在运算过程中不得出现非整数
/// 比如不能出现 3÷5+2=2.6 这样的算式
/// 练习题生成好后
/// 将生成的 n道练习题及其对应的正确答案输出到一个文件 subject.txt中
/// 当程序接收的参数为4时
/// 以下为一个输出文件示例。
/// 13+17-1=29
/// 11*15-5=160
/// 3+10+4-16=11
/// 5÷5+3-2=4
/// </summary>


namespace ConsoleApp1
{
    class G
    {
        public int GetN(int x, int y)
        {
            return new Random(Guid.NewGuid().GetHashCode()).Next(x, y);
        }
    }

    class Num
    {


        public bool Isdivdent(int n1, int n2)//判断除法结果是否为整数，以及被除数是否为零
        {
            if (n1 % n2 == 0 && n2 != 0)
                return true;
            else return false;
        }


        public int sCount(int op, int n1, int n2)//计算
        {
            int result = 0;
            switch (op)
            {
                case 0:
                    result = n1 + n2;
                    break;
                case 1:
                    result = n1 - n2;
                    break;
                case 2:
                    result = n1 * n2;
                    break;
                case 3:
                    result = n1 / n2;
                    break;
                default:
                    break;
            }
            return result;
        }
        

        public int Count()
        {
            G g = new G();
            int[] op = new int[3];  //存储参与计算的运算符，数组容量3 ---  +（0）、-（1）、*（2）、/（3）、计算过（4）
            int result= 0;//存放答案    
            int m = g.GetN(2, 4);//m随机决定运算符个数m——2或3个运算符
            cc:int[] n = new int[4];   //存储参与计算的数字，数组容量4
                 
            int i,;
            for (i = 0; i < m; i++)
            {
                op[i] = g.GetN(0, 4);     //随机运算符
            }
            char[] t = new char[3]; //打印用存放符号数组
            for (i = 0; i < m; i++)
            {
                switch (op[i])
                {
                    case 0:
                        t[i] = '+';
                        break;
                    case 1:
                        t[i] = '-';
                        break;
                    case 2:
                        t[i] = '*';
                        break;
                    case 3:
                        t[i] = '/';
                        break;
                    default:
                        break;
                }
            }
            for (i = 0; i < m + 1; i++) //根据运算符个数匹配相应的随机运算数
            {
                n[i] = g.GetN(1, 100);
            }
           
            Console.Write("{0} ", n[0]);
            for (i = 0; i < m; i++)
            {
                Console.Write("{0} ", t[i]);
                Console.Write("{0} ", n[i + 1]);
            }
            Console.Write("= ");

            for (i = 0; i < m; i++)
            {
                if (op[i] == 2 || op[i] == 3)
                {
                    if (op[i] == 2)
                        n[i] = sCount(op[i], n[i], n[i + 1]);
                    else if (op[i] == 3)
                    {
                        if (Isdivdent(n[i], n[i + 1]))
                        {
                            n[i] = sCount(op[i], n[i], n[i + 1]);
                            
                        }
                        else goto cc;   //如果除法计算数不满足要求，则推回重新随机数字
                    }
                    result = n[i];
                    op[i] = 4;          //标志此计算符已经计算过，计算结果放于n数组中与计算符同标位置
                }
            }
            for (i = 0; i < m; i++)
            {
                if (op[i] == 1 || op[i] == 0)
                {
                    if(i > 0 && n[i-1] == -1)
                        result += sCount(op[i], n[i-1], n[i + 1]);
                    else
                        result += sCount(op[i], n[i], n[i+1]);
                }
            }
            return result;
        }
    }




    class Program
    {
        static void Main(string[] args)
        {
            Num num = new Num();
            Console.WriteLine("Please input the number of question you want:");
            string str = Console.ReadLine();
            int n = Convert.ToInt32(str);
            int[] result = new int[n];
            for (int j = 0; j < n; j++)
            {
                result[j] = num.Count();
                Console.WriteLine("{0}", result[j]);
            }

            Console.ReadLine();

        }

    }
}


