using System;
using System.Collections.Generic;
using System.Text;

namespace Mononoke.DataStructures.Heaps
{
	/// <summary>
	/// Copyright (c) 2019 Paco Juan Quirós
	///
	/// Original source: https://github.com/pacojq/PJDataStructures
	/// Licensed under the MIT License.
	/// </summary>
	public class BinaryHeap<T> : IBinaryHeap<T> where T : IComparable<T>
	{

		public int Count => _heap.Count;
		public bool IsEmpty => Count == 0;
		
	
		
		private readonly List<HeapNode<T>> _heap;


		public BinaryHeap()
		{
			_heap = new List<HeapNode<T>>();
		}
		
		
		public BinaryHeap(IEnumerable<T> elements) : this()
		{
			foreach (T e in elements)
				_heap.Add(new HeapNode<T>(e));
		
			for (int i = Count/2; i >= 0; i --)
				FilterDown(i);
		}



		#region "PUBLIC METHODS"

		public void Add(T element)
		{
			if (!Contains(element))
			{			
				_heap.Add(new HeapNode<T>(element));
				FilterUp(_heap.Count - 1);
			}
		}

		public bool Contains(T element)
		{
			return _heap.Find(n => element.Equals(n.Element)) != null;
		}
		
		/// <summary>
		/// Retrieves and removes.
		/// </summary>
		/// <returns></returns>
		public T Poll()
		{
			if (IsEmpty)
				return default(T);
		
			// Get First
			T element = RemoveNodeAt(0).Element;
		
			// Reorder
			if (_heap.Count > 0)
			{
				_heap.Insert(0, RemoveNodeAt(Count - 1));
				FilterDown(0);
			}
		
			return element;
		}

		/// <summary>
		/// Retrieves, but doesn't remove.
		/// </summary>
		/// <returns></returns>
		public T Peek()
		{
			if (IsEmpty)
				return default(T);
			
			return _heap[0].Element;
		}

		public bool Remove(T element)
		{
			int index = GetIndex(element);
			if (index == -1)
				return false;

			_heap[index].MinusInfiniteWeight = true;
			FilterUp(index);

			Poll();
			
			return true;
		}


		public override string ToString()
		{
			StringBuilder str = new StringBuilder();

			str.Append("[");

			for (int i = 0; i < _heap.Count - 1; i++)
				str.Append(_heap[i].Element + ", ");
			
			if (_heap.Count > 0)
				str.Append(_heap[Count-1].Element);

			str.Append("]");

			return str.ToString();
		}

		#endregion


		
		

	
		
		#region "FILTERING"

		private void FilterUp(int pos)
		{
			if (!IsValidIndex(pos))
				return;
		
			var node = _heap[pos];
			int comp = node.CompareTo( _heap[GetParent(pos)] );
		
			while (pos > 0 && comp < 0)
			{
				Swap(pos, GetParent(pos));
				pos = GetParent(pos);
				comp = node.CompareTo( _heap[GetParent(pos)] );
			}			
		}
		
		
		private void FilterDown(int pos)
		{
		
			if (!IsValidIndex(pos))
				return;

			while (!IsLeaf(pos))
			{
				var node = _heap[pos];
				int posL = GetLeftChild(pos);
				int posR = GetRightChild(pos);
			
				int childComp; // The comparison between the left child and the right child
				if (!IsValidIndex(posR)) childComp = -1; // -1 = left
				else childComp = _heap[posL].CompareTo( _heap[posR] );
			
				if (childComp < 0) // Swapping with left child
				{
					if (_heap[posL].CompareTo(node) < 0)
					{
						Swap(pos, posL);
						pos = GetLeftChild(pos);
					}
					else break;
				}
				else // Swapping with the right child
				{
					if (_heap[posR].CompareTo(node) < 0)
					{
						Swap(pos, posR);
						pos = GetRightChild(pos);
					}
					else break;
				}		
			
			}
		}

		#endregion
		
		
		
		
		
		
	
		#region "NODE MANAGEMENT"
		
		
		private int GetIndex(T element)
		{
			int index = -1;
			for (int i = 0; i < Count; i++)
			{
				if (_heap[i].Element.Equals(element))
				{
					index = i;
					break;
				}
			}

			return index;
		}
		
		
		private void Swap(int indexA, int indexB)
		{
			var temp = _heap[indexA];
			_heap[indexA] = _heap[indexB];
			_heap[indexB] = temp;
		}
		
		private HeapNode<T> RemoveNodeAt(int index)
		{
			var element = _heap[index];
			_heap.RemoveAt(index);
			return element;
		}
		
		private int GetParent(int pos)
		{
			return (pos - 1)/2;
		}
	
		private int GetLeftChild(int pos)
		{
			return 2*pos + 1;
		}
	
		private int GetRightChild(int pos)
		{
			return 2*pos + 2;
		}
	
		private bool IsLeaf(int pos)
		{
			bool left = GetLeftChild(pos) >= _heap.Count;
			bool right = GetRightChild(pos) >= _heap.Count;
		
			return right && left;
		}
	
		private bool IsValidIndex(int pos)
		{
			return pos >= 0 && pos < _heap.Count;
		}
		
		#endregion
		
	}
}