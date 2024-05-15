using System.Collections.Generic;

namespace BoxOfT
{
    public class Box<T> : Stack<T>
    {
        private Stack<T> _box;

        public Box()
        {
            _box = new Stack<T>();
        }

        public void Add(T element)
        {
            _box.Push(element);
        }

        public T Remove()
        {
          return _box.Pop();
        }

        public int Count => _box.Count;
    }
}