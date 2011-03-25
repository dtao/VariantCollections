namespace VariantCollections
{
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
