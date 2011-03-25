using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

namespace VariantCollections.UnitTests
{
    class StackWriterTests : CollectionWriterTests<ICollectionWriter<object>>
    {
        Stack<object> m_stack = new Stack<object>();

        [Test]
        public void ShouldThrowOnNullStack()
        {
            Stack<object> stack = null;
            Assert.That(() => stack.GetWriter(), Throws.InstanceOf<ArgumentNullException>());
        }

        protected override ICollectionWriter<object> CreateWriter()
        {
            return m_stack.GetWriter();
        }

        protected override void AssertCollectionCount(int count)
        {
            Assert.That(m_stack.Count, Is.EqualTo(count));
        }

        protected override void AssertCollectionContains(object obj)
        {
            Assert.That(m_stack.Contains(obj));
        }
    }
}
