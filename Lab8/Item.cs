using System;

namespace Lab8
{
    public abstract class Item : IComparable
    {
        public abstract void TypeOfClass();

        public virtual int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            Item otherItem = obj as Item;
            if (otherItem != null)
            {
                return this.GetType().Name.CompareTo(otherItem.GetType().Name);
            }

            return 0;
        }
    }
}