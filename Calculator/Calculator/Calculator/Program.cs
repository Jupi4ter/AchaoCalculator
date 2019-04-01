using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Part0
{
    public
    class Program
    {
        static void Main(string[] args)
        {

            string filename = @"C:\00001\subject.txt";
            StreamWriter fs = new StreamWriter(filename, true);
            int n = int.Parse(Console.ReadLine());
            Random rd = new Random();
            char[] ops = { '+', '-', '*', '/' };
            for (int i = 0; i < n; i++)
            {
                int opnumber = rd.Next(2, 4);
                int[] intstore = new int[opnumber+1];
                char[] charstore = new char[opnumber];
                if (opnumber == 2)
                {

                    while (true)
                    {
                        for (int j = 0; j < opnumber + 1; j++)
                        {
                            intstore[j] = rd.Next(0, 101);
                        }
                        for (int k = 0; k < opnumber; k++)
                        {
                            charstore[k] = ops[rd.Next(0,4)];
                        }
                        int ans = intstore[0] + charstore[0] + intstore[1] + charstore[1] + intstore[2];
                        if (Char.IsNumber(char.Parse(ans.ToString())))
                        {
                            break;
                        }
                    }
                    fs.Write(intstore[0].ToString(), Encoding.UTF8);
                    fs.Write(charstore[0]);
                    fs.Write(intstore[1].ToString(), Encoding.UTF8);
                    fs.Write(charstore[1]);
                    fs.Write(intstore[2].ToString(), Encoding.UTF8);
                    fs.WriteLine("=");
                }
                if (opnumber == 3)
                {
                    while (true)
                    {
                        for (int j = 0; j < opnumber + 1; j++)
                        {
                            intstore[j] = rd.Next(0, 101);
                        }
                        for (int k = 0; k < opnumber; k++)
                        {
                            charstore[k] = ops[rd.Next(0, 4)];
                        }
                        int ans = intstore[0] + charstore[0] + intstore[1] + charstore[1] + intstore[2]+charstore[2]+intstore[3];
                        if (Char.IsNumber(char.Parse(ans.ToString())))
                        {
                            break;
                        }
                    }
                    fs.Write(intstore[0].ToString(), Encoding.UTF8);
                    fs.Write(charstore[0]);
                    fs.Write(intstore[1].ToString(), Encoding.UTF8);
                    fs.Write(charstore[1]);
                    fs.Write(intstore[2].ToString(), Encoding.UTF8);
                    fs.Write(charstore[2]);
                    fs.Write(intstore[3].ToString(), Encoding.UTF8);
                    fs.WriteLine("=");
                }
            }
            fs.Close();
        }
    }
    public class calculator
    {

    }
}
