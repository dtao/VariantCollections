using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace VariantCollections.UnitTests
{
    [TestFixture]
    class DictionaryReaderTests
    {
        const string Key = "Key";
        const string Value = "Hello";

        IDictionary<object, string> m_dictionary;
        IDictionaryReader<object, string> m_reader;

        [SetUp]
        public void Init()
        {
            m_dictionary = new Dictionary<object, string>
            {
                { Key, Value }
            };
            m_reader = m_dictionary.AsVariant();
        }

        [Test]
        public void ShouldThrowOnNullDictionary()
        {
            IDictionary<int, string> dictionary = null;
            Assert.That(() => dictionary.AsVariant(), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void CastReader()
        {
            IDictionaryReader<string, object> reader;
            Assert.That(() => reader = m_reader, Throws.Nothing);
        }

        [Test]
        public void AccessElementByKey()
        {
            Assert.That(m_reader[Key], Is.EqualTo(Value));
        }

        [Test]
        public void AccessCastElementByKey()
        {
            IDictionaryReader<string, object> reader = m_reader;
            Assert.That(reader[Key], Is.EqualTo(Value));
        }

        [Test]
        public void ProvideCount()
        {
            Assert.That(m_reader.Count, Is.EqualTo(1));
        }

        [Test]
        public void CheckContainsKey()
        {
            Assert.That(m_reader.ContainsKey(Key));
        }

        [Test]
        public void CheckTryGetValue()
        {
            IDictionaryReader<string, object> reader = m_reader;
            object value;
            Assert.That(reader.TryGetValue(Value, out value), Is.False);
            Assert.That(reader.TryGetValue(Key, out value));
            Assert.That(value, Is.EqualTo(Value));
        }
    }
}
