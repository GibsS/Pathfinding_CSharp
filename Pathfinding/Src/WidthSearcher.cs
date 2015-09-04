using System.Collections.Generic;

/// <summary>
/// WidthSearcher. Defines a pathfinder that finds a path through a simple breadth search.
/// </summary>
public class WidthSearcher : IPathFinder {

	public List<X> getNodePath<X>(IGraph<X> graph, X x1, X x2) {
		List<X> res = new List<X>();
		List<X> neighbour;
		X 		currentNode;
		X 		previous;
							
		List<X> visited = new List<X>();
		Queue<X> toVisit = new Queue<X>();
		Dictionary<X, X> path = new Dictionary<X, X>();

		toVisit.Enqueue (x1);

		if (!x1.Equals (x2)) {
			while (toVisit.Count > 0) {
				currentNode = toVisit.Dequeue ();

				if (currentNode.Equals (x2)) {
						do {
							res.Add(currentNode);
							path.TryGetValue (currentNode, out previous);
							currentNode = previous;
						} while(currentNode != null && !currentNode.Equals(x1));
						res.Add (x1);
						res.Reverse ();
						return res;
				}
				neighbour = graph.getNextNodes (currentNode);

				foreach (X n in neighbour) 
					if (!visited.Contains (n) && !path.ContainsKey (n)) {
						path.Add (n, currentNode);
						toVisit.Enqueue (n);
					}
				visited.Add (currentNode);
			}
			return null;
		} else {
			res.Add (x1);
			return res;
		}
	}

	public Path<X,Y> getFullPath<X, Y>(IGraph<X, Y> graph, X x1, X x2) {
		Path<X,Y> res = new Path<X, Y> ();
		List<Tuple<X, Y>> neighbour = new List<Tuple<X, Y>> ();
		X currentNode;
		Tuple<X, Y> previous;

		List<X> visited  = new List<X> ();
		Queue<X> toVisit = new Queue<X> ();
		Dictionary<X, Tuple<X,Y>> path = new Dictionary<X, Tuple<X,Y>>();

		toVisit.Enqueue (x1);

		if (!x1.Equals (x2)) {
			while(toVisit.Count > 0) {
				currentNode = toVisit.Dequeue();

				if(currentNode.Equals(x2)) {
					res.start (x2);

					do {
						path.TryGetValue(currentNode,out previous);
						res.addTransition(previous);
						currentNode = previous.item1;
					} while(currentNode != null && !currentNode.Equals(x1));

					res.reverse();

					return res;
				} 

				neighbour = graph.getVertices(currentNode);

				foreach(Tuple<X, Y> pair in neighbour)
					if(!visited.Contains(pair.item1) && !path.ContainsKey(pair.item1)) {
						path.Add (pair.item1, new Tuple<X, Y>(currentNode,pair.item2));
						toVisit.Enqueue (pair.item1);
					}
				visited.Add (currentNode);
			}
		} else {
			res.start (x1);
			return res;
		}

		return null;
	}
}

