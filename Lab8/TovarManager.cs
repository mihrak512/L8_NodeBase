using System;
namespace Lab8
{
	class TovarManager
	{
        Tovar[] items;
		public TovarManager(Tovar[] Items)
		{
			items = Items;
		}
        public void PrintAll()
        {
            Console.WriteLine("Список товаров:");
            for (int i = 0; i < items.Length; i++)
                Console.WriteLine(items[i]);
        }
        public void SortByPrice()
        {
            for (int i = 0; i < items.Length - 1; i++)
            {
                for (int j = i + 1; j < items.Length; j++)
                {
                    if (items[i].Cost > items[j].Cost)
                    {
                        Tovar temp = items[i];
                        items[i] = items[j];
                        items[j] = temp;
                    }
                }
            }
        }
        public Tovar FindMostExpensive()
        {
            if (items.Length == 0) return null;

            Tovar max = items[0];
            for (int i = 1; i < items.Length; i++)
            {
                if (items[i].Cost > max.Cost)
                {
                    max = items[i];
                }
            }
            return max;
        }
        public Tovar FindCheapest()
        {
            if (items.Length == 0) return null;

            Tovar min = items[0];
            for (int i = 1; i < items.Length; i++)
            {
                if (items[i].Cost < min.Cost)
                {
                    min = items[i];
                }
            }
            return min;
        }
    }
}

