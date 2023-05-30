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
        private String price; // цена

        public Buyer()
        {
            name = "";
            surname = "";
            product = "";
            price = "";
        }

        // конструктор    
        public Buyer(string name1, string surname1, string product1, string price1)
        {
            name = name1;
            surname = surname1;
            product = product1;
            price = price1;
        }

        public void name_set(string name1)
        {
            name = name1;
        }

        public string name_get()
        {
            return name;
        }

        public void surname_set(string surname1)
        {
            surname = surname1;
        }

        public string surname_get()
        {
            return surname;
        }

        public void product_set(string phone1)
        {
            product = phone1;
        }

        public string product_get()
        {
            return product;
        }

        public void price_set(string email1)
        {
            price = email1;
        }

        public string price_get()
        {
            return price;
        }


        public string Name { get => name; set => name = value; }

        public string Surname { get => surname; set => surname = value; }

        public string Product { get => product; set => product = value; }

        public string Price { get => price; set => price = value; }


    }
}
