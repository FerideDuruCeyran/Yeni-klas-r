using System;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading.Tasks.Dataflow;
using System.Text;
using System.Linq.Expressions;

namespace hello
{
    internal class Program
    {
        static void Main(string[] args)

        {
            int ay;
            Console.WriteLine("1-12 arası bir sayı giriniz:");
            ay = Convert.ToInt32(Console.ReadLine());
            switch (ay)
            {
                case 1:
                    Console.WriteLine("{0}.ay Ocak ayıdır", ay);
                    break;
                case 2:
                    Console.WriteLine("{0}.ay Şubat ayıdır", ay);
                    break;
                case 3:
                    Console.WriteLine("{0}.ay Mart ayıdır", ay);
                    break;
                case 4:
                    Console.WriteLine("{0}.ay Nisan ayıdır", ay);
                    break;
                case 5:
                    Console.WriteLine("{0}.ay Mayıs ayıdır", ay);
                    break;
                case 6:
                    Console.WriteLine("{0}.ay Haziran ayıdır", ay);
                    break;
                case 7:
                    Console.WriteLine("{0}.ay Temmuz ayıdır",ay);
                    break;
                case 8:
                    Console.WriteLine("{0}.ay Ağustos ayıdır", ay);
                    break;
                case 9:
                    Console.WriteLine("{0}.ay Eylül ayıdır", ay);
                    break;
                case 10:
                    Console.WriteLine("{0}.ay Ekim ayıdır", ay);
                    break;
                case 11:
                    Console.WriteLine("{0}.ay Kasım ayıdır", ay);
                    break;
                case 12:
                    Console.WriteLine("{0}.ay Aralık ayıdır", ay);
                    break;
                default:
                    Console.WriteLine("girmiş olduğunuz sayı 1-12c arasında değildir.");
                    break;

            }
            Console.WriteLine("merhaba");
            Console.ReadKey();



        }

    }
}