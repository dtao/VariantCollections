using System;
using System.Collections.Generic;

namespace VariantCollections
{
    class ListWriter<T> : IListWriter<T>
    {
        private IList<T> m_list;

        public ListWriter(IList<T> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException("list");
            }

            m_list = list;
        }

        public T this[int index]
        {
            set
            {
            	m_list[index] = value;
            }
        }

        public void Add(T element)
        {
            m_list.Add(element);
        }
    }
}
