using System.Collections.Generic;

/// <summary>
/// Priority queue. Acts as a typical queue with the added information of the priority : the lower the priority, 
/// the sooner it is to be dequeued. At equal priority, to know which one will come out. it goes "first in first out"
/// like any queue.
/// </summary>
public class PriorityQueue<X> {

	// The list of elements with their respective priority. This structure is quite poor and should be modified. 
	List<Tuple<float, X>> queue;

	/// <summary>
	/// Initializes a new instance of the <see cref="PriorityQueue`1"/> class. Only creates queue data structure.
	/// </summary>
	public PriorityQueue() {
		queue = new List<Tuple<float,X>> ();
	}

	/// <summary>
	/// Enqueues the specified element with its according priority.
	/// </summary>
	/// <param name="priority">The priority of the element to enqueue.</param>
	/// <param name="element">The element to enqueue.</param>
	public void enqueue(float priority, X element) {
		if (isEmpty ())
			queue.Add (new Tuple<float, X> (priority, element));
		else {
			for (int i = 0; i < queue.Count; i++)
				if (queue [i].item1 > priority) {
					queue.Insert (i, new Tuple<float, X> (priority, element));
					return;
				}
			queue.Add (new Tuple<float, X> (priority, element)); 
		}
	}

	/// <summary>
	/// Dequeues the highest priority element of the queue and the oldest element for the given priority.
	/// </summary>
	/// <returns>The pair composed of the priority of the element and the element.</returns>
	public Tuple<float, X> dequeuePriority() {
		Tuple<float, X> pair = queue[0];
		queue.Remove (queue[0]);
		return pair;
	}

	/// <summary>
	/// Dequeues the highest priority element of the queue and the oldest element for the given priority.
	/// </summary>
	/// <returns>The selected element of the queue.</returns>
	public X dequeue() {
		Tuple<float, X> pair = queue[0];
		queue.Remove (queue[0]);
		return pair.item2;
	}

	/// <summary>
	/// Returns the highest priority and oldest element for said priority.
	/// </summary>
	/// <returns>The element and its priority in a Tuple</returns>
	public Tuple<float, X> peek() {
		return queue [0];
	}

	/// <summary>
	/// Remove all element of the queue.
	/// </summary>
	public void clear() {
		queue.Clear ();
	}

	/// <summary>
	/// Returns the number of element in the queue.
	/// </summary>
	/// <returns>The number of element in the queue.</returns>
	public int count() {
		return queue.Count;
	}

	/// <summary>
	/// Tests if their is elements in the queue.
	/// </summary>
	/// <returns><c>true</c>, if there is no elements in the queue, <c>false</c> otherwise.</returns>
	public bool isEmpty() {
		return queue.Count == 0;
	}
}

