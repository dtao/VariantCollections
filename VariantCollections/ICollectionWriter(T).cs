namespace VariantCollections
{
    /// <summary>
    /// Represents a contravariant writer of a collection of objects.
    /// </summary>
    /// 
    /// <typeparam name="T">
    /// The type of elements in the collection.
    /// </typeparam>
    public interface ICollectionWriter<in T>
    {
        /// <summary>
        /// Adds an elment to the collection.
        /// </summary>
        /// 
        /// <param name="element">
        /// The element to add to the collection.
        /// </param>
        void Add(T element);
    }
}
