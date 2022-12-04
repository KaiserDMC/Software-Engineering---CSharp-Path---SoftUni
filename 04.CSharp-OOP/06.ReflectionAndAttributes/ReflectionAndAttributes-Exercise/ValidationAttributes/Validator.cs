using System.Linq;
using System.Reflection;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] propertyInfos = obj.GetType().GetProperties()
                .Where(x => x.GetCustomAttributes(typeof(MyValidationAttribute)).Any()).ToArray();


            foreach (var property in propertyInfos)
            {
                object value = property.GetValue(obj);
                MyValidationAttribute attribute = property.GetCustomAttribute<MyValidationAttribute>();
                bool isValid = attribute.IsValid(value);

                if (!isValid)
                {
                    return false;
                }
            }

            return true;
        }
    }
}