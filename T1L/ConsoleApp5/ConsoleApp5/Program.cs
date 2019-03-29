using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace JISUANQI
{
    class Subject
    {
        public List<double> num;               
        public List<int> op;                
        public double result;                   
        public Subject()                       
        {
            num = new List<double>();
            op = new List<int>();
            result = 0;
        }
        public void set(List<double> num, List<int> op)
        {
            this.num = num;
            this.op = op;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("需要多少道题");
            int n = Convert.ToInt32(Console.ReadLine());
            SuiJi(n);
            Console.ReadKey();
        }
        public static List<double> SuiJiShu(int m)
        {
            List<double> num = new List<double>();
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < m; i++)
                num.Add(rand.Next(101));
            return num;
        }
        public static List<int> SuiJiFuHao(int x)
        {
            List<int> op = new List<int>();
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            for (int i = 0; i < x; i++)
                op.Add(rand.Next(1,5));
            return op;
        }
        public static Subject RES(Subject a)
        {
            double result = 0;
            if (a.num.Count == 1)
            {
                a.result = a.num[0];
                return a;
            }
            else if (a.op.Exists(x => x == 3) || a.op.Exists(x => x == 4))
            {
                for (int i = 0; i < a.op.Count; i++)
                {
                    if (a.op[i] == 3 || a.op[i] == 4)
                    {
                        result = Result(a.num[i], a.num[i + 1], a.op[i]);
                        a.num[i] = result;
                        a.op.RemoveAt(i);
                        a.num.RemoveAt(i + 1);
                        return RES(a);
                    }
                }
            }
            else
            {
                result = Result(a.num[0], a.num[1], a.op[0]);
                a.num[0] = result;
                a.num.RemoveAt(1);
                a.op.RemoveAt(0);
                return RES(a);
            }
            return RES(a);
        }
        public static void SuiJi(int n)
        {
            Subject a = new Subject();                                    
            Random rd = new Random(Guid.NewGuid().GetHashCode());
            List<double> num = new List<double>();                          
            List<int> op = new List<int>();                            
            string path = @"C:\Users\RAIse\Desktop\四则运算.txt";         
            FileStream FS = new FileStream(path, FileMode.Append);          
            StreamWriter SW = new StreamWriter(FS);
            for (int i = 0; i < n;)
            {
                int m = rd.Next(3, 5);                                       
                num = SuiJiShu(m);                                        
                op = SuiJiFuHao(m - 1);                              
                a.set(num, op);                                        
                StringBuilder s = new StringBuilder();
                s.Append(string.Format("({0}) ", i + 1));
                s.Append(a.num[0].ToString());
                for (int k = 0; k < a.op.Count; k++)
                {
                    s.Append(" ");
                    s.Append(OP(a.op[k]));
                    s.Append(" ");
                    s.Append(a.num[k + 1]);
                }
                s.Append("  =  " + RES(a).result.ToString());
                if (RES(a).result < 0 || (RES(a).result % 1) != 0 || RES(a).result > 300)
                    continue;
                else
                {
                    i++;
                    Console.WriteLine(s.ToString());
                    SW.WriteLine(s.ToString());         
                }
            }
            SW.Close();
            FS.Close();
        }
        public static double Result(double x, double y,int a )
        {
            double result = 0;
            if (a == 1)
                result = x + y;
            else if (a == 2)
                result = x - y;
            else if (a == 3)
                result = x * y;
            else if (a == 4)
                result = x / y;
            return result;
        }
        public static string OP(int a)
        {
            if (a == 1)
                return "+";
            else if (a == 2)
                return "-";
            else if (a == 3)
                return "*";
            else
                return "/";
        }        
    }
}

