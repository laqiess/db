// @autor: Ключерев Артемий ИВТ-21.


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;// для ObservableCollection
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.FileIO;
using System.IO;



namespace bd
{

    // класс для хранения данных и работы с ними
    class BaseData
    {
        public ObservableCollection<Buyer> data;
        // ObservableCollection -- коллекция, которую можно использовать совместно с DataGrid
        // Эта коллекция можеть оповещать о своём изменении DataGrid
        // DataGrid, в свою очередь, автоматически поддерживает сортировки и т.п.

        public BaseData()
        {
            data = new ObservableCollection<Buyer>();
        }

        // метод для добавления данных
        public void add_data(string name, string surname, string product, string price)
        {
            data.Add(new Buyer(name, surname, product, price));
        }

        // метод для чтения csv файла
        public void open_csv(string filename)
        {
            string path = filename;

            using (TextFieldParser tfp = new TextFieldParser(filename))
            {
                tfp.TextFieldType = FieldType.Delimited;
                // обозначим знак разделения
                tfp.SetDelimiters(",");

                while (!tfp.EndOfData)
                {
                    // делим первую строчку на поля, которые разделяюся запятой
                    string[] fields = tfp.ReadFields();
                    data.Add(new Buyer(fields[0], fields[1], fields[2], fields[3]));
                }
            }
        }

        // запись в csv файл
        public void save_csv(int count, string filename)
        {
            string path = filename;

            int n = count;

            StringBuilder scv = new StringBuilder();
            for (int i = 0; i < n; ++i)
            {
                scv.AppendLine(data[i].Name + "," + data[i].Surname + "," + data[i].Product + "," + data[i].Price);
                // Encoding нужен для правильной записи символов
                File.WriteAllText(path, scv.ToString(), Encoding.GetEncoding("utf-8"));
            }
        }

        // метод для удаления выделенной строки
        public void del_line(int SelInd, int count)
        {
            // в index записывается номер выделенной строки
            data.RemoveAt(SelInd);
        }
    }
}
