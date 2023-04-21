namespace GenericArrayCreator
{
    public class ArrayCreator
    {
        public ArrayCreator()
        {

        }

        public static T[] Create<T>(int length, T item)
        {
            T[] array = new T[length];

            for (int i = 0; i < length; i++)
            {
                array[i] = item;
            }

            return array;
        }
    }
}