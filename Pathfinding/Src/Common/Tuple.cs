using System.Collections;

/// <summary>
/// Tuple. Allows to have two elements wrapped into one object.
/// </summary>
public class Tuple<T1, T2>
{
	public T1 item1 { get; private set; }
	public T2 item2 { get; private set; }
	internal Tuple(T1 first, T2 second)
	{
		item1 = first;
		item2 = second;
	}
}

/// <summary>
/// Tuple. Allows to have three elements wrapped into one object.
/// </summary>
public class Tuple<T1, T2, T3>
{
	public T1 item1 { get; private set; }
	public T2 item2 { get; private set; }
	public T3 item3 { get; private set; }
	internal Tuple(T1 first, T2 second, T3 third)
	{
		item1 = first;
		item2 = second;
		item3 = third;
	}
}

/// <summary>
/// Tuple. Allows to have four elements wrapped into one object.
/// </summary>
public class Tuple<T1, T2, T3, T4>
{
	public T1 item1 { get; private set; }
	public T2 item2 { get; private set; }
	public T3 item3 { get; private set; }
	public T4 item4 { get; private set; }
	internal Tuple(T1 first, T2 second, T3 third, T4 forth)
	{
		item1 = first;
		item2 = second;
		item3 = third;
		item4 = forth;
	}
}