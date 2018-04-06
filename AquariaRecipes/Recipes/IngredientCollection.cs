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
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAL.AquariaRecipes.Recipes
{
    public class IngredientCollection : IList, IList<IIngredient>, INotifyCollectionChanged
    {
        private sealed class IngredientCollectionEnumerator : IEnumerator<IIngredient>
        {
            private int index;
            private IngredientCollection collection;

            public IngredientCollectionEnumerator(IngredientCollection collection)
            {
                this.collection = collection ?? throw new ArgumentNullException(nameof(collection));
                Reset();
            }

            public IIngredient Current => collection.ingredients[index];

            object IEnumerator.Current => Current;

            public void Dispose() { }

            public bool MoveNext() => index < collection.count && ++index < collection.Count;

            public void Reset() => index = -1;
        }

        private int count = 0;
        private IIngredient[] ingredients = new IIngredient[3];

        public IngredientCollection(params IIngredient[] ingredients)
            : this(ingredients.AsEnumerable())
        { }

        public IngredientCollection(IEnumerable<IIngredient> ingredients)
        {
            ingredients = from ingredient in ingredients
                          where ingredient != null
                          select ingredient;

            foreach (IIngredient ingredient in ingredients.Take(3))
            {
                Add(ingredient);
            }
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public bool IsSimpleRecepie => count == 2;

        public bool IsComplexRecepie => count == 3;

        public int Count => count;

        public bool IsReadOnly => false;

        public bool IsFixedSize => false;

        public object SyncRoot => ingredients;

        public bool IsSynchronized => true;

        object IList.this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IIngredient this[int index] { get => ingredients[index]; set => ingredients[index] = value; }

        public void Add(IIngredient item)
        {
            if (count == 3)
                throw new InvalidOperationException("Recipes cannot have more ingredients than 3.");

            ingredients[count++] = item ?? throw new ArgumentNullException(nameof(item));

            OnCollectionChanged(NotifyCollectionChangedAction.Add, item, count - 1);
        }

        public bool Remove(IIngredient item)
        {
            int i;
            int found = -1;

            for (i = 0; i < count; ++i)
            {
                if (found >= 0)
                {
                    ingredients[i - 1] = ingredients[i];
                }

                else if (ingredients[i].Equals(item))
                {
                    found = i;
                    --count;
                }
            }

            if (found >= 0 && i < ingredients.Length)
            {
                ingredients[i] = null;
            }

            if (found >= 0)
            {
                OnCollectionChanged(NotifyCollectionChangedAction.Remove, item, found);
            }

            return found >= 0;
        }

        public void Clear()
        {
            count = 0;
            Array.Clear(ingredients, 0, ingredients.Length);

            OnCollectionChanged(NotifyCollectionChangedAction.Reset);
        }

        public bool Contains(IIngredient item)
        {
            for (int i = 0; i < count; ++i)
            {
                if (ingredients[i].Equals(item)) return true;
            }
            return false;
        }

        public void CopyTo(IIngredient[] array, int arrayIndex)
        {
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));

            if (array.Length - arrayIndex < count)
                throw new ArgumentException();

            for (int i = 0; i < count; ++i)
            {
                array[arrayIndex + i] = ingredients[i];
            }
        }

        public IEnumerator<IIngredient> GetEnumerator()
        {
            return new IngredientCollectionEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        protected virtual void OnCollectionChanged(NotifyCollectionChangedAction action)
        {
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action));
        }

        protected virtual void OnCollectionChanged(NotifyCollectionChangedAction action, object newItem, int newIndex)
        {
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, newItem, newIndex));
        }

        public int IndexOf(IIngredient item) => Array.IndexOf(ingredients, item);

        public void Insert(int index, IIngredient item)
        {
            if (count == 3)
                throw new InvalidOperationException("Recipes cannot have more ingredients than 3.");

            for (int i = count++; i > index; --i)
            {
                ingredients[i] = ingredients[i - 1];
            }

            ingredients[index] = item;

            OnCollectionChanged(NotifyCollectionChangedAction.Add, item, index);
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
                throw new ArgumentOutOfRangeException(nameof(index));

            ////// Kept for reference //////

            //--count;

            //for (int i = index; i < count; ++i)
            //{
            //    ingredients[i] = ingredients[i + 1];
            //}

            //ingredients[count] = null;

            //OnCollectionChanged(NotifyCollectionChangedAction.Remove, null, index);

            Remove(ingredients[index]);
        }

        public int Add(object value)
        {
            Add(value as IIngredient ?? throw new ArgumentException($"Cannot add {value.GetType()} to the ingredient list.", nameof(value)));
            return count - 1;
        }

        public bool Contains(object value) => value is IIngredient && Contains((IIngredient)value);

        public int IndexOf(object value) => value is IIngredient ? IndexOf((IIngredient)value) : -1;

        public void Insert(int index, object value)
        {
            Insert(index, value as IIngredient ?? throw new ArgumentException($"Cannot add {value.GetType()} to the ingredient list.", nameof(value)));
        }

        public void Remove(object value)
        {
            if (!(value is IIngredient))
                return;

            Remove((IIngredient)value);
        }

        public void CopyTo(Array array, int index) => Array.Copy(ingredients, 0, array, index, count);
    }
}
