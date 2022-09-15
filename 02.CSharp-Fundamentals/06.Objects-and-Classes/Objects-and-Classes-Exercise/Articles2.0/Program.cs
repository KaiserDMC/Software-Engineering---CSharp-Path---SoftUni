using System;
using System.Collections.Generic;
using System.Linq;

namespace Articles2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfArticles = int.Parse(Console.ReadLine());

            ArticleCatalogue articleCatalogue = new ArticleCatalogue();

            for (int i = 0; i < numberOfArticles; i++)
            {
                string inputLine = Console.ReadLine();

                string[] commandTokens = inputLine.Split(", ").ToArray();
                Article article = new Article(commandTokens[0], commandTokens[1], commandTokens[2]);

                articleCatalogue.Articles.Add(article);
            }

            List<Article> orderedArticles = new List<Article>();
            orderedArticles = articleCatalogue.Articles;

            foreach (Article article in orderedArticles)
            {
                article.ToString();
            }
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

            public void ToString()
            {
                Console.WriteLine($"{this.Title} - {this.Content}: {this.Author}");
            }
        }

        class ArticleCatalogue
        {
            public ArticleCatalogue()
            {
                this.Articles = new List<Article>();
            }

            public List<Article> Articles { get; set; }
        }
    }
}
