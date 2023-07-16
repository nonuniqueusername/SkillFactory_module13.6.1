using System.Diagnostics;


namespace SkillFactory_module13._6._1
{
    delegate void MethodToMeasure(string[] fileContentArray);
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter file path:");
            string path = Console.ReadLine();
            var fileContent = GetFileContent(path);

            MeasureExecTime(GetList, fileContent, "List");
            MeasureExecTime(GetLinkedList, fileContent, "LinkedList");
        }

        static private string[] GetFileContent(string path)
        {
            return File.ReadAllText(path).Split(new[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
        }

        static private void GetList(string[] fileContentArray) 
        {
            List<string> strings = new List<string>();
            foreach (var line in fileContentArray)
            {
                strings.Add(line);
            }
            return;
        }

        static private void GetLinkedList(string[] fileContentArray)
        {
            LinkedList<string> strings = new LinkedList<string>();
            foreach (var line in fileContentArray)
            {
                strings.AddLast(line);
            }
            return;
        }

        static private void MeasureExecTime(MethodToMeasure method, string[] fileContentArray, string objectType)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            method(fileContentArray);
            timer.Stop();
            Console.WriteLine($"{objectType}: {timer.ElapsedMilliseconds} ms");
        }
    }
}