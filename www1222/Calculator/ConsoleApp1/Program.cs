using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class calculation
    {
        //设aXbYcZd
        public int[][] a;//计算数设为a/b 分子分母分开存储 默认a=0.b=1
        public char[] X;
        public char[] symbol = { '+', '-', '*', '/' };
        public calculation()
        {

        }
        /// <summary>
        /// 生成一个题目并保存至exercises.txt
        /// </summary>
        /// <param name="r">运算数范围</param>
        /// <returns></returns>
        public string GetProblem(int r, ref int[] result, ref int[] ic)
        {
            a = new int[4][] { new int[] { 0, 1 }, new int[] { 0, 1 }, new int[] { 0, 1 }, new int[] { 0, 1 } };
            X = new char[3] { ' ', ' ', ' ' };//默认为空格，方便判断
            //至多有两对括号，且成对出现
            //bool b1 = false, b2 = false;
            //计算式至少有两个运算数，一个运算符，则a，d不为0
            string problem = "";
            //Random rd = new Random(Guid.NewGuid().GetHashCode());
            //int i1 = rd.Next(0, 2);
            //if(i1==1)
            //{
            //    b1 = true;
            //    problem += "(";
            //}
            while (a[0][0] == 0)
            {
                GetNumber(a[0], r, ref problem);
            }
            GetSymbol(a[0][0], ref problem, ref X[0]);
            GetNumber(a[1], r, ref problem);
            GetSymbol(a[1][0], ref problem, ref X[1]);
            GetNumber(a[2], r, ref problem);
            GetSymbol(a[2][0], ref problem, ref X[2]);
            while (a[3][0] == 0)
            {
                GetNumber(a[3], r, ref problem);
            }
            problem += "=";
            ic = IsCommon();
            //Console.WriteLine(problem);
            TreeNode<Number> sym = new TreeNode<Number>();
            GetTree(0, 3, sym);
            LinkBinaryTree<Number> link = new LinkBinaryTree<Number>(sym.Data);
            result = link.GetResult(sym, ref problem);
            return problem;
        }
        /// <summary>
        /// 四个运算数等于随机自然数或真分数
        /// </summary>
        /// <param name="r">数字范围</param>
        /// <param name="pb">运算数输出形式</param>
        /// <returns>运算数计算形式</returns>
        public void GetNumber(int[] a, int r, ref string pb)
        {
            Random rd = new Random(Guid.NewGuid().GetHashCode());
            a[0] = rd.Next(0, r);
            //是否生成真分数
            int c = rd.Next(0, 2);
            //a=0时，不需要写入problem
            if (c == 1 && a[0] != 0)
            {
                //生成分母应大于1
                a[1] = rd.Next(2, r);
                // n += "/" + a[1].ToString();
                if (a[0] >= a[1])
                {
                    if (a[0] % a[1] == 0)
                    {
                        pb += (a[0] / a[1]).ToString() + "  ";
                    }
                    else
                    {
                        int gg = GetCommon(a[0] % a[1], a[1]);
                        pb += (a[0] / a[1]).ToString() + "'" + (a[0] % a[1] / gg).ToString() + "/" + (a[1] / gg).ToString() + "  ";
                    }
                }
                else
                {
                    int g = GetCommon(a[0], a[1]);
                    a[0] /= g;
                    a[1] /= g;
                    pb += a[0].ToString() + "/" + a[1].ToString() + "  ";
                }
            }
            else if (c == 0 && a[0] != 0)
            {
                pb += a[0].ToString() + "  ";
            }
        }
        /// <summary>
        /// 随机取运算符，若a=0，则运算符取+，方便计算结果
        /// </summary>
        /// <param name="a"></param>
        /// <param name="problem"></param>
        /// <param name="X"></param>
        public void GetSymbol(int a, ref string problem, ref char X)
        {
            if (a != 0)
            {
                Random rd = new Random(Guid.NewGuid().GetHashCode());
                X = symbol[rd.Next(0, 4)];
                problem += X.ToString() + "  ";
            }
        }
        /// <summary>
        /// 计算两个数的最大公因子，为分数约分
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int GetCommon(int a, int b)
        {
            int d = 0;
            if (a == 0)
            {
                b = 1;
            }
            else
            {
                while (b % a != 0)
                {

                    d = b % a;
                    b = a;
                    a = d;
                }
                b = a;
            }
            return b;
        }
        /// <summary>
        /// 获取运算符等级
        /// </summary>
        /// <param name="c">当前字符</param>
        /// <returns></returns>
        public static int GetOperationLevel(char c)
        {
            switch (c)
            {
                case '+': return 1;
                case '-': return 1;
                case '*': return 2;
                case '/': return 2;
                default: return 3;
            }
        }
        /// <summary>
        /// 获取优先级最小的运算符
        /// </summary>
        /// <returns></returns>
        public int GetMin(int s, int e, ref int j)
        {
            int min = s;

            for (int i = s; i < e; i++)
            {
                if (X[i] != ' ')
                {
                    j++;
                    if (GetOperationLevel(X[i]) <= GetOperationLevel(X[min]))
                        min = i;
                }
            }
            //运算符空，结束遍历
            return min;
        }
        public void GetTree(int s, int e, TreeNode<Number> sym)
        {
            int j = 0;
            int min = GetMin(s, e, ref j);
            if (j == 0)
            {
                sym.Data = new Number(a[e][0], a[e][1], ' ');
                // Console.WriteLine(sym.Data.Son.ToString() + "/" + sym.Data.Mother.ToString()+sym.Data.Symbol.ToString());
            }
            else
            {
                if (min != -1)
                {
                    sym.Data = new Number(0, 0, X[min]);
                    //   Console.WriteLine(sym.Data.Son.ToString() + "/" + sym.Data.Mother.ToString() + sym.Data.Symbol.ToString());
                    X[min] = ' ';
                    TreeNode<Number> left = new TreeNode<Number>();
                    GetTree(s, min, left);
                    sym.LChild = left;
                    TreeNode<Number> right = new TreeNode<Number>();
                    GetTree(min + 1, e, right);
                    sym.RChild = right;
                }
            }
        }

        /// <summary>
        /// 将计算数相加，与其他计算式的相加值一样时舍去
        /// </summary>
        /// <returns></returns>
        public int[] IsCommon()
        {
            string s = "";
            LinkBinaryTree<Number> ic = new LinkBinaryTree<Number>();
            int[] c = ic.Arithmetic(a[0], a[1], '+', ref s);
            c = ic.Arithmetic(c, a[2], '+', ref s);
            c = ic.Arithmetic(c, a[3], '+', ref s);
            return c;
        }
    }
    public class Number
    {
        public int Son
        {
            get;
            set;
        }
        public int Mother
        {
            get;
            set;
        }

        public char Symbol;
        public Number(int son, int mother, char symbol)
        {
            this.Son = son;
            this.Mother = mother;
            this.Symbol = symbol;
        }
    }
    /// <summary>
    /// 二叉链表结点类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TreeNode<T>
    {
        public T data;               //数据域
        public TreeNode<T> lChild;   //左孩子   树中一个结点的子树的根结点称为这个结点的孩子
        public TreeNode<T> rChild;   //右孩子

        public TreeNode(T val, TreeNode<T> lp, TreeNode<T> rp)
        {
            data = val;
            lChild = lp;
            rChild = rp;
        }

        public TreeNode(TreeNode<T> lp, TreeNode<T> rp)
        {
            data = default(T);
            lChild = lp;
            rChild = rp;
        }

        public TreeNode(T val)
        {
            data = val;
            lChild = null;
            rChild = null;
        }

        public TreeNode()
        {
            data = default(T);
            lChild = null;
            rChild = null;
        }

        public T Data
        {
            get { return data; }
            set { data = value; }
        }

        public TreeNode<T> LChild
        {
            get { return lChild; }
            set { lChild = value; }
        }

        public TreeNode<T> RChild
        {
            get { return rChild; }
            set { rChild = value; }
        }
        /// <summary>
        /// 定义索引文件结点的数据类型
        /// </summary>
        public struct indexnode
        {
            int key;         //键
            int offset;      //位置
            public indexnode(int key, int offset)
            {
                this.key = key;
                this.offset = offset;
            }

            //键属性
            public int Key
            {
                get { return key; }
                set { key = value; }
            }
            //位置属性
            public int Offset
            {
                get { return offset; }
                set { offset = value; }
            }


        }

    }
    public class LinkBinaryTree<T>
    {
        public TreeNode<T> head;       //头引用
        public TreeNode<T> Head
        {
            get { return head; }
            set { head = value; }
        }
        public LinkBinaryTree()
        {
            head = null;
        }
        public LinkBinaryTree(T val)
        {
            TreeNode<T> p = new TreeNode<T>(val);
            head = p;
        }
        public LinkBinaryTree(T val, TreeNode<T> lp, TreeNode<T> rp)
        {
            TreeNode<T> p = new TreeNode<T>(val, lp, rp);
            head = p;
        }
        //判断是否是空二叉树
        public bool IsEmpty()
        {
            if (head == null)
                return true;
            else
                return false;
        }
        //获取根结点
        public TreeNode<T> Root()
        {
            return head;
        }
        //获取结点的左孩子结点
        public TreeNode<T> GetLChild(TreeNode<T> p)
        {
            return p.LChild;
        }
        public TreeNode<T> GetRChild(TreeNode<T> p)
        {
            return p.RChild;
        }
        //将结点p的左子树插入值为val的新结点，原来的左子树称为新结点的左子树
        public void InsertL(T val, TreeNode<T> p)
        {
            TreeNode<T> tmp = new TreeNode<T>(val);
            tmp.LChild = p.LChild;
            p.LChild = tmp;
        }
        //将结点p的右子树插入值为val的新结点，原来的右子树称为新节点的右子树
        public void InsertR(T val, TreeNode<T> p)
        {
            TreeNode<T> tmp = new TreeNode<T>(val);
            tmp.RChild = p.RChild;
            p.RChild = tmp;
        }
        //若p非空 删除p的左子树
        public TreeNode<T> DeleteL(TreeNode<T> p)
        {
            if ((p == null) || (p.LChild == null))
                return null;
            TreeNode<T> tmp = p.LChild;
            p.LChild = null;
            return tmp;
        }
        //若p非空 删除p的右子树
        public TreeNode<T> DeleteR(TreeNode<T> p)
        {
            if ((p == null) || (p.RChild == null))
                return null;
            TreeNode<T> tmp = p.RChild;
            p.RChild = null;
            return tmp;
        }
        //判断是否是叶子结点
        public bool IsLeaf(TreeNode<T> p)
        {
            if ((p != null) && (p.RChild == null) && (p.LChild == null))
                return true;
            else
                return false;
        }



        public List<int[]> num = new List<int[]>();
        public List<char> sym = new List<char>();
        char s;
        //后序遍历
        //遍历根结点的左子树->遍历根结点的右子树->根结点
        public void postorder(TreeNode<Number> ptr, ref string problem)
        {
            if (IsEmpty())
            {
                Console.WriteLine("Tree is Empty !");
                return;
            }
            if (ptr != null)
            {
                postorder(ptr.LChild, ref problem);
                postorder(ptr.RChild, ref problem);
                // Console.WriteLine(ptr.Data.Son.ToString ()  + "/"+ptr .Data.Mother .ToString ()+ptr .Data .Symbol .ToString () );
                char c = ptr.Data.Symbol;
                if (c == '+' || c == '-' || c == '*' || c == '/')
                {
                    sym.Add(c);
                }
                else
                {
                    int[] nn = new int[2] { ptr.Data.Son, ptr.Data.Mother };
                    num.Add(nn);
                }
                if (sym.Count == 1 && num.Count >= 2)
                {
                    num[num.Count - 2] = Arithmetic(num[num.Count - 2], num[num.Count - 1], sym[0], ref problem);
                    num.RemoveAt(num.Count - 1);
                    sym.RemoveAt(0);
                }
            }

        }

        public int[] GetResult(TreeNode<Number> ptr, ref string problem)
        {
            postorder(ptr, ref problem);
            return num[0];
        }

        int s1, s2, s3;
        public int[] Arithmetic(int[] b1, int[] b2, char s, ref string problem)
        {
            int[] result = new int[2];
            switch (s)
            {
                case '+':
                    s1 = b1[0] * b2[1] + b2[0] * b1[1];
                    s2 = b1[1] * b2[1];
                    calculation c1 = new calculation();
                    s3 = c1.GetCommon(s1, s2);
                    result[0] = s1 / s3;
                    result[1] = s2 / s3;
                    break;
                case '-':
                    s1 = b1[0] * b2[1] - b2[0] * b1[1];
                    s2 = b1[1] * b2[1];

                    calculation c2 = new calculation();
                    s3 = c2.GetCommon(s1, s2);
                    result[0] = s1 / s3;
                    result[1] = s2 / s3;
                    //运算过程中出现负数，则主函数进行判断，舍去后重新生成计算式
                    if (s1 < 0)
                    {
                        problem = "重新生成";
                    }
                    break;
                case '*':
                    s1 = b1[0] * b2[0];
                    s2 = b1[1] * b2[1];
                    calculation c3 = new calculation();
                    s3 = c3.GetCommon(s1, s2);
                    result[0] = s1 / s3;
                    result[1] = s2 / s3;
                    break;
                case '/':
                    s1 = b1[0] * b2[1];
                    s2 = b1[1] * b2[0];
                    calculation c4 = new calculation();
                    s3 = c4.GetCommon(s1, s2);
                    result[0] = s1 / s3;
                    result[1] = s2 / s3;
                    break;
            }
            return result;
        }
    }


    public class Program
    {
        public static int Add(int num1, int num2)
        {
            
            {
                return num1 + num2;
            }
            
               
        }


        public static void Main(string[] args)
        {
            int r = 10;
            int n = 1;
            int[] result = new int[2];
            Console.WriteLine("请输入生成题目的数量");
            string nn = Console.ReadLine();
            while (int.TryParse(nn, out n) == false)
            {
                Console.WriteLine("输入有误，请重新输入数字");
                nn = Console.ReadLine();
            }
            Console.WriteLine("请输入题目中数值的范围");
            nn = Console.ReadLine();
            while (int.TryParse(nn, out r) == false)
            {
                Console.WriteLine("输入有误，请重新输入数字");
                nn = Console.ReadLine();
            }
            calculation c = new calculation();
            int[][] ic = new int[n][];//n个计算式中计算数的和数
            for (int i = 0; i < n; i++)
            {
                string a = c.GetProblem(r, ref result, ref ic[i]);
                for (int j = 0; j < i; j++)
                {
                    if (ic[j] == ic[i])
                        a = "重新生成";
                }
                while (a == "重新生成")
                {
                    a = c.GetProblem(r, ref result, ref ic[i]);
                    for (int j = 0; j < i; j++)
                    {
                        if (ic[j] == ic[i])
                            a = "重新生成";
                    }
                }
                //将题目存入subject.txt中，可追加
                using (StreamWriter sw = new StreamWriter(@"D:\Github\Calculation\test\subject.txt", true))
                {
                    sw.WriteLine(i + ".四则运算题目 " + a);
                }
                //将答案存入subject.txt
                using (StreamWriter sw = new StreamWriter(@"D:\Github\Calculation\test\subject.txt", true))
                {
                    if (result[0] == 0 || result[1] == 1)
                        sw.WriteLine(i + ".答案 " + result[0].ToString());
                    else
                        sw.WriteLine(i + ".答案 " + result[0].ToString() + "/" + result[1].ToString());
                }
            }
            Console.ReadKey();

        }
    }
}
