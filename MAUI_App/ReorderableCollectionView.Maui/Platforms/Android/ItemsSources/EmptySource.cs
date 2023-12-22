﻿using Microsoft.Maui.Controls.Handlers.Items;

// Cloned from the main .NET MAUI repository.
// No changes were made.
// https://github.com/dotnet/maui/tree/main/src/Controls/src/Core/Handlers/Items/Android/ItemsSources/EmptySource.cs
namespace ReorderableCollectionView.Maui
{
	sealed internal class EmptySource : IItemsViewSource
	{
		public int Count => 0;

		public bool HasHeader { get; set; }
		public bool HasFooter { get; set; }

		public void Dispose()
		{

		}

		public bool IsHeader(int index)
		{
			return HasHeader && index == 0;
		}

		public bool IsFooter(int index)
		{
			if (!HasFooter)
			{
				return false;
			}

			if (HasHeader)
			{
				return index == 1;
			}

			return index == 0;
		}

		public int GetPosition(object item)
		{
			return -1;
		}

		public object GetItem(int position)
		{
			throw new System.IndexOutOfRangeException("IItemsViewSource is empty");
		}
	}
}