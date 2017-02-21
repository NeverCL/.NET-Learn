using System;
using System.Text;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            // 下面这种方式也能解决中文乱码问题
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            Console.WriteLine("Hello World!你好,世界!");
            Console.WriteLine(Console.ReadLine());
            Console.ReadKey();
        }
    }
}
