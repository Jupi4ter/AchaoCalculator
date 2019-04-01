using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.label2.Text = "";
            try
            {
                int strN = int.Parse(textBox1.Text);
                Random rd = new Random();//随机函数

                IList<IList<int>> timushu = new List<IList<int>>(); //存储题目数量

                for (int i = 0; i < strN; i++)
                {
                    IList<int> num = new List<int>();//每个题目内的数量
                    int numc = rd.Next(2, 4); //获得题目内的数字个数
                    for (int j = 0; j < numc; j++)
                    {
                        num.Add(rd.Next(1, 101));//获得题目数字
                    }
                    timushu.Add(num);
                }

                //题目数字准备完毕  开始获得运算符号


                foreach (IList<int> list in timushu)
                {
                    int sign1 = rd.Next(1, 5); // 获得第一个运算符
                    int sign2 = rd.Next(1, 5); // 获得第二个运算符

                    //判断当前的运算有几个数
                    if (list.Count == 2)
                    {
                        //避免出现小数  判断并处理运算符
                        if (sign1 == 4)//如果是 除号 需要第一个数是第二个数的倍数并小于100
                        {
                            while (list[0] % list[1] != 0)//不能整除则重新取数
                            {
                                list[0] = rd.Next(1, 101);
                                list[1] = rd.Next(1, 101);
                            }
                        }
                        this.label2.Text += list[0] + " " + returnSign(sign1) + " " + list[1] + " = " + result(list[0], list[1], sign1) + "\n";
                    }
                    else if (list.Count == 3)
                    {
                        //避免出现小数  判断并处理运算符
                        if (sign1 == 4)//如果是 除号 需要第一个数是第二个数的倍数并小于100
                        {
                            while (list[0] % list[1] != 0)//不能整除则重新取数
                            {
                                list[0] = rd.Next(1, 101);
                                list[1] = rd.Next(1, 101);
                            }
                            if (sign2 == 4)
                            {
                                while ((list[0] / list[1]) % list[2] != 0)//不能整除则重新取数
                                {
                                    list[2] = rd.Next(1, 100);
                                }
                            }
                        }
                        else if (sign2 == 4)//如果是 除号 需要第一个数是第二个数的倍数并小于100
                        {
                            while (list[1] % list[2] != 0)//不能整除则重新取数
                            {
                                list[1] = rd.Next(1, 100);
                                list[2] = rd.Next(1, 100);
                            }
                        }


                        this.label2.Text += list[0] + " " + returnSign(sign1) + " " + list[1] + " " + returnSign(sign2) + " " + list[2] + " = " + result(list[0], list[1], list[2], sign1, sign2) + "\n";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("请输入数字");
            }
        }

        private int result(int a, int b, int sign)
        {
            switch (sign)
            {
                case 1:
                    return a + b;
                case 2:
                    return a - b;
                case 3:
                    return a * b;
                case 4:
                    return a / b;
            }
            return 0;
        }

        private int result(int a, int b, int c, int sign1, int sign2)
        {
            if (sign1 == 1 && sign2 == 1)
            {
                return a + b + c;
            }
            else if (sign1 == 1 && sign2 == 2)
            {
                return a + b - c;
            }
            else if (sign1 == 1 && sign2 == 3)
            {
                return a + b * c;
            }
            else if (sign1 == 1 && sign2 == 4)
            {
                return a + b / c;
            }
            else if (sign1 == 2 && sign2 == 1)
            {
                return a - b + c;
            }
            else if (sign1 == 2 && sign2 == 2)
            {
                return a - b - c;
            }
            else if (sign1 == 2 && sign2 == 3)
            {
                return a - b * c;
            }
            else if (sign1 == 2 && sign2 == 4)
            {
                return a - b / c;
            }
            else if (sign1 == 3 && sign2 == 1)
            {
                return a * b + c;
            }
            else if (sign1 == 3 && sign2 == 2)
            {
                return a * b - c;
            }
            else if (sign1 == 3 && sign2 == 3)
            {
                return a * b * c;
            }
            else if (sign1 == 3 && sign2 == 4)
            {
                return a * b / c;
            }
            else if (sign1 == 4 && sign2 == 1)
            {
                return a / b + c;
            }
            else if (sign1 == 4 && sign2 == 2)
            {
                return a / b - c;
            }
            else if (sign1 == 4 && sign2 == 3)
            {
                return a / b * c;
            }
            else if (sign1 == 4 && sign2 == 4)
            {
                return a / b / c;
            }
            return 0;
        }


        private string returnSign(int type)
        {
            switch (type)
            {
                case 1:
                    return "+";
                case 2:
                    return "-";
                case 3:
                    return "*";
                case 4:
                    return "÷";
            }
            return "";
        }

    }
}
