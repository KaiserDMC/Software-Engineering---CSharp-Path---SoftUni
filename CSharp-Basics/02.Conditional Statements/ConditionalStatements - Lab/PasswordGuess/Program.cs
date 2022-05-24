using System;

namespace PasswordGuess
{
    class Program
    {
        static void Main(string[] args)
        {
            string passwrd = "s3cr3t!P@ssw0rd";
            string userInput = Console.ReadLine();

            if(userInput!=passwrd)
            {
                Console.WriteLine("Wrong password!");
            }
            else
            {
                Console.WriteLine("Welcome");
            }
        }
    }
}
