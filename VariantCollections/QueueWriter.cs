using System;
using System.Collections.Generic;

namespace VariantCollections
{
    class QueueWriter<T> : ICollectionWriter<T>
    {
        Queue<T> m_queue;

        public QueueWriter(Queue<T> queue)
        {
            if (queue == null)
            {
                throw new ArgumentNullException("queue");
            }

            m_queue = queue;
        }

        public void Add(T element)
        {
            m_queue.Enqueue(element);
        }
    }
}
