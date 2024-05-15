using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public Spy()
        {

        }

        public string StealFieldInfo(string nameOfClass, params string[] fieldsToInvestigate)
        {
            StringBuilder stringBuilder = new StringBuilder();

            Type type = Type.GetType(nameOfClass);

            FieldInfo[] privateFields = type.GetFields((BindingFlags)60);

            Object classInstance = Activator.CreateInstance(type, new object[] { });

            stringBuilder.AppendLine($"Class under investigation: {nameOfClass}");

            foreach (var field in privateFields.Where(f => fieldsToInvestigate.Contains(f.Name)))
            {
                stringBuilder.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return stringBuilder.ToString().Trim();
        }

    }
}
