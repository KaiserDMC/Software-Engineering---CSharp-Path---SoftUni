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

        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder stringBuilder = new StringBuilder();

            Type type = Type.GetType(className);
            FieldInfo[] classFields = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            MethodInfo[] classPublicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] classNonPublicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var field in classFields)
            {
                stringBuilder.AppendLine($"{field.Name} must be private!");
            }

            foreach (var method in classNonPublicMethods.Where(m => m.Name.StartsWith("get")))
            {
                stringBuilder.AppendLine($"{method.Name} has to be public!");
            }

            foreach (var method in classPublicMethods.Where(m => m.Name.StartsWith("set")))
            {
                stringBuilder.AppendLine($"{method.Name} has to be private!");
            }

            return stringBuilder.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            StringBuilder stringBuilder = new StringBuilder();

            Type type = Type.GetType(className);

            MethodInfo[] allPrivateMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            stringBuilder.AppendLine($"All Private Methods of Class: {className}");
            stringBuilder.AppendLine($"Base Class: {type.BaseType.Name}");

            foreach (var method in allPrivateMethods)
            {
                stringBuilder.AppendLine($"{method.Name}");
            }

            return stringBuilder.ToString().Trim();
        }

        public string CollectGettersAndSetters(string className)
        {
            StringBuilder stringBuilder = new StringBuilder();

            Type type = Type.GetType(className);

            MethodInfo[] allMethods = type.GetMethods((BindingFlags)60);

            List<MethodInfo> getterList = allMethods.Where(m => m.Name.StartsWith("get")).ToList();
            List<MethodInfo> setterList = allMethods.Where(m => m.Name.StartsWith("set")).ToList();

            foreach (var getter in getterList)
            {
                stringBuilder.AppendLine($"{getter.Name} will return {getter.ReturnType}");
            }

            foreach (var setter in setterList)
            {
                stringBuilder.AppendLine($"{setter.Name} will set field of {setter.GetParameters().First().ParameterType}");
            }

            return stringBuilder.ToString().Trim();
        }
    }
}
