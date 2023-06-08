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
        //Если вы просто добавляете, изменяете и удаляете данные из самой ObservableCollection,
        //вы делаете это в модели представления, где определена ObservableCollection.
        //ObservableCollection<T> находится в пространстве имен и сборке
        public ObservableCollection<Buyer> data;
        // ObservableCollection -- коллекция, которую можно использовать совместно с DataGrid
        // Эта коллекция можеть оповещать о своём изменении DataGrid
        // DataGrid, в свою очередь, автоматически поддерживает сортировки и т.п.

        public BaseData()
        {
            data = new ObservableCollection<Buyer>();
        }

        // метод для добавления данных
        //можно без него
        public void add_data(string name, string surname, string product, double price)
        {
            data.Add(new Buyer(name, surname, product, price));
        }


        // метод для чтения csv файла
        public void open_csv(string filename)
        {
            string path = filename;
            // TextFieldParser - класс, предоставляющий методы и свойства для 
            // анализа структурированных текстовых файлов
            //берет строчку,разделяет на поля
            using (TextFieldParser tfp = new TextFieldParser(filename))
            {
                //с помощью символа разделяет поля
                tfp.TextFieldType = FieldType.Delimited;
                // обозначим знак разделения
                tfp.SetDelimiters(",");
                //пока не конец данных делаем...
                while (!tfp.EndOfData)
                {
                    // делим первую строчку на поля, которые разделяюся запятой
                    string[] fields = tfp.ReadFields();
                    //добавляем данные
                    data.Add(new Buyer(fields[0], fields[1], fields[2], double.Parse( fields[3])));
                }
            }
        }



        // запись в csv файл
        public void save_csv(string filename)
        {
            int count = data.Count;
            // StringBuilder - изменяемая строка символов
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < count; ++i)
            {
                stringBuilder.AppendLine(data[i].Name + "," + data[i].Surname + "," + data[i].Product + "," + data[i].Price);
                // Encoding нужен для правильной записи символов
                File.WriteAllText(filename, stringBuilder.ToString(), Encoding.GetEncoding("utf-8"));
            }
        }

    }
}
