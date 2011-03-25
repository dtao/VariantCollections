namespace VariantCollections
{
    /// <summary>
    /// Represents a contravariant writer of a generic collection of key/value
    /// pairs.
    /// </summary>
    /// 
    /// <typeparam name="TKey">
    /// The type of keys in the dictionary.
    /// </typeparam>
    /// 
    /// <typeparam name="TValue">
    /// The type of values in the dictionary.
    /// </typeparam>
    public interface IDictionaryWriter<in TKey, in TValue>
    {
        /// <summary>
        /// Sets the element with the specified key.
        /// </summary>
        /// 
        /// <param name="key">
        /// The key of the element to set.
        /// </param>
        TValue this[TKey key] { set; }

        /// <summary>
        /// Adds the specified key and value to the dictionary.
        /// </summary>
        /// 
        /// <param name="key">
        /// The key of the element to add.
        /// </param>
        /// 
        /// <param name="value">
        /// The value of the element to add. The value can be null for reference types.
        /// </param>
        void Add(TKey key, TValue value);
    }
}
