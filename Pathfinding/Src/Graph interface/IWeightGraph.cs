using System.Collections;

/// <summary>
/// IWeightGraph. Defines a graph that has nodes and vertices that have a weight attached to them. The weights are
/// used for example in path finding algorithms.
/// </summary>
public interface IWeightGraph<X,Y> : IGraph<X,Y> where Y : IWeightVertice {
	
}

/// <summary>
/// IWeightVertice. Define a vetice with a weight attached to it.
/// </summary>
public interface IWeightVertice {

	/// <summary>
	/// Gets the weight of the current vertice.
	/// </summary>
	/// <returns>The weight.</returns>
	float getWeight();
}