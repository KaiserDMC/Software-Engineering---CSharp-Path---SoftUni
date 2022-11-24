using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);
            MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

            foreach (var method in methods)
            {
                if (method.CustomAttributes.Any(n=>n.AttributeType==typeof(AuthorAttribute)))
                {
                    var attributes = method.GetCustomAttributes(false);

                    foreach (AuthorAttribute att in attributes)
                    {
                        Console.WriteLine($"{method.Name} is written by {att.Name}");
                    }
                }
            }
        }
    }
}
