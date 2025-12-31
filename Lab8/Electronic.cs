using System;

namespace Lab8
{
    public class Electronic : Tovar
    {
        private string deviceType;
        private float powerConsumption;
        private int warrantyMonths;

        public string DeviceType
        {
            get { return deviceType; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    deviceType = value;
                else
                    deviceType = "Неизвестно";
            }
        }

        public float PowerConsumption
        {
            get { return powerConsumption; }
            set
            {
                if (value > 0 && value <= 500)
                    powerConsumption = value;
                else
                {
                    Console.WriteLine("Ошибка: недопустимое энергопотребление");
                    powerConsumption = 50;
                }
            }
        }

        public int WarrantyMonths
        {
            get { return warrantyMonths; }
            set
            {
                if (value >= 0 && value <= 60)
                    warrantyMonths = value;
                else
                {
                    Console.WriteLine("Ошибка: гарантия вне диапазона");
                    warrantyMonths = 12;
                }
            }
        }

        public Electronic(string name, string category, string manufacturer, double cost, int kol, bool IsDamaged, string ExpirationDate,
                          string deviceType, float powerConsumption, int warrantyMonths)
            : base(name, category, manufacturer, cost, kol, IsDamaged, ExpirationDate)
        {
            DeviceType = deviceType;
            PowerConsumption = powerConsumption;
            WarrantyMonths = warrantyMonths;
        }

        public override void TypeOfClass()
        {
            Console.WriteLine("Это электронное устройство");
        }

        public override double GetTotalPrice()
        {
            return Cost * Kol;
        }

        public void ShowBasicInfo()
        {
            Console.WriteLine($"Название: {Name}\nТип устройства: {DeviceType}\nЦена: {Cost}");
        }

        public override string ToString()
        {
            return base.ToString() + $"\nТип: {DeviceType}\nЭнергопотребление: {PowerConsumption} Вт\nГарантия: {WarrantyMonths} мес.";
        }

        public override void ShowDetails()
        {
            ShowBasicInfo();
        }

        public override object Clone()
        {
            return new Electronic(Name, Kategory, Manufacter, Cost, Kol, IsDamaged, ExpirationDate,
                DeviceType, PowerConsumption, WarrantyMonths);
        }
    }
}