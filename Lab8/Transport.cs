using System;

namespace Lab8
{
    public class Transport : Tovar
    {
        private string model;
        private string type;
        private int maxSpeed;
        private bool isElectric;

        public string Model
        {
            get { return model; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    model = value;
                else
                    model = "Неизвестно";
            }
        }

        public string Type
        {
            get { return type; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    type = value;
                else
                    type = "Общий";
            }
        }

        public int MaxSpeed
        {
            get { return maxSpeed; }
            set
            {
                if (value > 0 && value <= 400)
                    maxSpeed = value;
                else
                {
                    Console.WriteLine("Ошибка: недопустимая скорость");
                    maxSpeed = 50;
                }
            }
        }

        public bool IsElectric
        {
            get { return isElectric; }
            set { isElectric = value; }
        }

        public Transport(string name, string category, string manufacturer, double cost, int kol,
                         bool isDamaged, string expirationDate,
                         string model, string type, int maxSpeed, bool isElectric)
            : base(name, category, manufacturer, cost, kol, isDamaged, expirationDate)
        {
            Model = model;
            Type = type;
            MaxSpeed = maxSpeed;
            IsElectric = isElectric;
        }

        public override void TypeOfClass()
        {
            Console.WriteLine("Это транспортное средство");
        }

        public override double GetTotalPrice()
        {
            return Cost * Kol;
        }

        public void ShowTransportInfo()
        {
            Console.WriteLine($"Модель: {Model}, Тип: {Type}, Макс. скорость: {MaxSpeed} км/ч, Электрический: {(IsElectric ? "Да" : "Нет")}");
        }

        public override string ToString()
        {
            return base.ToString() +
                   $"\nМодель: {Model}\nТип: {Type}\nМакс. скорость: {MaxSpeed} км/ч\nЭлектрический: {(IsElectric ? "Да" : "Нет")}";
        }

        public override void ShowDetails()
        {
            ShowTransportInfo();
        }

        public override object Clone()
        {
            return new Transport(Name, Kategory, Manufacter, Cost, Kol, IsDamaged, ExpirationDate,
                Model, Type, MaxSpeed, IsElectric);
        }
    }
}