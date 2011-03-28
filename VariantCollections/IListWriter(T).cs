namespace VariantCollections
{
    /// <summary>
    /// Represents a contravariant writer of a collection of objects that can be
    /// individually set by index.
    /// </summary>
    /// 
    /// <typeparam name="T">
    /// The type of elements in the list.
    /// </typeparam>
    public interface IListWriter<in T> : ICollectionWriter<T>
    {
        /// <summary>
        /// Sets the element at the specified index.
        /// </summary>
        /// 
        /// <param name="index">
        /// The zero-based index of the element to set.
        /// </param>
        T this[int index] { set; }
    }
}
