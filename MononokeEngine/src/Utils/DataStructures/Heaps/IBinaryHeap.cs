namespace MononokeEngine.Utils.DataStructures.Heaps
{
	/// <summary>
	/// Copyright (c) 2019 Paco Juan Quirós
	/// Licensed under the MIT License.
	///
	/// Interface for a Binary Heap.
	/// 
	/// </summary>
	public interface IBinaryHeap<T>
	{
		void Add(T element);
		

		/// <summary>
		/// Retrieves and removes.
		/// </summary>
		/// <returns>Element with more priority</returns>
		T Poll();
		

		/// <summary>
		/// Retrieves, but doesn't remove.
		/// </summary>
		/// <returns>Element with more priority</returns>
		T Peek();
		
		
		bool Contains(T element);
		

		bool Remove(T element);
	}
}