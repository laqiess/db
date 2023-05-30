// @autor: Ключерев Артемий ИВТ-21

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


        // Добавляет новую строку в таблицу
        private void button_add_row_Click(object sender, RoutedEventArgs e)
        {
            SolidColorBrush error_color = new SolidColorBrush();
            SolidColorBrush usual_color = new SolidColorBrush();

            ///цвет ошибочных полей 
            error_color.Color = Color.FromRgb(252, 187, 187);
            /////цвет полей обычный
            usual_color.Color = Colors.White;

            bool hasError = false;
            // если поле ввода имени пустое
            if (TextBox_name.Text == "")
            {
                TextBox_name.Background = error_color;
                hasError = true;
                return;
            }
            else
            {
                TextBox_name.Background = usual_color;
            }

            // если поле ввода фамилии пустое
            if (TextBox_surname.Text == "")
            {
                TextBox_surname.Background = error_color;
                hasError = true;
                return;
            }
            else
            {
                TextBox_surname.Background = usual_color;
            }


            if (TextBox_product.Text == "")
            {
                TextBox_product.Background = error_color;
                hasError = true;
                return;
            }
            else
            {
                TextBox_product.Background = usual_color;
            }


            if (TextBox_price.Text == "")
            {
                TextBox_price.Background = error_color;
                hasError = true;
                return;
            }
            else
            {
                TextBox_price.Background = usual_color;
            }

            // если в имени есть цифры
            if (Regex.IsMatch(TextBox_name.Text, @"[0-9]"))
            {
                TextBox_name.Background = error_color;
                hasError = true;
                return;
            }
            else
            {
                TextBox_name.Background = usual_color;
            }

            // если в фамилии есть цифры
            if (Regex.IsMatch(TextBox_surname.Text, @"[0-9]"))
            {
                TextBox_surname.Background = error_color;
                hasError = true;
                return;
            }
            else
            {
                TextBox_surname.Background = usual_color;
            }


            if (Regex.IsMatch(TextBox_product.Text, @"[0-9]"))
            {
                TextBox_product.Background = error_color;
                hasError = true;
                return;
            }
            else
            {
                TextBox_product.Background = usual_color;
            }


            if (Regex.IsMatch(TextBox_price.Text, @"[a-zA-Z]") || Regex.IsMatch(TextBox_price.Text, @"[а-яА-Я]"))
            {
                TextBox_price.Background = error_color;
                hasError = true;
                return;
            }
            else
            {
                TextBox_price.Background = usual_color;
            }

            // если проверка прошла, добавить данные
            data.add_data(TextBox_name.Text, TextBox_surname.Text, TextBox_product.Text, TextBox_price.Text);

        }

        // изменение полей ввода при выделении строчек
        private void datagrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        // удаление выделенной строки
        private void Button_del_row_Click(object sender, RoutedEventArgs e)
        {
            // в index записывается номер выделенной строки
            if (datagrid.SelectedIndex <= datagrid.Items.Count && datagrid.SelectedIndex >= 0)
            {
                // удаление строчки
                data.del_line(datagrid.SelectedIndex, datagrid.Items.Count);
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
                data.save_csv(datagrid.Items.Count, sfd.FileName);
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

