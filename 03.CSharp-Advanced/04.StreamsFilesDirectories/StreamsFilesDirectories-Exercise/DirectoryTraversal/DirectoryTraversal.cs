using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DirectoryTraversal
{
    using System;
    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            DirectoryInfo directory = new DirectoryInfo(inputFolderPath);

            FileInfo[] filesInDirectory = directory.GetFiles("*", SearchOption.TopDirectoryOnly);

            Dictionary<string, Dictionary<string, long>> filesByExtension =
                new Dictionary<string, Dictionary<string, long>>();

            foreach (var fileInfos in filesInDirectory)
            {
                string extension = fileInfos.Extension;
                string name = fileInfos.Name;
                long size = fileInfos.Length / 125;

                if (!filesByExtension.ContainsKey(extension))
                {
                    filesByExtension.Add(extension, new Dictionary<string, long>());
                }

                filesByExtension[extension].Add(name, size);
            }

            string bullshit = String.Empty;


            foreach (var file in filesByExtension.OrderByDescending(c => c.Value.Count).ThenBy(c => c.Key))
            {
                bullshit += file.Key;
                bullshit += "\n";

                foreach (var f in file.Value.OrderBy(f => f.Value))
                {
                    bullshit += "--" + f.Key.ToString() + " - " + f.Value + "kb";
                    bullshit += "\n";
                }

                bullshit += "\n";
            }

            //Console.WriteLine(bullshit);

            return bullshit;
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string pathToCreate = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);

            pathToCreate += reportFileName;

            File.WriteAllText(pathToCreate,textContent);
        }
    }
}
