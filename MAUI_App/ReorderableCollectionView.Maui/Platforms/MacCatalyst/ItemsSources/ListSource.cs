using System;
using System.Collections;
using System.Collections.Generic;
using Foundation;
using Microsoft.Maui.Controls.Handlers.Items;

// Cloned from the main .NET MAUI repository.
// Updated class to use original source if the source is already an IList.
// Also includes fix from Xamarin.Forms which has yet to be implemented in Maui repo.
// https://github.com/xamarin/Xamarin.Forms/pull/14621
// https://github.com/dotnet/maui/tree/main/src/Controls/src/Core/Handlers/Items/iOS/ListSource.cs
namespace ReorderableCollectionView.Maui
{
	class ListSource : IList, IItemsViewSource
	{
		IList _itemsSource;

		public ListSource()
		{
		}

		public ListSource(IList list)
		{
			_itemsSource = list;
		}

		public ListSource(IEnumerable<object> enumerable)
		{
			_itemsSource = new List<object>(enumerable);
		}

		public ListSource(IEnumerable enumerable)
		{
			_itemsSource = new List<object>();

			if (enumerable == null)
				return;

			foreach (object item in enumerable)
			{
				_itemsSource.Add(item);
			}
		}

		public void Dispose()
		{

		}

		public object this[NSIndexPath indexPath]
		{
			get
			{
				if (indexPath.Section > 0)
				{
					throw new ArgumentOutOfRangeException(nameof(indexPath));
				}

				return _itemsSource[(int)indexPath.Item];
			}
		}

		public int GroupCount => 1;

		public int ItemCount => _itemsSource.Count;

		public int Count => _itemsSource.Count;

		public bool IsReadOnly => _itemsSource.IsReadOnly;

		public bool IsFixedSize => _itemsSource.IsFixedSize;

		public object SyncRoot => _itemsSource.SyncRoot;

		public bool IsSynchronized => _itemsSource.IsSynchronized;

		object IList.this[int index] { get => _itemsSource[index]; set => _itemsSource[index] = value; }

		public NSIndexPath GetIndexForItem(object item)
		{
			for (int n = 0; n < _itemsSource.Count; n++)
			{
				if (ItemComparer.AreEquals(_itemsSource[n], item))
				{
					return NSIndexPath.Create(0, n);
				}
			}

			return NSIndexPath.Create(-1, -1);
		}

		public object Group(NSIndexPath indexPath)
		{
			return null;
		}

		public int ItemCountInGroup(nint group)
		{
			if (group > 0)
			{
				throw new ArgumentOutOfRangeException(nameof(group));
			}

			return _itemsSource.Count;
		}

		public int Add(object value)
		{
			return _itemsSource.Add(value);
		}

		public bool Contains(object value)
		{
			return _itemsSource.Contains(value);
		}

		public void Clear()
		{
			_itemsSource.Clear();
		}

		public int IndexOf(object value)
		{
			return _itemsSource.IndexOf(value);
		}

		public void Insert(int index, object value)
		{
			_itemsSource.Insert(index, value);
		}

		public void Remove(object value)
		{
			_itemsSource.Remove(value);
		}

		public void RemoveAt(int index)
		{
			_itemsSource.RemoveAt(index);
		}

		public void CopyTo(Array array, int index)
		{
			_itemsSource.CopyTo(array, index);
		}

		public IEnumerator GetEnumerator()
		{
			return _itemsSource.GetEnumerator();
		}
	}
}