using Microsoft.Data.Sqlite;

namespace LibProject
{
    public class Invent
    {
        public static void AddInfo()
        {
            string firstName = File.ReadAllLines(@"Resource/Name.txt")[new Random().Next(0, File.ReadAllLines(@"Resource/Name.txt").Length)];
            string secondName = File.ReadAllLines(@"Resource/SecondName.txt")[new Random().Next(0, File.ReadAllLines(@"Resource/SecondName.txt").Length)];
            string thirdName = File.ReadAllLines(@"Resource/ThirdName.txt")[new Random().Next(0, File.ReadAllLines(@"Resource/ThirdName.txt").Length)];
            string department = File.ReadAllLines(@"Resource/Department.txt")[new Random().Next(0, File.ReadAllLines(@"Resource/Department.txt").Length)];
            string post = File.ReadAllLines(@"Resource/Post.txt")[new Random().Next(0, File.ReadAllLines(@"Resource/Post.txt").Length)];
            long inventNumber = new Random().NextInt64(93000000, 93999999);
            string item = File.ReadAllLines(@"Resource/Item.txt")[new Random().Next(0, File.ReadAllLines(@"Resource/Item.txt").Length)];


            using (var connection = new SqliteConnection("Data Source = Invent.db"))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = $"INSERT INTO Inventory (Name, SecondName, ThirdName, Department, Post, InventNumber, Item) VALUES ('{firstName}', '{secondName}', '{thirdName}', '{department}', '{post}', '{inventNumber}', '{item}')";
                command.ExecuteNonQuery();
            }
        }
    }
}