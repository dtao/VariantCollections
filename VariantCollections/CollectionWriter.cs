using System.Collections.Generic;

namespace VariantCollections
{
    public static class CollectionWriter
    {
        public static ICollectionWriter<T> GetWriter<T>(this ICollection<T> collection)
        {
            return new CollectionWriter<T>(collection);
        }

        public static IListWriter<T> GetWriter<T>(this IList<T> list)
        {
            return new ListWriter<T>(list);
        }

        public static IDictionaryWriter<TKey, TValue> GetWriter<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            return new DictionaryWriter<TKey, TValue>(dictionary);
        }

        public static ICollectionWriter<T> GetWriter<T>(this Queue<T> queue)
        {
            return new QueueWriter<T>(queue);
        }

        public static ICollectionWriter<T> GetWriter<T>(this Stack<T> stack)
        {
            return new StackWriter<T>(stack);
        }
    }
}
