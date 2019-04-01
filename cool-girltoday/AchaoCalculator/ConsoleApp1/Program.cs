using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Problem
    {
        private int n;
        private Random rd = new Random();
        private char[] op_int2char = { '+', '-', '*', '/' };
        public Problem(int n)
        {
            this.n = n;
            CreateEquation();
        }
        private bool chack(int lef, char op, int rig, ref int ans)
        {
            if (op == '+') ans = lef + rig;
            else if (op == '-') ans = lef - rig;
            else if (op == '*') ans = lef * rig;
            else
            {
                if (rig == 0) return false;
                else if (lef % rig != 0) return false;
                else ans = lef / rig;
            }
            return true;
        }

        public string SolveAndCheck(int v)
        {
            throw new NotImplementedException();
        }

        private bool check(char a, char b)
        {
            if (a == '+' || a == '-') return true;
            if (a == '*' || a == '/')
            {
                if (b == '+' || b == '-') return false;
                return true;
            }
            return false;
        }
        //结构体保存后缀表达式节点
        struct node
        {
            public bool type;
            //false -> int
            //true -> char
            public int val;
            public char op;
            public node(bool a, int b, char c)
            {
                type = a;
                val = b;
                op = c;
            }
        }
        //结构体保存生成的问题
        struct problem
        {
            public string equation;
            public int ans;
            public problem(string a, int b)
            {
                equation = a;
                ans = b;
            }
        }
        List<problem> pro = new List<problem>();
        public char[] op = new char[1000];
        public int[] arr = new int[1000];
        Stack<int> st = new Stack<int>();
        Stack<char> stack = new Stack<char>();
        List<node> output = new List<node>();
        private void CreateNum(int op_cnt)
        {
            while (true)
            {
                //生成等式
                for (int i = 0; i < op_cnt; ++i)
                {
                    op[i] = op_int2char[rd.Next(0, 4)];
                    arr[i] = rd.Next(1, 100);
                }
                arr[op_cnt] = rd.Next(1, 100);
                output.Clear();
                stack.Clear();
                st.Clear();
                //转换为后缀表达式
                for (int i = 0; i < op_cnt + 1; ++i)
                {
                    output.Add(new node(false, arr[i], ' '));
                    if (i < op_cnt)
                    {
                        while (stack.Count != 0)
                        {
                            if (check(op[i], stack.Peek()))
                            {
                                output.Add(new node(true, 0, stack.Pop()));
                            }
                            else break;
                        }
                        stack.Push(op[i]);
                    }
                }
                if (stack.Count != 0) output.Add(new node(true, 0, stack.Pop()));

                //检查等式是否合法
                bool flg = true;
                for (int i = 0; i < output.Count; ++i)
                {
                    if (output[i].type == false) st.Push(output[i].val);
                    else
                    {
                        char op_type = output[i].op;
                        int a = st.Pop(), b = st.Pop();
                        int c = 0;
                        if (!chack(a, op_type, b, ref c))
                        {
                            flg = false;
                            break;
                        }
                        else st.Push(c);
                    }
                }
                if (flg)
                {
                    string tit = arr[0].ToString();
                    for (int i = 0; i < op_cnt; ++i)
                    {
                        tit += op[i].ToString();
                        tit += arr[i + 1].ToString();
                    }
                    pro.Add(new problem(tit, st.Pop()));
                    break;
                }
            }
        }
        //写入到文件
        private void Write2File()
        {
            StreamWriter sw = new StreamWriter(@".\subject.txt", false, Encoding.UTF8);
            foreach (problem p in pro)
            {
                sw.WriteLine("{0}={1}", p.equation, p.ans);
            }
            sw.Close();
        }
        //创建等式函数
        private void CreateEquation()
        {
            for (int i = 0; i < this.n; ++i)
            {
                int op_cnt = rd.Next(2, 4); //随机产生2-3个运算符
                CreateNum(op_cnt); //调用生成问题函数
            }
            for (int i = 0; i < this.n; ++i)
            {
                Console.WriteLine("{0}=", pro[i].equation);
            }
            Write2File();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Problem problem = new Problem(n);
            Console.Read();
        }
    }
}
