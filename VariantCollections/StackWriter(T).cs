using System;
using System.Collections.Generic;

namespace VariantCollections
{
    class StackWriter<T> : ICollectionWriter<T>
    {
        Stack<T> m_stack;

        public StackWriter(Stack<T> stack)
        {
            if (stack == null)
            {
                throw new ArgumentNullException("stack");
            }

            m_stack = stack;
        }

        public void Add(T element)
        {
            m_stack.Push(element);
        }
    }
}
