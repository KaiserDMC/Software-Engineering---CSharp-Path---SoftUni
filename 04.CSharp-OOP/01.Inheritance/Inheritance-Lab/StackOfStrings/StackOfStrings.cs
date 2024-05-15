using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        private Stack<string> stack;

        public StackOfStrings()
        {
            this.Stack = new Stack<string>();
        }

        public Stack<string> Stack
        {
            get { return stack; }
            set { stack = value; }
        }

        public bool IsEmpty()
        {
            return this.Count == 0;
        }

        public Stack<string> AddRange(Stack<string> stackRange)
        {
            foreach (var item in stackRange)
            {
                this.Push(item);
            }

            return this;
        }
    }
}
