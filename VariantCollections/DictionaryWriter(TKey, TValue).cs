using System;
using System.Collections.Generic;

namespace VariantCollections
{
    class DictionaryWriter<TKey, TValue> : IDictionaryWriter<TKey, TValue>
    {
        private IDictionary<TKey, TValue> m_dictionary;

        public DictionaryWriter(IDictionary<TKey, TValue> dictionary)
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException("dictionary");
            }

            m_dictionary = dictionary;
        }

        public TValue this[TKey key]
        {
            set
            {
            	m_dictionary[key] = value;
            }
        }

        public void Add(TKey key, TValue value)
        {
            m_dictionary.Add(key, value);
        }
    }
}
