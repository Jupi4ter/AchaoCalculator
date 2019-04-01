using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
namespace ConsoleApp1
{
    //�½�һ����������������洢���㷽��
    class Calculator
    {
        IList fhList = new List<string>();
        //�����ۺ�������ɵ�number�ͷ���
        IList contest = new List<string>();
        string str= "";
        //isok�����ж��Ƿ���������
        int isok = 1;

        public int Getisok()
        {
            return isok;
        }

        public string Gettimu()
        {
            return str;
        }
        IList numberList = new List<int>();
        Random random = new Random();
        public int Genelment()
        {
            int fhlen = random.Next(2, 4);
            for (int i = 0; i <= fhlen; i++)
            {
                int num = random.Next(101);
                numberList.Add(num);
            }
            return fhlen;
        }
        public string Gensign(int length)
        {
            for (int i = 0; i < length; i++)
            {
                int fh = random.Next(1, 5);
                switch (fh)
                {
                    case 1:
                        fhList.Add("+");
                        continue;
                    case 2:
                        fhList.Add("-");
                        continue;
                    case 3:
                        fhList.Add("*");
                        continue;
                    case 4:
                        fhList.Add("/");
                        continue;
                }
            }
            return "";
        }
        //���ʵ�������ʽ
        public int Cal(int a, int b, string sign)
        {
            if (sign == "+")
            {
                return a + b;
            }
            if (sign == "-")
            {
                return a - b;
            }
            if (sign == "*")
            {
                return a * b;
            }
            return 0;
        }
        //�����������ͬʱ������֮��ķ�������
        public int Calprior()
        {
            int result = 0;
            if (((fhList[0] == "+" | fhList[0] == "-") & (fhList[1] == "+" | fhList[1] == "-")) | 
                ((fhList[0] == "/" | fhList[0] == "*") & (fhList[1] == "/" | fhList[1] == "*")) | 
                ((fhList[0] == "/" | fhList[0] == "*") & (fhList[1] == "+" | fhList[1] == "-")))
            {
                result = Cal(Convert.ToInt32(numberList[0]), Convert.ToInt32(numberList[1]), Convert.ToString(fhList[0]));
                result = Cal(result, Convert.ToInt32(numberList[2]), Convert.ToString(fhList[1]));
            }
            else
            {
                result = Cal(Convert.ToInt32(numberList[1]), Convert.ToInt32(numberList[2]), Convert.ToString(fhList[1]));
                result = Cal(Convert.ToInt32(numberList[0]), result, Convert.ToString(fhList[0]));
            }
            return result;
        }
        public int Genresult()
        {
            int i = 0;
            try
            {
                while (true)
                {
                    contest.Add(Convert.ToString(numberList[i]));
                    contest.Add(fhList[i]);
                    i++;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                int result = 0;
                foreach (string k in contest)
                {
                    str += k;
                }
                if (i == 2)
                {
                    result = Calprior();

                }
                //���Ƿ��ŵ����ȼ�
                if (i == 3)
                {
                    if (fhList[2] == "+" | fhList[2] == "-")
                    {
                        result = Calprior();
                        result = Cal(result, Convert.ToInt32(numberList[3]), Convert.ToString(fhList[2]));
                    }
                    else
                    {
                        result = Cal(Convert.ToInt32(numberList[3]), Convert.ToInt32(numberList[2]), Convert.ToString(fhList[2]));
                        numberList[2] = result;
                        result = Calprior();
                    }
                }
                return result;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("��Ҫ���ɵ���Ŀ������");
            int Howmany = 0;
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                Calculator calculator = new Calculator();
                //����Calculator�༰����
                int fhlen = calculator.Genelment();
                string _ = calculator.Gensign(fhlen);
                int result = calculator.Genresult();
                string timu = calculator.Gettimu();
                int isok = calculator.Getisok();
                if ((isok != 1) | (result < 0))
                {
                    num++;
                }
                else
                {
                    Howmany += 1;
                    Console.WriteLine("���������⣺");
                    Console.WriteLine(Howmany);
                    Console.WriteLine(timu);
                    FileStream file = new FileStream("C:/Users/a/Desktop/AchaoCalculator/text.txt", FileMode.Append, FileAccess.Write);
                    StreamWriter stream = new StreamWriter(file);
                    stream.WriteLine(timu + "=" + result);
                    stream.Close();
                    file.Close();
                }
            }
        }
    }
}
