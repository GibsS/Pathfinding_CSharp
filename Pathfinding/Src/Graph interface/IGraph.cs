using System.Collections.Generic;
using System;

/// <summary>
/// IGraph. Defines a simple graph allowing us to get the basic information of a graph : the nodes and their adjacent nodes.
/// This graph has no vertices.
/// </summary>
public interface IGraph<X> {

	/// <summary>
	/// Gets the nodes.
	/// </summary>
	/// <returns>The nodes.</returns>
	List<X> getNodes();
	/// <summary>
	/// Gets the nodes adjacent to the node given in argument.
	/// Precondition : o "belongs to" the graph. The implementing class as to define this concept of "belonging".
	/// </summary>
	/// <returns>The list of the adjacent nodes.</returns>
	/// <param name="o">The node for which we search the adjacent nodes.</param>
	List<X> getNextNodes(X o);
}

/// <summary>
/// Igraph. Defines a graph with nodes AND vertices.
/// </summary>
public interface IGraph<X, Y> : IGraph<X>{

	/// <summary>
	/// Gets the nodes adjacent to the node given in argument as well as the vertices associated to the links.
	/// </summary>
	/// <returns>The adjacent nodes and the vertice leading to the nodes.</returns>
	/// <param name="o">The node for which we search the adjacent nodes.</param>
	List<Tuple<X, Y>> getVertices(X o);
}