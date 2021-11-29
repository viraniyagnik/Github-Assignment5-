using A5.Task1;
using System.Collections;
namespace A5.Task2
{
	public class ArraySet<T> : ISet<T>
	{
		private int[] data;
		private int numItems;

		
		public bool add(T value)
		{
			// TODO Auto-generated method stub
			
			return false;
		}

		public void addMany(params T[] args )
		{
			// Auto-generated method 
			foreach (T i in args)
			{
				add(i);
			}
		}

		public void addAll(ISet<T> otherSet)
		{
			//Auto-generated method
			foreach (ISet<T>  i in otherSet)
			{
				add(i);
			}
		}

		public bool remove(T value)
		{
			// TODO Auto-generated method stub
			int idx = 0;
			for (; idx < numItems && !(data[idx] == T value); ++idx) ;

			if (idx == numItems)
			{
				return false;
			}
			--numItems;
			if (numItems > 0)
			{
				data[idx] = data[numItems];
			}
			return true;
			
		}

		public bool contains(T target)
		{
			for (int i = 0; i < numItems; ++i)
			{
				if (data[i] == target)
				{
					return true;
				}
			}
			return false;
		}

		public T get(int index)
		{
			if (index < numItems && index >= 0)
			{
				return data[index];
			}
			throw new IndexOutOfRangeException();
		}

		public int size()
		{
			return numItems;
		}

		public bool isEmpty()
		{
			
			return numItems == 0;
		}

		public void clear()
		{
			
			numItems = 0;
		}

		public override string ToString()
		{
			// TODO Auto-generated method stub
			String str = "ArraySet[";
			for (int i = 0; i < numItems; ++i)
			{
				str += data[i];
				if (i != numItems - 1)
				{
					str += ", ";
				}
			}
			return str += "]";
		}

		public bool equals(object other)
		{
			// TODO Auto-generated method stub
			if (this == other)
			{
				return true;
			}
			if (other == null)
			{
				return false;
			}
			if (other.GetType() != typeof(ISet))
			{
				return false;
			}
			ISet set = (ISet)other;
			if (set.size() != size())
			{
				return false;
			}
			if (isEmpty())
			{
				return true;
			}
			for (int i = 0; i < numItems; ++i)
			{
				if (!set.contains(data[i]))
				{
					return false;
				}
			}
			return true;
			return false;
		}
	}
}
