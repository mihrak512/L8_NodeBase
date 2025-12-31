using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab8
{
    public class TovarList : IList, IComparable, ICloneable
    {
        private Tovar[] items;
        private int count;

        public TovarList()
        {
            items = new Tovar[4];
            count = 0;
        }

        public TovarList(int capacity)
        {
            if (capacity < 0)
            {
                Console.WriteLine("Ошибка: емкость не может быть отрицательной");
                items = new Tovar[4];
            }
            else
            {
                items = new Tovar[capacity];
            }
            count = 0;
        }

        public object this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                {
                    Console.WriteLine($"Ошибка: индекс {index} находится вне диапазона [0, {count - 1}]");
                    return null;
                }
                return items[index];
            }
            set
            {
                if (index < 0 || index >= count)
                {
                    Console.WriteLine($"Ошибка: индекс {index} находится вне диапазона [0, {count - 1}]");
                    return;
                }
                if (value == null)
                {
                    Console.WriteLine("Ошибка: элемент не может быть null");
                    return;
                }
                items[index] = (Tovar)value;
            }
        }

        public int Count
        {
            get { return count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool IsFixedSize
        {
            get { return false; }
        }

        public bool IsSynchronized
        {
            get { return false; }
        }

        public object SyncRoot
        {
            get { return this; }
        }

        public int Add(object value)
        {
            if (value == null)
            {
                Console.WriteLine("Ошибка: добавляемый элемент не может быть null");
                return -1;
            }

            if (count == items.Length)
            {
                Tovar[] newArray = new Tovar[items.Length * 2];
                Array.Copy(items, 0, newArray, 0, count);
                items = newArray;
            }

            items[count] = (Tovar)value;
            int addedIndex = count;
            count++;
            return addedIndex;
        }

        public void Clear()
        {
            Array.Clear(items, 0, count);
            count = 0;
        }

        public bool Contains(object value)
        {
            return IndexOf(value) >= 0;
        }

        public void CopyTo(Array array, int index)
        {
            if (array == null)
            {
                Console.WriteLine("Ошибка: массив не может быть null");
                return;
            }
            if (index < 0)
            {
                Console.WriteLine("Ошибка: индекс не может быть отрицательным");
                return;
            }
            if (array.Length - index < count)
            {
                Console.WriteLine("Ошибка: недостаточно места в целевом массиве");
                return;
            }

            Array.Copy(items, 0, array, index, count);
        }

        public IEnumerator GetEnumerator()
        {
            Tovar[] tempArray = new Tovar[count];
            for (int i = 0; i < count; i++)
            {
                tempArray[i] = items[i];
            }
            return tempArray.GetEnumerator();
        }

        public int IndexOf(object value)
        {
            if (value == null)
            {
                return -1;
            }

            Tovar tovarValue = (Tovar)value;
            for (int i = 0; i < count; i++)
            {
                if (object.Equals(items[i], tovarValue))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, object value)
        {
            if (index < 0 || index > count)
            {
                Console.WriteLine($"Ошибка: индекс {index} находится вне диапазона [0, {count}]");
                return;
            }
            if (value == null)
            {
                Console.WriteLine("Ошибка: вставляемый элемент не может быть null");
                return;
            }

            if (count == items.Length)
            {
                Tovar[] newArray = new Tovar[items.Length * 2];
                Array.Copy(items, 0, newArray, 0, count);
                items = newArray;
            }

            for (int i = count; i > index; i--)
            {
                items[i] = items[i - 1];
            }

            items[index] = (Tovar)value;
            count++;
        }

        public void Remove(object value)
        {
            int index = IndexOf(value);
            if (index >= 0)
            {
                RemoveAt(index);
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
            {
                Console.WriteLine($"Ошибка: индекс {index} находится вне диапазона [0, {count - 1}]");
                return;
            }

            for (int i = index; i < count - 1; i++)
            {
                items[i] = items[i + 1];
            }

            items[count - 1] = null;
            count--;
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            TovarList otherList = obj as TovarList;
            if (otherList != null)
            {
                return this.Count.CompareTo(otherList.Count);
            }

            Console.WriteLine("Ошибка: объект не является TovarList");
            return 0;
        }

        public object Clone()
        {
            TovarList cloneList = new TovarList(this.count);
            for (int i = 0; i < this.count; i++)
            {
                Tovar clonedTovar = (Tovar)this.items[i].Clone();
                cloneList.Add(clonedTovar);
            }
            return cloneList;
        }

        public override string ToString()
        {
            return $"TovarList с {count} элементами";
        }

        public void AddRange(Tovar[] collection)
        {
            if (collection == null)
            {
                Console.WriteLine("Ошибка: коллекция не может быть null");
                return;
            }

            foreach (Tovar item in collection)
            {
                Add(item);
            }
        }

        public Tovar FindByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Ошибка: имя для поиска не может быть пустым");
                return null;
            }

            for (int i = 0; i < count; i++)
            {
                if (items[i].Name == name)
                {
                    return items[i];
                }
            }
            return null;
        }

        public void PrintAll()
        {
            Console.WriteLine("Содержимое списка:");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{i}: {items[i].Name}");
            }
        }

        public Tovar GetMostExpensive()
        {
            if (count == 0)
            {
                Console.WriteLine("Список пуст");
                return null;
            }

            Tovar mostExpensive = items[0];
            for (int i = 1; i < count; i++)
            {
                if (items[i].Cost > mostExpensive.Cost)
                {
                    mostExpensive = items[i];
                }
            }
            return mostExpensive;
        }
    }
}