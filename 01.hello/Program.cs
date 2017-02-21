using System;
using System.Text;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Console.WriteLine("Hello World!你好,世界!");
            Console.WriteLine(Console.ReadLine());
            Console.ReadKey();
        }
    }
}
