using System;
using System.Collections.Generic;

namespace HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            string articleTitle = Console.ReadLine();
            string articleContent = Console.ReadLine();

            List<string> commentList = new List<string>();

            while (true)
            {
                string comment = Console.ReadLine();

                if (comment == "end of comments")
                {
                    break;
                }

                commentList.Add(comment);
            }

            Console.WriteLine($"<h1>{Environment.NewLine} \t{articleTitle} {Environment.NewLine}</h1>");

            Console.WriteLine($"<article>{Environment.NewLine} \t{articleContent} {Environment.NewLine}</article>");

            foreach (string comment in commentList)
            {
                Console.WriteLine($"<div> {Environment.NewLine} \t{comment} {Environment.NewLine}</div>");
            }
        }
    }
}
