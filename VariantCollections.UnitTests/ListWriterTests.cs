using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace VariantCollections.UnitTests
{
    [TestFixture]
    class ListWriterTests : CollectionWriterTests<IListWriter<object>>
    {
        List<object> m_list = new List<object>();

        [Test]
        public void ShouldThrowOnNullList()
        {
            IList<object> list = null;
            Assert.That(() => list.GetWriter(), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void Set()
        {
            // Get the count up to one.
            m_collectionWriter.Add(null);

            object obj = new object();
            m_collectionWriter[0] = obj;

            AssertCollectionContains(obj);
        }

        protected override IListWriter<object> CreateWriter()
        {
            return m_list.GetWriter();
        }

        protected override void AssertCollectionCount(int count)
        {
            Assert.That(m_list.Count, Is.EqualTo(count));
        }

        protected override void AssertCollectionContains(object obj)
        {
            Assert.That(m_list, Contains.Item(obj));
        }
    }
}
