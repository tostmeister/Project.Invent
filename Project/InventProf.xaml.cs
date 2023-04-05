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
using System.Windows.Shapes;
using Microsoft.Data.Sqlite;

namespace Project
{
    /// <summary>
    /// Логика взаимодействия для InventProf.xaml
    /// </summary>
    public partial class InventProf : Window
    {
        private bool isEditMode = true;
        public int Rowid { get; set; }

        public InventProf()
        {
            InitializeComponent();
        }

        public InventProf(string name, string secondName, string thirdName, string department, string post, long inventNumber, string item, int rowid)
        {
            InitializeComponent();
            ProfInventNumber.Text = inventNumber.ToString();
            Profitem.Text = item;
            ProfName.Text = name;
            ProfSecondName.Text = secondName;
            ProfThirdName.Text = thirdName;
            ProfDepartment.Text = department;
            ProfPost.Text = post;
            Rowid = rowid;
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            if (isEditMode == true)
            {
                ProfInventNumber.IsReadOnly = false;
                Profitem.IsReadOnly = false;
                ProfName.IsReadOnly = false;
                ProfSecondName.IsReadOnly = false;
                ProfThirdName.IsReadOnly = false;
                ProfDepartment.IsReadOnly = false;
                ProfPost.IsReadOnly = false;
                MessageBox.Show("Вы можете редактировать информацию!");

                ProfInventNumber.Cursor = Cursors.IBeam;
                Profitem.Cursor = Cursors.IBeam;
                ProfName.Cursor = Cursors.IBeam;
                ProfSecondName.Cursor = Cursors.IBeam;
                ProfThirdName.Cursor = Cursors.IBeam;
                ProfDepartment.Cursor = Cursors.IBeam;
                ProfPost.Cursor = Cursors.IBeam;
                isEditMode = false;
            }
            else
            {
                ProfInventNumber.IsReadOnly = true;
                Profitem.IsReadOnly = true;
                ProfName.IsReadOnly = true;
                ProfSecondName.IsReadOnly = true;
                ProfThirdName.IsReadOnly = true;
                ProfDepartment.IsReadOnly = true;
                ProfPost.IsReadOnly = true;
                MessageBox.Show("Вы отредактировали информацию!");

                ProfInventNumber.Cursor = Cursors.Arrow;
                Profitem.Cursor = Cursors.Arrow;
                ProfName.Cursor = Cursors.Arrow;
                ProfSecondName.Cursor = Cursors.Arrow;
                ProfThirdName.Cursor = Cursors.Arrow;
                ProfDepartment.Cursor = Cursors.Arrow;
                ProfPost.Cursor = Cursors.Arrow;
                isEditMode = false;
            }

            using (SqliteConnection connection = new SqliteConnection("Data Source=Invent.db"))
            {
                connection.OpenAsync();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = $"UPDATE Inventory SET InventNumber='{ProfInventNumber.Text}', Item='{Profitem.Text}', Name='{ProfName.Text}', SecondName='{ProfSecondName.Text}', ThirdName='{ProfThirdName.Text}', Department='{ProfDepartment.Text}', Post='{ProfPost.Text}' WHERE rowid={Rowid}";
                command.ExecuteNonQuery();
            }
        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            using (SqliteConnection connection = new SqliteConnection("Data Source=Invent.db"))
            {
                connection.OpenAsync();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "VACUUM";
                command.ExecuteNonQuery();
                command.CommandText = $"DELETE FROM Inventory WHERE rowid='{Rowid}'";
                command.ExecuteNonQuery();
                MessageBox.Show("Вы удалили профиль оборудования!");
            }
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        private void WriteOffButtonClick(object sender, RoutedEventArgs e)
        {
            using(SqliteConnection connection = new SqliteConnection("Data Source = Invent.db"))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Inventory";
                command.ExecuteNonQuery();
                command.CommandText = $"UPDATE Inventory SET DecommissionedValue='1' WHERE rowid={Rowid}";
                command.ExecuteNonQuery();
                WriteOff.Visibility = Visibility.Hidden;
                MessageBox.Show("Оборудование списано!");
            }
        }
    }
}
