using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace word_muncher
{
    public class WordMuncher
    {
        public static void Main(string[] args)
        {
            if (args == null || args.Length != 2)
            {
                Console.WriteLine("No filename provided, please send argument with file.");
                return;
            }

            string filePath = Path.GetFullPath(args[0]);
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Invalid input file path: {filePath}");
                return;
            }
            string resultPath = Path.GetFullPath(args[1]);
            if (resultPath == null)
            {
                Console.WriteLine($"Invalid output file path: {resultPath}");
                return;
            }

            string fileContents = new string(File.ReadAllText(filePath).Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());

            WordProcessor wordProcessor = new WordProcessor(fileContents);

            string results = string.Empty;
            foreach(KeyValuePair<string, long> instance in wordProcessor.GetTopTwentyOccurances())
            {
                results += $"{instance.Key}:{instance.Value}\n";
            }

            File.WriteAllText(resultPath, results);
            Console.Write(File.ReadAllText(resultPath));
        }
    }
}