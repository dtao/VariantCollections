using System;
using System.Collections.Generic;

namespace VariantCollections
{
    sealed class DictionaryReader<TKey, TValue> : IDictionaryReader<TKey, TValue>
    {
        readonly IDictionary<TKey, TValue> m_dictionary;

        public DictionaryReader(IDictionary<TKey, TValue> dictionary)
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException("dictionary");
            }

            m_dictionary = dictionary;
        }

        public TValue this[TKey key]
        {
            get { return m_dictionary[key]; }
        }

        public int Count
        {
            get { return m_dictionary.Count; }
        }

        public bool ContainsKey(TKey key)
        {
            return m_dictionary.ContainsKey(key);
        }
    }
}
