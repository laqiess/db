// @autor: Ключерев Артемий ИВТ-21.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bd
{

    // класс покупатель
    public class Buyer
    {
        private String name; // имя
        private String surname; // фамилия
        private String product; // товар
        private double price; // цена

        public Buyer()
        {
            name = "";
            surname = "";
            product = "";
            price = 0;
        }

        // конструктор    
        public Buyer(string name1, string surname1, string product1, double price1)
        {
            Name = name1;
            Surname = surname1;
            Product = product1;
            Price = price1;
        }

        public string Name
        {
            //пример свойства
            get { return name; }
            set
            {
                name = value;
                //Ключевое слово value ссылается на значение,
                //которое клиентский код пытается присвоить свойству или индексатору
            }
        }

        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
            }
        }
        public string Product
        {
            get { return product; }
            set
            {
                product = value;
            }
        }

        // геттер и сеттер стоимости оплаты
        public double Price
        {
            get { return price; }
            set
            {
                // значение не может быть отрицательным
                if (value < 0)
                {
                    throw new Exception("Price can't be negative");
                }
                else
                {
                    price = value;
                }

            }
        }

    }
}
