using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp2
{
    class Pro1
    {
        public Pro1(int n)  //构造函数开始生成算式
        {
            Run(n);
        }
        private struct Node //存储算式x,y,z表示数字大小，a,b表示运输符号，sm表示算式运算结果
        {
            public int x, y, z, a, b, sm;
        }
        private char Pri(int n)//输出符号
        {
            if (n == 1)
                return '+';
            else if (n == 2)
                return '-';
            else if (n == 3)
                return '*';
            else
                return '/';
        }
        private int Com(int a,int b,int c)//单次运算，b表示运算符号，a,c表示运算数字
        {
            if (b == 1)
                return a + c;
            else if (b == 2)
                return a - c;
            else if (b == 3)
                return a * c;
            else
                return a / c;
        }
        private int Sum(Node k)//运算算式返回结果
        {
            if (k.a > 2 || k.b <= 2)
                return Com(Com(k.x, k.a, k.y), k.b, k.z);
            return Com(k.x, k.a, Com(k.y, k.b, k.z));
        }
        private bool Judge(List<Node> data,Node k)//判断算式是否符合标准
        {
            for (int i = 0; i < data.Count; i++)//检查之前是否出现过该算式
                if (data[i].x == k.x && data[i].y == k.y && data[i].z == k.z && data[i].a == k.a && data[i].b == k.b)
                    return false;
            if (k.a == 4 && (k.x / k.y * k.y) != k.x)//检查是否出现小数
                return false;
            if (k.b == 4)//检查是否出现小数
            {
                if (k.a <= 2 && (k.y / k.z * k.z) != k.y)
                    return false;
                if (k.a > 2 && (Com(k.x, k.a, k.y) / k.z * k.z) != Com(k.x, k.a, k.y))
                    return false;
            }
            if (Sum(k) < 0)//检查是否出现负数
                return false;
            return true;
        }
       
        private Node Ad(List<Node> data)//随机生成算式，并判断是否合法
        {
            Random key = new Random();
            while (true)
            {
                Node k = new Node();
                k.x = key.Next(1, 100);
                k.a = key.Next(1, 5);
                k.y = key.Next(1, 100);
                k.b = key.Next(1, 5);
                k.z = key.Next(1, 100);
                if (Judge(data, k))
                {
                    k.sm = Sum(k);
                    return k;
                }
            }
        }
        private void Run(int n)//接收n生成n个算式
        {
            List<Node> data = new List<Node>();//定义一个线性表用于储存算式
            for (int i = 0; i < n; i++)//调用Ad函数生成n个算式，储存在线性表中
                data.Add(Ad(data));
            StreamWriter sw = new StreamWriter(@"F:\acm\ConsoleApp2\ConsoleApp2\t1.txt");//把算式打印到文件中
            Console.SetOut(sw);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(data[i].x + "" + Pri(data[i].a) + "" + data[i].y + "" + Pri(data[i].b) + "" + data[i].z + "=" + data[i].sm);
            }
            sw.Flush();
            sw.Close();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());//读入n，表示生成n个算式
            Pro1 pro = new Pro1(n);//开始执行程序
        }
    }
}
