/* 
 * Linked List
 * 
 */

using System;
using A5.Task2;
using A5.Task1;
using System.Collections;

namespace A5.Task1
{
	public class DoublyLinkedList
	{
		private class Node
		{
			public int data;
			public Node next;
			public Node previous;

			public Node(int data, Node next, Node previous)
			{
				this.data = data;
				this.next = next;
				if (next != null)
				{
					next.previous = this;
				}
				this.previous = previous;
				if (previous != null)
				{
					previous.next = this;
				}
			}
			public Node(int data, Node next) : this(data, next, null) { }
			public Node(int data) : this(data, null, null) { }
		}

		private Node head; // Start of the list
		private Node tail; // End of the list


		/// <summary>
		///Add value into front
		/// </summary>
		/// <param name="value"></param>
		public void addFront(int value)
		{
			head = new Node(value, head);
			if (tail == null)
			{
				tail = head;
			}
		}


		/// <summary>
		///Add value into back
		/// </summary>
		/// <param name="value"></param>
		public void addBack(int value)
		{
			tail.next = new Node(value, null, tail);
			tail = tail.next;
			if (head == null)
			{
				head = tail;
			}
		}

		/// <summary>
		///remove from the front
		/// </summary>
		public int removeFront()
		{
			if (head == null)
			{
				throw new InvalidOperationException("List is empty");
			}
			int temp = head.data;
			head = head.next;
			if (head != null)
			{
				head.previous = null;
			}
			else
			{
				tail = null;
			}
			return temp;
		}

		/// <summary>
		///remove from the back
		/// </summary>
		public int removeBack()
		{
			if (tail == null)
			{
				throw new InvalidOperationException("List is empty");
			}
			int temp = tail.data;
			tail = tail.previous;
			if (tail != null)
			{
				tail.next = null;
			}
			else
			{
				head = null;
			}
			return temp;
		}

		/// <summary>
		/// add value into the index
		/// </summary>
		/// <param name="value">/param>
		/// <param name="index"></param>
		public void add(int value, int index)
		{
			int numElems = size();
			if (index < 0 || index >= numElems)
			{
				throw new IndexOutOfRangeException();
			}
			if (index == 0)
			{
				addFront(value);
			}
			else if (index == numElems)
			{
				addBack(value);
			}
			else
			{
				int count = 0;
				Node temp = head;
				while(count < index)
				{
					temp = temp.next;
					++count;
				}
				temp.next = new Node(value, temp.next, temp);
			}
		}

		/// <summary>
		/// remove value into the index
		/// </summary>
		/// <param name="index">/param>
		public int remove(int index)
		{
			int numElems = size();
			if (index < 0 || index >= numElems)
			{
				throw new IndexOutOfRangeException();
			}
			if (index == 0)
			{
				return removeFront();
			}
			if (index == numElems - 1)
			{
				return removeBack();
			}

			int count = 0;
			Node temp = head;
			while (count < index - 1)
			{
				temp = temp.next;
				++count;
			}

			int tmp = temp.next.data;
			temp.next = temp.next.next;
			if (temp.next != null)
			{
				temp.next.previous = temp;
			}
			return tmp;
		}

		/// <summary>
		/// check the size
		/// </summary>
		public int size()
		{
			int count = 0;
			Node temp = head;
			while (temp != null)
			{
				++count;
				temp = temp.next;
			}
			return count;
		}

		/// <summary>
		/// check the index of value
		/// </summary>
		/// <param name="value">/param>
		public int indexOf(int value)
		{
			Node temp = head;
			int idx = 0;
			while (temp != null)
			{
				if (temp.data == value)
				{
					return idx;
				}
				temp = temp.next;
				++idx;
			}
			return -1;
		}

		/// <summary>
		/// empty link list
		/// </summary>
		public bool empty()
		{
			return head == null; 
		}

		/// <summary>
		/// get the value into the index
		/// </summary>
		/// <param name="index">/param>
		public int get(int index)
		{
			if (index < 0 || index >= size())
			{
				throw new IndexOutOfRangeException();
			}

			int count = 0;
			Node temp = head;
			while (count < index)
			{
				temp = temp.next;
				++count;
			}
			return temp.data;
		}

		/// <summary>
		/// front of the link list
		/// </summary>
		public int front()
		{
			if (head == null)
			{
				throw new InvalidOperationException("List is empty");
			}
			return head.data;
		}

		/// <summary>
		/// back of the link list
		/// </summary>
		public int back()
		{
			if (tail == null)
			{
				throw new InvalidOperationException("List is empty");
			}
			return tail.data;
		}

		/// <summary>
		/// clear the link list
		/// </summary>
		public void clear()
		{
			head = null;
			tail = null;
		}
	}
}
