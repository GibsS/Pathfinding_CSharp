using System.Collections.Generic;

/// <summary>
/// AStar. Defines a pathfinder that implements the A star algorithm.
/// </summary>
public class AStar : IWeightPathFinder, IPathFinder {

	public List<X> getNodePath<X>(IGraph<X> graph, X x1, X x2) {
		List<X> res = new List<X> ();
		List<X> neighbour;
		Tuple<int, X> currentNode;
		X previous;
		X current;

		List<X> visited = new List<X>();
		PriorityQueue<Tuple<int, X>> toVisit = new PriorityQueue<Tuple<int, X>>();
		Dictionary<X, X> path = new Dictionary<X, X>();

		toVisit.enqueue (0, new Tuple<int,X>(0, x1));

		if (!(x1.Equals (x2))) {

			while(!toVisit.isEmpty()) {
				currentNode = toVisit.dequeue();

				if(currentNode.item2.Equals(x2)) {
					current = currentNode.item2;
					do {
						res.Add(current);
						path.TryGetValue (current, out previous);
						current = previous;
					} while(current != null && !current.Equals(x1));
					res.Add (x1);
					res.Reverse ();
					return res;
				}

				neighbour = graph.getNextNodes(currentNode.item2);

				foreach(X n in neighbour)
					if(!visited.Contains(n) && !path.ContainsKey(n)) {
						path.Add (n, currentNode.item2);
						toVisit.enqueue(currentNode.item1 + ((IAstarHeuristic<X>)graph).getHeuristic(n,x2), 
					                	new Tuple<int, X>(currentNode.item1 +1, n));
					}

				visited.Add(currentNode.item2);
			}
		} else {
			res.Add(x1);
			return res;
		}

		return null;
	}

	public Path<X, Y> getFullPath<X,Y>(IGraph<X, Y> graph, X x1, X x2) {
		Path<X, Y> res = new Path<X, Y> ();
		List<Tuple<X, Y>> neighbour;
		Tuple<int, X> currentNode;
		X current;
		Tuple<X, Y> previous;
		
		List<X> visited = new List<X>();
		PriorityQueue<Tuple<int, X>> toVisit = new PriorityQueue<Tuple<int, X>>();
		Dictionary<X, Tuple<X, Y>> path = new Dictionary<X, Tuple<X, Y>>();
		
		toVisit.enqueue (0, new Tuple<int,X>(0, x1));

		if (!x1.Equals (x2)) {
			while(!toVisit.isEmpty()) {
				currentNode = toVisit.dequeue();

				if(currentNode.item2.Equals(x2)) {
					res.start (x2);
					current = currentNode.item2;

					do {
						path.TryGetValue(current,out previous);
						res.addTransition(previous);
						current = previous.item1;
					} while(current != null && !current.Equals(x1));
					
					res.reverse();				
					return res;
				}

				neighbour = graph.getVertices(currentNode.item2);

				foreach(Tuple<X, Y> n in neighbour)
				if(!visited.Contains(n.item1) && !path.ContainsKey(n.item1)) {
					path.Add (n.item1, new Tuple<X, Y>(currentNode.item2, n.item2));
					toVisit.enqueue(currentNode.item1 + ((IAstarHeuristic<X>)graph).getHeuristic(n.item1,x2), 
					                new Tuple<int, X>(currentNode.item1 +1, n.item1));
				}
				
				visited.Add(currentNode.item2);
			}
		} else {
			res.start (x1);
			return res;
		}

		return null;
	}

	/// <summary>
	/// Gets path defined by the list of nodes and vertices
	/// precondition 1 : x1 and x2 belong to the graph
	/// precondition 2 : the graph has implements IAStarHeuristic ie defines the distance from any node to the end.
	/// </summary>
	/// <returns>The full path if their is one, null if not.</returns>
	/// <param name="graph">The graph in which we search a path.</param>
	/// <param name="x1">The start of the path.</param>
	/// <param name="x2">The end of the path.</param>
	/// <typeparam name="X">The type of nodes.</typeparam>
	/// <typeparam name="Y">The type of vertices.</typeparam>
	public Path<X, Y> getWeightedPath<X,Y>(IWeightGraph<X, Y> graph, X x1, X x2)  where Y : IWeightVertice {
		Path<X, Y> res = new Path<X, Y> ();
		List<Tuple<X, Y>> neighbour;
		Tuple<float, X> currentNode;
		X current;
		Tuple<X, Y> previous;
		
		List<X> visited = new List<X>();
		PriorityQueue<Tuple<float, X>> toVisit = new PriorityQueue<Tuple<float, X>>();
		Dictionary<X, Tuple<X, Y>> path = new Dictionary<X, Tuple<X, Y>>();
		
		toVisit.enqueue (0, new Tuple<float,X>(0, x1));
		
		if (!x1.Equals (x2)) {
			while(!toVisit.isEmpty()) {
				currentNode = toVisit.dequeue();

				if(currentNode.item2.Equals(x2)) {
					res.start (x2);
					current = currentNode.item2;
					
					do {
						path.TryGetValue(current,out previous);
						res.addTransition(previous);
						current = previous.item1;
					} while(current != null && !current.Equals(x1));
					
					res.reverse();				
					return res;
				}
				
				neighbour = graph.getVertices(currentNode.item2);
				
				foreach(Tuple<X, Y> n in neighbour)
				if(!visited.Contains(n.item1) && !path.ContainsKey(n.item1)) {
					path.Add (n.item1, new Tuple<X, Y>(currentNode.item2, n.item2));
					toVisit.enqueue(currentNode.item1 + ((IAstarHeuristic<X>)graph).getHeuristic(n.item1,x2), 
					                new Tuple<float, X>(currentNode.item1 + n.item2.getWeight(), n.item1));
				}
				
				visited.Add(currentNode.item2);
			}
		} else {
			res.start (x1);
			return res;
		}
		
		return null;
	}
}

public interface IAstarHeuristic<X> {

	float getHeuristic(X x1, X x2);
}