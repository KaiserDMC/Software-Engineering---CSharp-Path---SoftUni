namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {

            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            using (var reader = new StreamReader(textFilePath))
            {
                using (var streamRead = new StreamReader(wordsFilePath))
                {
                    string[] separateWords = streamRead.ReadToEnd().Split(" ").ToArray();

                    string nextLineText = reader.ReadLine();

                    while (nextLineText != null)
                    {
                        nextLineText = nextLineText.ToLower();

                        for (int i = 0; i < separateWords.Length; i++)
                        {
                            string tempString = separateWords[i].ToLower();

                            if (nextLineText.Contains(tempString))
                            {
                                if (!wordCount.ContainsKey(tempString))
                                {
                                    wordCount.Add(tempString, 0);
                                }

                                wordCount[tempString]++;
                            }
                        }

                        nextLineText = reader.ReadLine();
                    }
                }
            }

            using (var writer = new StreamWriter(outputFilePath))
            {
                foreach (var word in wordCount.OrderByDescending(x => x.Value))
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
