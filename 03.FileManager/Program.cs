using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var path = @"D:\Test\";
            var filePath = @"1.txt";
            var physicalFileProvider = new PhysicalFileProvider(path);
            var embeddedFileProvider = new EmbeddedFileProvider(Assembly.GetEntryAssembly());

            var content = new ServiceCollection()
                .AddSingleton<IFileProvider>(physicalFileProvider)
                .AddSingleton<IFileProvider>(embeddedFileProvider)
                .AddSingleton<IFileManager, FileManager>()
                .BuildServiceProvider()
                .GetService<IFileManager>()
                // .ShowStructure();
                // .ReadAllTextAsync("1.txt").Result;  // 1.txt 是基于D:\Test目录下的
                .ReadAllTextAsync("data.txt").Result;  // data.txt 是嵌入到程序集中的
            System.Console.WriteLine(content);

            #region 文件变化
            // 监听文件变化
            ChangeToken.OnChange(() => physicalFileProvider.Watch(filePath)
            , () => System.Console.WriteLine(File.ReadAllText(path + filePath)));
            // 模拟文件变化
            while (true)
            {
                File.WriteAllText(@"d:\test\1.txt", DateTime.Now.ToString());
                Task.Delay(5000).Wait();
            }
            #endregion

        }
    }

    public interface IFileManager
    {
        void ShowStructure();
        Task<string> ReadAllTextAsync(string path);
    }

    public class FileManager : IFileManager
    {
        public IFileProvider FileProvider { get; private set; }
        private Action<int, string> render;
        public FileManager(IFileProvider fileProvider)
        {
            this.FileProvider = fileProvider;
            this.render = (layer, name) => Console.WriteLine("{0}{1}", new string('\t', layer), name);
        }
        public void ShowStructure()
        {
            int layer = -1;
            Render("", ref layer);
        }

        private void Render(string subPath, ref int layer)
        {
            layer++;
            foreach (var fileInfo in this.FileProvider.GetDirectoryContents(subPath))
            {
                render(layer, fileInfo.Name);
                if (fileInfo.IsDirectory)
                {
                    var path = $@"{subPath}\{fileInfo.Name}".TrimStart('\\');
                    Render(path, ref layer);
                }
            }
            layer--;
        }

        public async Task<string> ReadAllTextAsync(string path)
        {
            byte[] buffer;
            using (Stream readStream = this.FileProvider.GetFileInfo(path).CreateReadStream())
            {
                buffer = new byte[readStream.Length];
                await readStream.ReadAsync(buffer, 0, buffer.Length);
            }
            var str = Encoding.ASCII.GetString(buffer);
            return str;
        }
    }
}
