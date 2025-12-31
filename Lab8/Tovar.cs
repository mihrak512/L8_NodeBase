using System;

namespace Lab8
{
    public class Tovar : Item, IComparable, ICloneable
    {
        public string Name { get; set; }
        public string Kategory { get; set; }
        public string Manufacter { get; set; }
        protected double cost;
        protected int kol;
        public bool IsDamaged { get; set; }
        public string ExpirationDate { get; set; }

        public double Cost
        {
            get { return cost; }
            set
            {
                if (value > 0)
                    cost = value;
                else
                    Console.WriteLine("Ошибка: цена должна быть положительной");
            }
        }

        public int Kol
        {
            get { return kol; }
            set
            {
                if (value > 0)
                    kol = value;
                else
                    Console.WriteLine("Ошибка: количество должно быть положительным");
            }
        }

        public Tovar(string name, string kategory, string manufacter, double cost, int kol, bool IsDamaged, string ExpirationDate)
        {
            Name = name;
            Kategory = kategory;
            Manufacter = manufacter;
            Cost = cost;
            Kol = kol;
            this.IsDamaged = IsDamaged;
            this.ExpirationDate = ExpirationDate;
        }

        public Tovar() { }

        public override string ToString()
        {
            return "Имя: " + Name + Environment.NewLine +
                   "Категория: " + Kategory + Environment.NewLine +
                   "Производитель: " + Manufacter + Environment.NewLine +
                   "Цена: " + Cost + Environment.NewLine +
                   "Количество: " + Kol + Environment.NewLine +
                   "Повреждён: " + (IsDamaged ? "Да" : "Нет") + Environment.NewLine +
                   "Срок годности: " + ExpirationDate;
        }

        public override void TypeOfClass()
        {
            Console.WriteLine("Это товар");
        }

        public virtual double GetTotalPrice()
        {
            return Cost * Kol;
        }

        public virtual bool IsDiscounted()
        {
            return IsDamaged;
        }

        public virtual string DiscountReason()
        {
            if (IsDamaged && ExpirationDate == "Скоро истекает")
                return "Повреждён и срок годности истекает";

            if (IsDamaged)
                return "Повреждён при перевозке";

            if (ExpirationDate == "Скоро истекает")
                return "Срок годности истекает";

            return "Нет причины для уценки";
        }

        public virtual void ShowDetails()
        {
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            Tovar otherTovar = obj as Tovar;
            if (otherTovar != null)
            {
                return this.Cost.CompareTo(otherTovar.Cost);
            }

            Console.WriteLine("Ошибка: объект не является Tovar");
            return 0;
        }

        public virtual object Clone()
        {
            return new Tovar(Name, Kategory, Manufacter, Cost, Kol, IsDamaged, ExpirationDate);
        }
    }
}