using System;

namespace Mononoke.DataStructures.Heaps
{
	/// <summary>
	/// Copyright (c) 2019 Paco Juan Quirós
	///
	/// Original source: https://github.com/pacojq/PJDataStructures
	/// Licensed under the MIT License.
	/// </summary>
	internal class HeapNode<T> : IComparable<HeapNode<T>>
			where T : IComparable<T>
	{
		public T Element;
		public bool MinusInfiniteWeight;
			
		public HeapNode(T element)
		{
			MinusInfiniteWeight = false;
			Element = element;
		}

		public int CompareTo(HeapNode<T> other)
		{
			if (MinusInfiniteWeight)
				return -1;

			return Element.CompareTo(other.Element);
		}
	}
}