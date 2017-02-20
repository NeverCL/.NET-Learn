/** 
 * C# 6 常用语法
 */

using System.Collections.Generic;

class Demo
{
    public Demo()
    {
        // 数组传入
        var info = new string(new[] { 'w', 'o', 'r', 'l', 'd' });
        // 字符串拼接(在C#中,不管是new string还是字面量字符串,只要结果一样,就都会用字符串拘留池中的那个)
        var str = $"Hello{info}";
        // 数组写法
        int[] arr = { 1, 2, 3, 4 };
        // 字典写法
        var dict = new Dictionary<string, string> { { "1", "2" } };
    }
}