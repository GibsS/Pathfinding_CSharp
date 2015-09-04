using System.Collections;

/// <summary>
/// IWeightPathFinder. Defines a class that can calculate a path from too nodes within a given graph that considers the
/// weight of each vertice : the algorithm does not try to find a minimal path in terms of number of nodes crossed
/// but in term of total path weight, defined by the sum of the weight of each vertice traversed.
/// </summary>
public interface IWeightPathFinder  {

	/// <summary>
	/// Gets path defined by the list of nodes and vertices
	/// precondition : x1 and x2 belong to the graph
	/// </summary>
	/// <returns>The full path if their is one, null if not.</returns>
	/// <param name="graph">The graph in which we search a path.</param>
	/// <param name="x1">The start of the path.</param>
	/// <param name="x2">The end of the path.</param>
	/// <typeparam name="X">The type of nodes.</typeparam>
	/// <typeparam name="Y">The type of vertices.</typeparam>
	Path<X, Y> getWeightedPath<X,Y> (IWeightGraph<X, Y> graph, X x1, X x2) where Y : IWeightVertice ;
}