/* Copyright (c) 2018, Ádám L. Juhász
 *
 * This file is part of AquariaRecepies.
 *
 * AquariaRecepies is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * AquariaRecepies is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with AquariaRecepies.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAL.AquariaRecipes.Recipes
{
    public class OwnedList<T> : IList<T>, IList
    {
        private List<T> innerList = new List<T>();

        public IListOwner<T> Owner { get; }

        public int Count => innerList.Count;

        public bool IsReadOnly => ((IList<T>)innerList).IsReadOnly;

        public bool IsFixedSize => ((IList)innerList).IsFixedSize;

        public object SyncRoot => ((IList)innerList).SyncRoot;

        public bool IsSynchronized => ((IList)innerList).IsSynchronized;

        object IList.this[int index] { get => ((IList)innerList)[index]; set => ((IList)innerList)[index] = value; }

        public T this[int index] { get => innerList[index]; set => innerList[index] = value; }

        public OwnedList(IListOwner<T> owner) => Owner = owner;

        public int IndexOf(T item) => innerList.IndexOf(item);

        public void Insert(int index, T item)
        {
            innerList.Insert(index, item);
            Owner.Add(item);
        }

        public void RemoveAt(int index)
        {
            T element = innerList[index];
            innerList.RemoveAt(index);
            Owner.Remove(element);
        }

        public void Add(T item)
        {
            innerList.Add(item);
            Owner.Add(item);
        }

        public void Clear() => innerList.Clear();

        public bool Contains(T item) => innerList.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => innerList.CopyTo(array, arrayIndex);

        public bool Remove(T item)
        {
            try
            {
                return innerList.Remove(item);
            }
            finally
            {
                Owner.Remove(item);
            }
        }

        public IEnumerator<T> GetEnumerator() => innerList.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => innerList.GetEnumerator();

        public int Add(object value)
        {
            int result;
            result = ((IList)innerList).Add(value);
            if (result >= 0) Owner.Add((T)value);
            return result;
        }

        public bool Contains(object value) => ((IList)innerList).Contains(value);

        public int IndexOf(object value) => ((IList)innerList).IndexOf(value);

        public void Insert(int index, object value)
        {
            ((IList)innerList).Insert(index, value);
            if (value is T) Owner.Add((T)value);
        }

        public void Remove(object value)
        {
            ((IList)innerList).Remove(value);
            if (value is T) Owner.Remove((T)value);
        }

        public void CopyTo(Array array, int index) => ((IList)innerList).CopyTo(array, index);
    }
}
