using System;

namespace Lab8
{
    public class Toy : Tovar
    {
        private int[] agegroup;
        private string type;
        private float weight;

        public int[] Agegroup
        {
            get { return agegroup; }
            set
            {
                for (int i = 0; i < value.Length; i++)
                    if (value[i] < 0 || value[i] > 17)
                    {
                        Console.WriteLine("Ошибка: возраст вне диапазона");
                        agegroup = new int[] { 3 };
                        return;
                    }
                agegroup = value;
            }
        }

        public float Weight
        {
            get { return weight; }
            set
            {
                if (value > 0 && value <= 20)
                    weight = value;
                else
                {
                    Console.WriteLine("Ошибка: недопустимый вес");
                    weight = 3;
                }
            }
        }

        public Toy(string name, string kategory, string manufacter, double cost, int kol, bool IsDamaged, string ExpirationDate,
                   string type, float weight, int[] agegroup)
            : base(name, kategory, manufacter, cost, kol, IsDamaged, ExpirationDate)
        {
            this.type = type;
            Weight = weight;
            Agegroup = agegroup;
        }

        public override void TypeOfClass()
        {
            Console.WriteLine("Это игрушка");
        }

        public override double GetTotalPrice()
        {
            return Cost * Kol;
        }

        public void ShowAgeGroups()
        {
            Console.Write("Игрушка подходит для возрастов: ");
            Console.WriteLine(string.Join(", ", Agegroup));
        }

        public override string ToString()
        {
            return base.ToString() + $"\nТип: {type}\nВес: {Weight}\nВозраст: {string.Join(", ", Agegroup)}";
        }

        public override void ShowDetails()
        {
            ShowAgeGroups();
        }

        public override object Clone()
        {
            return new Toy(Name, Kategory, Manufacter, Cost, Kol, IsDamaged, ExpirationDate,
                type, Weight, (int[])Agegroup.Clone());
        }
    }
}