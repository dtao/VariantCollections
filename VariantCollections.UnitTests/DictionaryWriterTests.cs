using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace VariantCollections.UnitTests
{
    [TestFixture]
    class DictionaryWriterTests
    {
        const string Key = "Key";
        const string Value = "Hello";

        IDictionary<object, object> m_dictionary;
        IDictionaryWriter<object, object> m_writer;

        [SetUp]
        public void Init()
        {
            m_dictionary = new Dictionary<object, object>();
            m_writer = m_dictionary.GetWriter();
        }

        [Test]
        public void ShouldThrowOnNullDictionary()
        {
            IDictionary<object, object> dictionary = null;
            Assert.That(() => dictionary.GetWriter(), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void Set()
        {
            m_writer[Key] = Value;
            Assert.That(m_dictionary[Key], Is.EqualTo(Value));
        }

        [Test]
        public void Add()
        {
            m_writer.Add(Key, Value);
            Assert.That(m_dictionary.ContainsKey(Key));

            object value;
            Assert.That(m_dictionary.TryGetValue(Key, out value));
            Assert.That(value, Is.EqualTo(Value));
        }

        [Test]
        public void AddKeyValuePair()
        {
            
        }
    }
}
