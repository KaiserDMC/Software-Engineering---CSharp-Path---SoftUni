using System;
using System.Linq;

namespace Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();

            string[] commandTokens = inputLine.Split(", ").ToArray();
            Article article = new Article(commandTokens[0], commandTokens[1], commandTokens[2]);

            int numberOfChanges = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfChanges; i++)
            {
                string[] changeCommand = Console.ReadLine().Split(": ").ToArray();
                string commandType = changeCommand[0];
                string commandText = changeCommand[1];

                switch (commandType)
                {
                    case "Edit":
                        article.Edit(commandText);
                        break;
                    case "ChangeAuthor":
                        article.ChangeAuthor(commandText);
                        break;
                    case "Rename":
                        article.Rename(commandText);
                        break;
                }
            }

            article.ToString();
        }

        class Article
        {
            public Article(string title, string content, string author)
            {
                this.Title = title;
                this.Content = content;
                this.Author = author;
            }

            public string Title { get; set; }
            public string Content { get; set; }
            public string Author { get; set; }

            public void Edit(string content)
            {
                this.Content = content;
            }

            public void ChangeAuthor(string author)
            {
                this.Author = author;
            }

            public void Rename(string title)
            {
                this.Title = title;
            }

            public void ToString()
            {
                Console.WriteLine($"{this.Title} - {this.Content}: {this.Author}");
            }
        }
    }
}
