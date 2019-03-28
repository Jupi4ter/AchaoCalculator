using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ALei
{
    public class RandomMaker
    {
        int min;
        int max;
        int length;
        public RandomMaker(int a, int b)
        {
            min = a;
            max = b + 1;
        }
        public int[] makerandom(int n)
        {
            length = n;
            int[] result = new int[length];
            Random random = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < length; i++)
            {
                result[i] = random.Next(min, max);
            }
            return result;
        }
    }

    public class Ti
    {
        int[] symble;
        int[] number;
        int n;//输入n就生成n个数字，n-1个符号，组成算式
        string s;
        public string gets()
        {
            return s;
        }
        public Ti(int n)
        {
            this.n = n;
            RandomMaker rm1 = new RandomMaker(1, 4);
            symble = rm1.makerandom(n - 1);
            RandomMaker rm2 = new RandomMaker(0, 100);
            number = rm2.makerandom(n);
        }
        public void make()
        {
            int num = n * 2 - 1;
            s = Convert.ToString(number[0]);
            for (int i = 1; i < num; i++)
            {
                if (i % 2 == 0)
                {
                    s += Convert.ToString(number[i / 2]);
                }
                else
                {
                    switch (symble[i / 2])
                    {
                        case 1:
                            s += "+";
                            break;
                        case 2:
                            s += "-";
                            break;
                        case 3:
                            s += "*";
                            break;
                        case 4:
                            s += "/";
                            break;
                        default:
                            Console.WriteLine("错误！");
                            break;
                    }
                }
            }
        }
        public int errorti()//是否可以用引用？？？？？？？？？？？？？？？？？
        {
            //判断结果是否为负数//判断分母不为0
            int id = Array.IndexOf(symble, 2);
            if (id != -1)
            {
                if (result() < 0)
                {
                    return -1;
                }
            }
            //判断结果有没有小数
            id = Array.IndexOf(symble, 4);
            if (id != -1)
            {
                //计算结果的函数
                if (Convert.ToString(result()).Contains("."))
                {
                    return -1;
                }
                if (result() > 10000)
                {
                    return -1;
                }
            }
            return 1;
        }
        public double result()
        {
            double re;
            DataTable dt = new DataTable();
            re = Convert.ToDouble(dt.Compute(s, "false"));
            //捕捉错误？？？？？？？？？？？？
            return re;
        }
    }
    public class TiMaker
    {
        int counter;
        public void Doit(int n, int type)
        {
            counter = 0;
            do
            {
                Ti ti = new Ti(type);
                ti.make();
                if (ti.errorti() != 1)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine(ti.gets() + " = ");
                    counter++;
                }
            } while (counter < n);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt16(Console.ReadLine());
            int ti_3 = n / 2;
            int ti_4 = n - ti_3;
            TiMaker tm = new TiMaker();
            tm.Doit(ti_3, 3);
            tm.Doit(ti_4, 4);
        }
    }
}
