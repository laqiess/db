// @autor: Ключерев Артемий ИВТ-21.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Win32;

namespace bd
{
   
    public partial class MainWindow : Window
    {
        BaseData data;

        public MainWindow()
        {
            InitializeComponent();
            data = new BaseData();

            // связывание данных и табличного предствления (datagrid)
            datagrid.ItemsSource = data.data;
            // названия столбцов в datagrid определятся автоматически, 
            // на основе названий свойств элементов привезанной коллекции данных (Buyer)
        }



        private bool AddingCheck()
        {
            SolidColorBrush error_color = new SolidColorBrush();
            SolidColorBrush usual_color = new SolidColorBrush();

            ///цвет ошибочных полей 
            error_color.Color = Color.FromRgb(252, 187, 187);
            /////цвет полей обычный
            usual_color.Color = Colors.White;

            bool hasError = false;

            //проверка имени
            ChangeColor(TextBox_name,ref hasError);

            //проверка фамилии
            ChangeColor(TextBox_surname, ref hasError);

            //проверка товара
            ChangeColor(TextBox_product, ref hasError);
            
            if (TextBox_price.Text == "")
            {
                TextBox_price.Background = error_color;
                hasError = true;
                
            }
            // если нельзя преобразовать в double 
            else if (!double.TryParse(TextBox_price.Text, out double payment))
            {
                TextBox_price.Background = error_color;
                hasError = true;
            }
            // если значение меньше нуля 
            else if (double.Parse(TextBox_price.Text) < 0)
            {
                TextBox_price.Background = error_color;
                hasError = true;
            }
            else
            {
                TextBox_price.Background = usual_color;
            }

            return hasError;
        }


        private void ChangeColor(TextBox f1,ref bool has_error)
        {
            SolidColorBrush error_color = new SolidColorBrush();
            SolidColorBrush usual_color = new SolidColorBrush();

            ///цвет ошибочных полей 
            error_color.Color = Color.FromRgb(252, 187, 187);
            /////цвет полей обычный
            usual_color.Color = Colors.White;


            // если поле ввода имени пустое
            if (f1.Text == "")
            {
                f1.Background = error_color;
                has_error = true;
            }
            else
            {
                f1.Background = usual_color;
            }


        }



        // Добавляет новую строку в таблицу
        private void button_add_row_Click(object sender, RoutedEventArgs e)
        {

            if (AddingCheck() == false)
            {
                string name1 = TextBox_name.Text;
                string surname1 = TextBox_surname.Text;
                // Convert преобразует строковые данные
                string product1 = TextBox_product.Text;
                // ToDouble - к типу double
                double price1 = Convert.ToDouble(TextBox_price.Text);
                // если проверка прошла, добавить данные
                data.add_data(name1,surname1,product1,price1);
            }
        }




        // изменение полей ввода при выделении строчек
        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        // удаление выделенной строки
        private void Button_del_row_Click(object sender, RoutedEventArgs e)
        {

            // если пользователь не выбрал строку
            // SelectedIndex - индекс строки первого выделенного элемента
            // по умолчанию -1
            if (datagrid.SelectedIndex == -1)
            {
            }
            else
            {    
                int row = datagrid.SelectedIndex;
                // удаляем элемент из коллекции под данным индексом
                data.data.RemoveAt(row);
            }
        }

        // закрытие прогаммы при нажатии на пункт меню
        private void MenuItem_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // справка
        private void MenuItem_Reference_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Разработчик: Ключерев Артемий ИВТ-21");
        }

        // пункт меню SaveToFile
        // сохранить данные в csv файл
        private void MenuItem_SaveToFile_Click(object sender, RoutedEventArgs e)
        {
            // SaveFileDialog - диалоговое окно для выбора файла для сохранения
            SaveFileDialog sfd = new SaveFileDialog();
            // выбор типа файла
            sfd.Filter = "Comma-separated values file|*.csv*";
            // ShowDialog() == true, если пользователь выбрал файл и нажал "сохранить"
            if (sfd.ShowDialog() == true)
            {
                // сохранение данных в файл
                data.save_csv( sfd.FileName);
            }
        }

        // прочитать csv файл
        private void MenuItem_ReadFile_Click(object sender, RoutedEventArgs e)
        {
            // OpenFileDialog - диалоговое окно для выбора файла для открытия
            OpenFileDialog ofd = new OpenFileDialog();
            // ShowDialog() == true, если пользователь выбрал файл и нажал "открыть"
            if (ofd.ShowDialog() == true)
            {
                // если файл существует
                if (File.Exists(ofd.FileName))
                {
                    // прочитать файл
                    data.open_csv(ofd.FileName);
                }
            }
        }

        //удалить все
        private void Button_del_all_Click(object sender, RoutedEventArgs e)
        {
            data.data.Clear();
        }
    }
}

