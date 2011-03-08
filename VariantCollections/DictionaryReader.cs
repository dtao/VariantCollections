using System.Collections.Generic;

namespace VariantCollections
{
    /// <summary>
    /// Provides an extension method to create variant readers for strongly-
    /// typed dictionaries.
    /// </summary>
    public static class DictionaryReader
    {
        /// <summary>
        /// Creates an <see cref="IDictionaryReader{TKey, TValue}"/> from an
        /// <seealso cref="IDictionary{TKey, TValue}"/>.
        /// </summary>
        /// 
        /// <typeparam name="TKey">
        /// The type of the keys of <paramref name="dictionary"/>
        /// </typeparam>
        /// 
        /// <typeparam name="TValue">
        /// The type of the values of <paramref name="dictionary"/>.
        /// </typeparam>
        /// 
        /// <param name="dictionary">
        /// The <seealso cref="IDictionary{TKey, TValue}"/> from which to
        /// create an <see cref="IDictionaryReader{TKey, TValue}"/>.
        /// </param>
        /// 
        /// <returns>
        /// An <see cref="IDictionaryReader{TKey, TValue}"/> that contains
        /// elements from the input dictionary.
        /// </returns>
        public static IDictionaryReader<TKey, TValue> AsVariant<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            return new DictionaryReader<TKey, TValue>(dictionary);
        }

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// 
        /// <typeparam name="TKey">
        /// The type of keys in the dictionary.
        /// </typeparam>
        /// 
        /// <typeparam name="TValue">
        /// The type of values in the dictionary.
        /// </typeparam>
        /// 
        /// <param name="reader">
        /// The reader with which to search for the specified key.
        /// </param>
        /// 
        /// <param name="key">
        /// The key whose value to get.
        /// </param>
        /// 
        /// <param name="value">
        /// When this method returns, the value associated with the specified
        /// key, if the key is found; otherwise, the default value for the type
        /// of the value parameter. This parameter is passed uninitialized.
        /// </param>
        /// 
        /// <returns>
        /// <c>true</c> if the dictionary contains an element with the
        /// specified key; otherwise, <c>false</c>.
        /// </returns>
        public static bool TryGetValue<TKey, TValue>(this IDictionaryReader<TKey, TValue> reader, TKey key, out TValue value)
        {
            if (reader.ContainsKey(key))
            {
                value = reader[key];
                return true;
            }

            value = default(TValue);
            return false;
        }
    }
}
