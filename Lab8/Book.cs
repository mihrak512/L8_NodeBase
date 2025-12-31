using System;

namespace Lab8
{
    public class Book : Tovar
    {
        private string author;
        private string genre;
        private int pages;
        private int[] audienceAges;

        public string Author
        {
            get { return author; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    author = value;
                else
                    author = "Неизвестен";
            }
        }

        public string Genre
        {
            get { return genre; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    genre = value;
                else
                    genre = "Без жанра";
            }
        }

        public int Pages
        {
            get { return pages; }
            set { pages = value > 0 ? value : 100; }
        }

        public int[] AudienceAges
        {
            get { return audienceAges; }
            set
            {
                foreach (int age in value)
                    if (age < 0 || age > 120)
                    {
                        Console.WriteLine("Ошибка: возраст вне диапазона");
                        audienceAges = new int[] { 12 };
                        return;
                    }
                audienceAges = value;
            }
        }

        public Book(string name, string category, string manufacturer, double cost, int kol, bool IsDamaged, string ExpirationDate,
                    string author, string genre, int pages, int[] audienceAges)
            : base(name, category, manufacturer, cost, kol, IsDamaged, ExpirationDate)
        {
            Author = author;
            Genre = genre;
            Pages = pages;
            AudienceAges = audienceAges;
        }

        public override void TypeOfClass()
        {
            Console.WriteLine("Это книга");
        }

        public override double GetTotalPrice()
        {
            return Cost * Kol;
        }

        public void ShowRecommendedAges()
        {
            Console.Write("Книга рекомендована для возрастов: ");
            Console.WriteLine(string.Join(", ", AudienceAges));
        }

        public override string ToString()
        {
            return base.ToString() + $"\nАвтор: {Author}\nЖанр: {Genre}\nСтраниц: {Pages}\nВозраст: {string.Join(", ", AudienceAges)}";
        }

        public override void ShowDetails()
        {
            ShowRecommendedAges();
        }

        public override object Clone()
        {
            return new Book(Name, Kategory, Manufacter, Cost, Kol, IsDamaged, ExpirationDate,
                Author, Genre, Pages, (int[])AudienceAges.Clone());
        }
    }
}