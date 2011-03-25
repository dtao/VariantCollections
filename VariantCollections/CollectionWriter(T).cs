using System;
using System.Collections.Generic;

namespace VariantCollections
{
    class CollectionWriter<T> : ICollectionWriter<T>
    {
        ICollection<T> m_collection;

        public CollectionWriter(ICollection<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }

            m_collection = collection;
        }

        public void Add(T element)
        {
            m_collection.Add(element);
        }
    }
}
