using System.Collections.Generic;

/// <summary>
/// Path. Defines a list of elements X with a Y element between each successive X. This data represents a path.
/// </summary>
public class Path<X, Y> {

	// the list of nodes.
	List<X> nodes;
	// the list of vertices.
	List<Y> vertices;

	/// <summary>
	/// Initializes a new instance of the <see cref="Path`2"/> class.
	/// </summary>
	public Path() {
		nodes = new List<X> ();
		vertices = new List<Y> ();
	}

	/// <summary>
	/// Clears the path. 
	/// </summary>
	public void clear() {
		nodes.Clear ();
		vertices.Clear ();
	}

	/// <summary>
	/// Starts the path with a node. It also reinitiates the path and clears
	/// </summary>
	/// <param name="x">The first node.</param>
	public void start(X x) {
		nodes.Clear ();
		vertices.Clear ();
		nodes.Add (x);
	}

	/// <summary>
	/// Adds a transition.
	/// precondition : the start method must have been called and no clear since.
	/// </summary>
	/// <param name="node">the next node in the path.</param>
	/// <param name="vertice">the next vertice in the path.</param>
	public void addTransition(X node, Y vertice) {
		nodes.Add (node);
		vertices.Add (vertice);
	}

	/// <summary>
	/// Adds a transition.
	/// precondition : the start method must have been called and no clear since.
	/// </summary>
	/// <param name="transition">the next transition constituted of a node and a vertice.</param>
	public void addTransition(Tuple<X,Y> transition) {
		nodes.Add (transition.item1);
		vertices.Add (transition.item2);
	}

	/// <summary>
	/// Reverses the order of the path.
	/// </summary>
	public void reverse() {
		nodes.Reverse ();
		vertices.Reverse ();
	}

	/// <summary>
	/// Gets the list of nodes
	/// </summary>
	/// <returns>The nodes.</returns>
	public List<X> getNodes() { return nodes; }
	/// <summary>
	/// Gets the list of vertices.
	/// </summary>
	/// <returns>The vertices.</returns>
	public List<Y> getVertices() { return vertices; }
}