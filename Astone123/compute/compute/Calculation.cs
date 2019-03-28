using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace compute
{
    public class Calculation
    {        
        int a, b, c,va;
        string ex;
        string ex1;
        public Calculation(int num1, int num2, int num3)
        {
            a = num1;
            b = num2;
            c = num3;
        }

        public string Getcalculate(int num4)
        {
            int z=num4;
            switch (z)
            {
                case 1:
                    ex1=mathjia();
                    break;
                case 2:
                    ex1=mathjian();
                    break;
                case 3:
                    ex1=mathcheng();
                    break;
                case 4:
                    ex1=mathchu();
                    break;               
            }
            return ex1;

        }
        public string mathjia()
        {
            if (a + b - c >= 0)
            {
                Console.WriteLine("{0} ＋ {1} － {2} =", a, b, c);
                va = a + b - c;
                ex = a + "＋" + b + "－" + c+"=!"+va;
                return ex;
            }
            else
            {
                Console.WriteLine("{2} － {1} ＋ {0} =", a, b, c);
                va = c - b + a;
                ex = c + "－" + b + "＋" + a + "=!"+va;
                return ex;
            }
        }

        public string mathjian()
        {
            if (a >= b * c)
            {
                Console.WriteLine("{0} － {1} ×{2} =", a, b, c);
                va = a - b * c;
                return ex=a+ "－" + b+"×" + c + "=!"+va;
            }
            else
            {
                Console.WriteLine("{2} × {1} － {0} =", a, b, c);
                va = c * b - a;
                return ex = c + "×" + b + "－" + a + "=!"+va;
            }
        }

        public string mathcheng()
        {
            if (a * b % c == 0)
            {
                Console.WriteLine("{0} × {1} ÷ {2} =", a, b, c);
                va = a * b / c;
                return ex = a + "×" + b + "÷" + c + "=!"+va;
            }
            else if (a * c % b == 0)
            {
                Console.WriteLine("{0} × {2} ÷ {1} =", a, b, c);
                va = a * c / b;
                return ex = a + "×" + c + "÷" + b + "=!"+va;
            }
            else
            {
                Console.WriteLine("{0} × {1} × {2} =", a, b, c);
                va = a * b * c;
                return ex = a + "×" + b + "×" + c + "=!" + va ;
            }
        }
       
         public string mathchu()
         {
            if (a % b == 0)
            {
                Console.WriteLine("{0} ÷ {1} ＋ {2} =", a, b, c);
                va = a / b + c;
                return ex = a + "÷" + c + "＋" + b + "=!"+va;
            }
            else if (b % a == 0 & b / a - c >= 0)
            {
                Console.WriteLine("{1} ÷ {0} － {2} =", a, b, c);
                va = b / a - c;
                return ex = b + "÷" + a + "－" + c + "=!"+va;
            }
            else if (c % a == 0 & c / a - c >= 0)
            {
                Console.WriteLine("{2} ÷ {0} － {1} =", a, b, c);
                va = c / a - b;
                return ex = c + "÷" + a + "－" + b + "=!"+va;
            }
            else if (c % b == 0)
            {
                Console.WriteLine("{2} ÷ {1} ＋ {0} =", a, b, c);
                va = c / b + a;
                return ex = c + "÷" + a + "＋" + c + "=!"+va;
            }
            else
            {
                va = a + b + c;
                return ex = a + "＋" + b + "＋" + c + "=!" + va ;
            }
         }                      
    }
}
