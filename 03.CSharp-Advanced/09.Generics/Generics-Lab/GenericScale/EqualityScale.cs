using System;

namespace GenericScale
{
    public class EqualityScale<T>
    {
        private T _right;
        private T _left;

        public EqualityScale(T left, T right)
        {
            _right = right;
            _left = left;
        }

        public bool AreEqual()
        {
            return _left.Equals(_right);
        }
    }
}