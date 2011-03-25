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

The same is true for many collection types, 

The VariantCollections library addresses this in an extremely straightforward way: first, by
defining an interface which offers *some* of the features of `IList<T>` *and is **covariant***:

	public interface IListReader<out T> : IEnumerable<T>
	{
		T this[int index] { get; }
		int Count { get; }
	}

Next, by defining an extension method on any `IList<T>` which creates an
`IListReader<T>` for that list:

	public static IListReader<T> AsVariant<T>(this IList<T> list);

What this allows us to do is achieve exactly the kind of variance we would *like* for `IList<T>` to
have, while avoiding the illegal parts (`Add`, `Insert`, `Remove`, etc.):

	var list = new List<int> { 1, 2, 3 };
	IListReader<int> reader = list.AsVariant();
	IListReader<object> objectReader = reader; // This is legal!