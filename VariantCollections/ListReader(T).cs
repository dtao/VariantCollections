using System;
using System.Collections.Generic;

namespace VariantCollections
{
    sealed class ListReader<T> : IListReader<T>
    {
        IList<T> m_list;

        public ListReader(IList<T> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException("list");
            }

            m_list = list;
        }

        public T this[int index]
        {
            get { return m_list[index]; }
        }

        public int Count
        {
            get { return m_list.Count; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return m_list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
