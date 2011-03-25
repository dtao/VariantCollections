using System.Collections.Generic;

using NUnit.Framework;

namespace VariantCollections.UnitTests
{
    class LinkedListCollectionWriterTests : CollectionWriterTests<ICollectionWriter<object>>
    {
        LinkedList<object> m_linkedList = new LinkedList<object>();

        protected override ICollectionWriter<object> CreateWriter()
        {
            return m_linkedList.GetWriter();
        }

        protected override void AssertCollectionCount(int count)
        {
            Assert.That(m_linkedList.Count, Is.EqualTo(count));
        }

        protected override void AssertCollectionContains(object obj)
        {
            Assert.That(m_linkedList.Contains(obj));
        }
    }
}
