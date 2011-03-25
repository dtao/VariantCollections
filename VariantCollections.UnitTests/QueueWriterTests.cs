using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace VariantCollections.UnitTests
{
    class QueueWriterTests : CollectionWriterTests<ICollectionWriter<object>>
    {
        Queue<object> m_queue = new Queue<object>();

        [Test]
        public void ShouldThrowOnNullQueue()
        {
            Queue<object> queue = null;
            Assert.That(() => queue.GetWriter(), Throws.InstanceOf<ArgumentNullException>());
        }

        protected override ICollectionWriter<object> CreateWriter()
        {
            return m_queue.GetWriter();
        }

        protected override void AssertCollectionCount(int count)
        {
            Assert.That(m_queue.Count, Is.EqualTo(count));
        }

        protected override void AssertCollectionContains(object obj)
        {
            Assert.That(m_queue.Contains(obj));
        }
    }
}
