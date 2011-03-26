# VariantCollections

The basic idea of this library is very simple. Often a .NET developer will have something like an
`IList<string>` (for example) and will want to "cast" it to an `IList<object>`. Unfortunately, he
or she will quickly discover that this is not legal because the `IList<T>` interface is not
[**covariant**](http://msdn.microsoft.com/en-us/library/dd799517.aspx).

The *reason* for this, of course, is that if `IList<T>` *were* covariant, then code like this would
be possible:

	var list = new List<int> { 1, 2, 3 };
	var objectList = (IList<object>)list;
	objectList.Add("Oh no! I'm adding a string to a List<int>!");

What's frustrating about this reason for the `IList<T>` type's invariance is that **we are not
always interested in those features of `IList<T>` that make it invariant**. In particular, we are
often only *really* interested in features of `IList<T>` which *could* be variant: for instance, it
is very common for developers to think of `IList<T>` as *the* interface to use for code that
requires a collection offering *random indexed **read** access* to its elements. In this capacity,
none of the actually interesting members of `IList<T>` compromise its potential covariance.

The same is true for many collection interfaces, such as `IDictionary<TKey, TValue>` (which we often want
to use only to look up elements by their keys, and *not* to modify the collection).

The VariantCollections library addresses this in an extremely straightforward way: by splitting the
most common collection interfaces into **covariant** *readers* and **contravariant** *writers*.

For example, given any implementation of `IList<T>`, if we are only interested in *reading* from the
collection, we should be able to treat it as an `IList<U>` for any type `U` that is *less specific*
than `T` (e.g., an `IList<string>` could just as easily be viewed as an `IList<object>` *for read-only
purposes*). In contrast, if we are only interested in *writing* to the collection, we should be able
to treat it as an `IList<U>` for any type `U` that is *more specific* than `T` (so, we could treat an
`IList<object>` as an `IList<string>` *for write-only purposes*).

This leads to the logical "splitting up" of `IList<T>` into the following covariant and contravariant
interfaces:

	public interface IListReader<out T> : IEnumerable<T>
	{
		T this[int index] { get; }
		int Count { get; }
	}

    public interface IListWriter<in T>
    {
    }

Next, by defining an extension method on any `IList<T>` which creates an
`IListReader<T>` for that list:

	public static IListReader<T> AsVariant<T>(this IList<T> list);

What this allows us to do is achieve exactly the kind of variance we would *like* for `IList<T>` to
have, while avoiding the illegal parts (`Add`, `Insert`, `Remove`, etc.):

	var list = new List<int> { 1, 2, 3 };
	IListReader<int> reader = list.AsVariant();
	IListReader<object> objectReader = reader; // This is legal!