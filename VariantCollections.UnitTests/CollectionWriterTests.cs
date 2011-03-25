using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace VariantCollections.UnitTests
{
    abstract class CollectionWriterTests<TCollectionWriter> where TCollectionWriter : ICollectionWriter<object>
    {
        protected TCollectionWriter m_collectionWriter;

        [SetUp]
        public void Init()
        {
            m_collectionWriter = CreateWriter();
        }

        [Test]
        public void ShouldThrowOnNullCollection()
        {
            ICollection<int> collection = null;
            Assert.That(() => collection.GetWriter(), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void Add()
        {
            object obj = new object();
            m_collectionWriter.Add(obj);

            AssertCollectionCount(1);
            AssertCollectionContains(obj);
        }

        [Test]
        public void UpcastWriter()
        {
            ICollectionWriter<string> writer;
            Assert.That(() => writer = m_collectionWriter, Throws.Nothing);
        }

        [Test]
        public void AddUpcastElement()
        {
            ICollectionWriter<string> writer = m_collectionWriter;
            writer.Add("Hello");
            AssertCollectionContains("Hello");
        }

        protected abstract TCollectionWriter CreateWriter();

        protected abstract void AssertCollectionCount(int count);

        protected abstract void AssertCollectionContains(object obj);
    }
}
