using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using Microsoft.Data.Sqlite;
using System.Reflection;
using System.Collections;
using LibProject;

namespace Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            Invent.AddInfo();
            InventListPanel.Children.Clear();
            ShowButtons();
        }

        private void ShowButtonClick(object sender, RoutedEventArgs e)
        {
            int id = 1;
            InventListPanel.Visibility = Visibility.Visible;
            Scroll.Visibility = Visibility.Visible;
            Show.Visibility = Visibility.Hidden;
            Add.Visibility = Visibility.Visible;
            Search.Visibility = Visibility.Visible;
            ShowButtons();
        }
        public void ShowInventProf(object sender, RoutedEventArgs e)
        {
            new InventInfo(int.Parse((sender as Button).Content.ToString().Split(" ")[0].Split(")")[0])).ShowInventProf();
            this.Close();
        }

        void ShowButtons()
        {
            using (var connection = new SqliteConnection("Data Source = Invent.db"))
            {
                int id=1;
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Inventory";
                command.ExecuteNonQueryAsync();

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string decomissValue = reader.GetValue(7).ToString();
                        string name = reader.GetValue(0).ToString();
                        string secondname = reader.GetValue(1).ToString();
                        string thirdname = reader.GetValue(2).ToString();
                        string department = reader.GetValue(3).ToString();
                        string post = reader.GetValue(4).ToString();
                        long inventNumber = reader.GetInt64(5);
                        string item = reader.GetValue(6).ToString();
                        Button Button = new Button();
                        if (decomissValue == "0")
                        {
                            Button.Width = 900;
                            Button.Height = 50;
                            Button.HorizontalContentAlignment = HorizontalAlignment.Left;

                            Button.Click += ShowInventProf;
                            Button.Content = $"{id}) ИН:{inventNumber} | Оборудование:{item}";
                            InventListPanel.Children.Add(Button);
                        }
                        else if (decomissValue == "1")
                        {
                            Button.Width = 900;
                            Button.Height = 50;
                            Button.HorizontalContentAlignment = HorizontalAlignment.Left;

                            Button.Click += ShowInventProf;
                            Button.Content = $"{id}) ИН:{inventNumber} | Оборудование:{item} | Списан";
                            InventListPanel.Children.Add(Button);
                        }

                        id++;
                    }
                }
            }
        }
        void StartSearch(object sender, RoutedEventArgs e)
        {
            InventListPanel.Children.Clear();
            ShowButtons();
            if (Search.Text=="")
            {
                InventListPanel.Children.Clear();
                ShowButtons();
            }
            else
            {
                int value = 0;
                foreach (var child in InventListPanel.Children.OfType<Button>().ToList())
                {
                    string text = child.ToString().Split(") ")[1].ToLower();
                    if (text.Contains(Search.Text.ToLower()))
                    {
                        value++;
                    }
                    else
                    {
                        InventListPanel.Children.RemoveAt(value);

                    }
                }
            }
        }
    }   
}
