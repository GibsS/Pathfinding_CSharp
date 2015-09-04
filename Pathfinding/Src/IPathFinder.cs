using System.Collections.Generic;

/// <summary>
/// IPathFinder. Defines a class that can calculate a path from too nodes within a given graph.
/// </summary>
public interface IPathFinder {

	/// <summary>
	/// Gets the path from <c>x1</c> to <c>x2</c> made up of the nodes and vertices.
	/// </summary>
	/// <returns>The full path if one can be found or null if there is none.</returns>
	/// <param name="graph">The graph in which we look for the path.</param>
	/// <param name="x1">The start of the path.</param>
	/// <param name="x2">The end of the path.</param>
	/// <typeparam name="X">The type of nodes.</typeparam>
	/// <typeparam name="Y">The type of vertices.</typeparam>
	Path<X, Y> getFullPath<X, Y>(IGraph<X, Y> graph, X x1, X x2);

	/// <summary>
	/// Gets the path from <c>x1</c> to <c>x2</c> made up of the nodes.
	/// Precondition : x1 and x2 belongs to the graph.
	/// </summary>
	/// <returns>The node path if one can be found or null if there is none.</returns>
	/// <param name="graph">The graph in which we look for the path.</param>
	/// <param name="x1">The start of the path.</param>
	/// <param name="x2">The end of the path.</param>
	/// <typeparam name="X">The type of nodes.</typeparam>
	List<X> getNodePath<X>(IGraph<X> graph, X x1, X x2);
}