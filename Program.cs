using System.Data;
using System.IO;

namespace Task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var temp = SearchFiles(@"C:\MyFiles\Шаг\Student\4. С# и .NET\Самообучение", @"*.pdf");
            foreach (var item in temp)
            {
                Console.WriteLine(Path.GetFileName(item));
            }
        }
        static string[] SearchFiles(string path, string searchMask)
        {
            if (path is null) throw new ArgumentNullException();
            if (searchMask is null) throw new ArgumentNullException();
            if (!Directory.Exists(path)) throw new DirectoryNotFoundException();
            List<string> files = new List<string>(Directory.GetFiles(path, searchMask));
            foreach (var item in Directory.GetDirectories(path))
            {
                string tempPath = Path.Combine(path, item);
                files.AddRange(SearchFiles(tempPath, searchMask));
            }
            return files.ToArray();
        }
    }
}

//Задание 1:
//Разработайте приложение для поиска файлов по маске. Пользователь вводит путь к папке и маску для поиска. Например:
//D:\DataForUser
//*.txt
//Приложение должно отобразить все файлы с расширением txt по пути D:\DataForUser
//Задание 2:
//Добавьте к первому заданию поиск в подпапках.

//if (path is null) throw new ArgumentNullException();
//if (searchMask is null) throw new ArgumentNullException();
//string[] fileInfo = Directory.GetFiles(path, searchMask);
//foreach (var item in fileInfo)
//{
//    Console.WriteLine(Path.GetFileName(item));
//}
//foreach (var item in Directory.GetDirectories(path))
//{
//    string tempPath = Path.Combine(path, item);
//    SearchFiles(tempPath, searchMask);
//}