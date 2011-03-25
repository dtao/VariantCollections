using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

namespace VariantCollections.UnitTests
{
    [TestFixture]
    public class ListReaderTests
    {
        const string Element = "Hello!";

        IList<string> m_list;
        IListReader<string> m_reader;
            
        [SetUp]
        public void Init()
        {
            m_list = new List<string>
            {
                Element
            };
            m_reader = m_list.GetReader();
        }

        [Test]
        public void ShouldThrowOnNullList()
        {
            IList<int> list = null;
            Assert.That(() => list.GetReader(), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void UpcastReader()
        {
            IListReader<object> reader;
            Assert.That(() => reader = m_reader, Throws.Nothing);
        }

        [Test]
        public void AccessElementByIndex()
        {
            Assert.That(m_reader[0], Is.EqualTo(Element));
        }

        [Test]
        public void AccessUpcastElementByIndex()
        {
            IListReader<object> reader = m_reader;
            Assert.That(reader[0], Is.EqualTo(Element));
        }

        [Test]
        public void ProvideCount()
        {
            Assert.That(m_reader.Count, Is.EqualTo(1));
        }

        [Test]
        public void CheckIndexOf()
        {
            Assert.That(m_reader.IndexOf(Element), Is.EqualTo(0));
            Assert.That(m_reader.IndexOf(""), Is.EqualTo(-1));
        }

        [Test]
        public void Enumerate()
        {
            Assert.That(m_reader.SequenceEqual(new[] { Element }));
        }

        [Test]
        public void UpcastThenEnumerate()
        {
            IListReader<object> reader = m_reader;
            Assert.That(reader.SequenceEqual(new[] { Element }));
        }

        [Test]
        public void CastEnumerator()
        {
            System.Collections.IEnumerable sequence = m_reader;
            System.Collections.IEnumerator enumerator = sequence.GetEnumerator();
            Assert.That(enumerator.MoveNext());
            Assert.That(enumerator.Current, Is.EqualTo(Element));
        }
    }
}