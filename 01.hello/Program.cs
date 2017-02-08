using System;
using System.Text;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] arr = { 1, 3, 4 };
            String str1 = "hello";
            String str2 = "hello";
            String str3 = new String(new char[] { 'h', 'e', 'l', 'l', 'o' });
            String str4 = new String(new char[] { 'h', 'e', 'l', 'l', 'o' });
            System.Console.WriteLine(str1 == str2);
            System.Console.WriteLine(str1 == str3);
            System.Console.WriteLine(str3 == str4);
            System.Console.WriteLine(str1.Equals(str3));
            System.Console.WriteLine(str3.Equals(str4));
            Console.WriteLine("Hello World!");
        }
    }
}
