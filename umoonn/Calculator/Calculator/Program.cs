using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
namespace Calculator
{
    public class Program
    {
        static public int P(int oprandcount, int[] number, char[] opp)
        {
            DataTable data = new DataTable();
            string a;
            double b;
            if (oprandcount == 2)
            {
                a = number[0].ToString() + opp[0] + number[1].ToString() + opp[1] + number[2].ToString();
                b = Convert.ToDouble(data.Compute(a, "false "));
                if (!(b % 2 != 1 && b % 2 != 0 || b < 0))
                {
                    using (StreamWriter sw = File.AppendText(@"F:\r.txt"))
                    {
                        sw.WriteLine(a + "=" + b);
                        sw.Flush();
                        return 1;
                    }
                }
                else
                {
                    return 0;
                }
            }
            if (oprandcount == 3)
            {
                a = number[0].ToString() + opp[0] + number[1].ToString() + opp[1] + number[2].ToString() + opp[2] + number[3].ToString();
                b = Convert.ToDouble(data.Compute(a, "false "));
                if (!(b % 2 != 1 && b % 2 != 0 || b < 0))
                {
                    using (StreamWriter sw = File.AppendText(@"F:\r.txt"))
                    {
                        sw.WriteLine(a + "=" + b);
                        sw.Flush();
                        return 1;
                    }
                }
                else
                {
                    return 0;
                }
            }
            else return 0;
        }
        static void Main(string[] args)
        {
            int count = 0;
            int num;//出题数目
            num = int.Parse(Console.ReadLine());
            Random rand = new Random(); //创建随机数对象           
            DataTable data = new DataTable();
            for (; count != num;)
            {
                int oprandcount = rand.Next(2, 4);//确定生成运算符的个数
                int[] number = new int[oprandcount + 1];
                char[] opp = new char[oprandcount];
                for (int i = 0; i < oprandcount + 1; i++)
                {
                    number[i] = rand.Next(0, 101);
                }
                for (int i = 0; i < oprandcount; i++)
                {
                    int op = rand.Next(1, 5);
                    switch (op)
                    {
                        case 1:
                            opp[i] = '+';
                            break;
                        case 2:
                            opp[i] = '-';
                            break;
                        case 3:
                            opp[i] = '*';
                            break;
                        case 4:
                            opp[i] = '/';
                            break;
                    }
                }
                count += P(oprandcount, number, opp);
            }
        }
    }
}