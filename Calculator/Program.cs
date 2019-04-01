using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculator
{
    public class Program
    {
        static void Main(string[] args)
        {           
            int n = int.Parse(Console.ReadLine());
            File.WriteAllText(@"g:file.txt", "");                             //先把文件的内容清空
            for (int i = 0; i < n;i++)
            {        
                int operatorNumber = GetRandomNumber(2, 3);                   //随机生成运算符的数量operatorNumber            
                char[] operators = new char[operatorNumber];                  //定义操作符数组
                int[] digitals = new int[operatorNumber + 1];                 //定义数字数组，数字数组的长度为操作符数组长度加一
                AssignCharactors(operatorNumber,ref operators,ref digitals);  //为数字数组和操作符数组赋值
                string command = GetCommand( operators, digitals);            //将操作符数组和数组数组合成为指令字符串
                int result = Compute(command);
                string formula = command + "=" + result+"\n";
                Console.Write(formula);
                File.AppendAllText(@"g:file.txt", formula);
            }
        }

        //为操作符数组operators和数字数组digitals赋值
        public static void AssignCharactors(int operatorNumber,ref char[] operators, ref int[] digitals )
        {

            digitals[0] = GetRandomNumber(0, 100);                            //由于可能要进行运算，所以在进入循环之前先为第一个数字赋值
            for (int j = 0; j < operators.Length; j++)
            {
                digitals[j+1] = GetRandomNumber(0, 100);                      //为数字数组digitals赋值
                int operatorID = GetRandomNumber(0, 3);                       //根据随机数决定操作符，为操作符数组operators赋值             
                switch (operatorID)
                {
                    case 0:
                        operators[j] = '+';
                        break;
                    case 1:
                        operators[j] = '-';
                        break;
                    case 2:
                        operators[j] = '*';
                        break;
                    case 3:
                        operators[j] = '/';
                        if (digitals[j + 1] == 0)
                        //除数不能为0，为了保证除数不为0，采取加上一个1到100的数的方式
                        {
                            digitals[j + 1] += GetRandomNumber(1, 100);
                        }
                        //由于该题要求计算过程中不能出现小数，所以当出现除号时应该检查除号之前的数与之后的数相除是否为小数  (此处仅为该题要求，根据需求不同可能会更改此处)
                        int first = 0;                                        //用变量first记录连续除号中的第一个除号的位置
                        bool isDivisible = IsDivisible(ref first, operators, digitals, j);
                        while (!isDivisible)
                        {
                            //当随机生成的数字不能满足要求时应该重新取值
                            for (int k = first; k <= j + 1; k++)
                            {
                                digitals[k] = GetRandomNumber(1, 100);
                            }
                            isDivisible = IsDivisible(ref first,operators, digitals, j);
                        }                 
                        break;

                }
            }
           
               
        }
        //该函数用于判断计算过程中是否会出现小数
        public static bool IsDivisible(ref int first,char[] operators,int[] digitals,int recent)
        {

             first = recent;
            //找到第一个除号的下标
            for (; first>= 0; first--)
            {
                if (operators[first] != '/')
                {
                    break;
                }
            }
            first++;                                                        //first多减了一，加回去
            int result = digitals[first];
            //判断从第一个除号开始进行连续运算直到当前除号的下标，能被整除返回true，否则返回false
            for (int i = first; i <= recent; i++)
            {
                if (result % digitals[i + 1] != 0 || result < digitals[i + 1])
                {
                    return false;
                }
                else
                {
                    result /= digitals[i + 1];
                }
            }
            return true;
        }
        //该函数用于最后的计算
        public static int Compute(string command)
        {
            var result = new DataTable().Compute(command, null);              //通过得到的指令进行计算
            return int.Parse(result.ToString());
        }

        //得到随机的数
        public static int GetRandomNumber(int min, int max)
        {
            var seed = Guid.NewGuid().GetHashCode();                         //设置随机数种子
            int randomrNumber = new Random(seed).Next(min,max+1);
            return randomrNumber;
        }

        //将得到的随机的数字和操作符生成command指令
        public static string GetCommand(char[] operators,int[] digitals)
        {
            string command = "";
            int i = 0;
            for (i = 0; i < operators.Length; i++)
            {
                command += digitals[i].ToString();
                command += operators[i];
            }
            command += digitals[i];
            return command;
        }

       
        
    }
}
