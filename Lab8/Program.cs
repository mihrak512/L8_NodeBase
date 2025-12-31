using System;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            Toy toy = new Toy("Кукла", "Игрушки", "Mattel", 250, 2, true, "10.11.2025",
                "Классическая", 0.8f, new int[] { 4, 5 });

            Book book = new Book("Сказки", "Книги", "Белкнига", 120, 3, false, "15.11.2025",
                "Пушкин", "Детская", 100, new int[] { 6, 7 });

            Electronic elec = new Electronic("Планшет", "Электроника", "Samsung", 999, 1,
                false, "30.11.2025", "Tablet", 15, 24);

            Transport tr = new Transport("Электросамокат", "Транспорт", "Xiaomi", 1200, 1,
                false, "01.12.2025", "Mi Scooter Pro", "Самокат", 25, true);

            Console.WriteLine("=== ДЕМОНСТРАЦИЯ IList ===");
            TovarList tovarList = new TovarList();

            Console.WriteLine("\n1. Метод Add:");
            int index1 = tovarList.Add(toy);
            Console.WriteLine($"Добавлена игрушка на индекс: {index1}");

            int index2 = tovarList.Add(book);
            Console.WriteLine($"Добавлена книга на индекс: {index2}");

            int nullIndex = tovarList.Add(null);
            Console.WriteLine($"Попытка добавления null: {nullIndex}");

            Console.WriteLine($"\n2. Свойство Count: {tovarList.Count}");

            Console.WriteLine($"\n3. Метод Contains (книга): {tovarList.Contains(book)}");
            Console.WriteLine($"Метод Contains (null): {tovarList.Contains(null)}");

           

            Console.WriteLine("\n5. Метод Insert:");
            Toy newToy = new Toy("Мяч", "Игрушки", "Nike", 300, 1, false,
                "10.11.2026", "Спортивный", 0.5f, new int[] { 6, 7, 8 });

            tovarList.Insert(1, newToy);
            Console.WriteLine("Мяч вставлен на позицию 1");

            tovarList.Insert(10, newToy);

            Console.WriteLine("\n6. Метод Remove:");
            tovarList.Remove(book);
            Console.WriteLine("Книга удалена");

            Console.WriteLine("\n7. Метод RemoveAt:");
            tovarList.RemoveAt(0);
            Console.WriteLine("Удален элемент по индексу 0");

            tovarList.RemoveAt(10);

            tovarList.Add(toy);
            tovarList.Add(book);
            tovarList.Add(elec);
            tovarList.Add(tr);
            

            Console.WriteLine("\n8. Индексатор:");
            Tovar firstItem = (Tovar)tovarList[0];
            if (firstItem != null)
            {
                Console.WriteLine($"Элемент по индексу 0: {firstItem.Name}");
            }

            Tovar invalidItem = (Tovar)tovarList[10];
            if (invalidItem == null)
            {
                Console.WriteLine("Элемент по индексу 10 не найден");
            }

            Console.WriteLine("\n9. Метод CopyTo:");
            Tovar[] array = new Tovar[tovarList.Count];
            tovarList.CopyTo(array, 0);
            Console.WriteLine("Скопированный массив:");
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"  - {array[i].Name}");
            }

            Console.WriteLine("\n10. Метод Clear:");
            tovarList.Clear();
            Console.WriteLine($"После очистки Count: {tovarList.Count}");

            tovarList.Add(toy);
            tovarList.Add(book);
            tovarList.Add(elec);
            tovarList.Add(tr);

            Console.WriteLine("\n=== ДЕМОНСТРАЦИЯ IComparable ===");

            TovarList anotherList = new TovarList();
            anotherList.Add(toy);
            anotherList.Add(book);

            int comparison = tovarList.CompareTo(anotherList);
            Console.WriteLine($"Сравнение списков: {comparison} (первый список больше)");

            Console.WriteLine("\n=== СОРТИРОВКА Array.Sort ===");
            Tovar[] tovarArray = new Tovar[] { toy, book, elec, tr };
            Array.Sort(tovarArray);

            Console.WriteLine("Отсортированный массив по цене:");
            for (int i = 0; i < tovarArray.Length; i++)
            {
                Console.WriteLine($"{tovarArray[i].Name} - {tovarArray[i].Cost} руб.");
            }

            Console.WriteLine("\n=== ДЕМОНСТРАЦИЯ ICloneable ===");

            TovarList clonedList = (TovarList)tovarList.Clone();
            Console.WriteLine($"Оригинальный список: {tovarList}");
            Console.WriteLine($"Клонированный список: {clonedList}");

            Tovar maxPriceItem = null;
            for (int i = 0; i < tovarArray.Length; i++)
            {
                if (maxPriceItem == null || tovarArray[i].Cost > maxPriceItem.Cost)
                {
                    maxPriceItem = tovarArray[i];
                }
            }

            if (maxPriceItem != null)
            {
                Tovar clonedMaxItem = (Tovar)maxPriceItem.Clone();
                Console.WriteLine($"\nОригинал (макс. цена): {maxPriceItem.Name} - {maxPriceItem.Cost} руб.");
                Console.WriteLine($"Клон (макс. цена): {clonedMaxItem.Name} - {clonedMaxItem.Cost} руб.");

                bool areSame = object.ReferenceEquals(maxPriceItem, clonedMaxItem);
                Console.WriteLine($"Это один и тот же объект? {areSame}");
            }
            Tovar found = tovarList.FindByName("Планшет");
            if (found != null)
            {
                Console.WriteLine($"Найден товар: {found.Name}");
            }

            Tovar expensive = tovarList.GetMostExpensive();
            if (expensive != null)
            {
                Console.WriteLine($"Самый дорогой товар: {expensive.Name} - {expensive.Cost} руб.");
            }

            tovarList.PrintAll();
            Console.WriteLine(tovarList.IndexOf(elec));
        }
    }
}