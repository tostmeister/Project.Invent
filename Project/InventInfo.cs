using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class InventInfo
    {
        public string name { get; set; }
        public string secondName { get; set; }
        public string thirdName { get; set; }
        public string department { get; set; }
        public string post { get; set; }
        public long inventNumber { get; set; }
        public string item { get; set; }
        public int rowid { get; set; }

        public InventInfo(string name, string secondName, string thirdName, string department, string post, int inventNumber, string item)
        {
            this.name = name;
            this.secondName = secondName;
            this.thirdName = thirdName;
            this.department = department;
            this.post = post;
            this.inventNumber = inventNumber;
            this.item = item;
        }

        public InventInfo(int rowid)
        {
            this.rowid = rowid;
        }

        public void ShowInventProf()
        {
            int val = 1;
            using (var connection = new SqliteConnection("Data Source= Invent.db"))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Inventory";

                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (val == rowid)
                            {
                                name = reader.GetValue(0).ToString();
                                secondName = reader.GetValue(1).ToString();
                                thirdName = reader.GetValue(2).ToString();
                                department = reader.GetValue(3).ToString();
                                post = reader.GetValue(4).ToString();
                                inventNumber = reader.GetInt64(5);
                                item = reader.GetValue(6).ToString();
                                new InventProf(name, secondName, thirdName, department, post, inventNumber, item, rowid).Show();
                                break;
                            }
                            else
                            {
                                val++;
                            }
                        }
                    }
                }
            }
        }
    }
}
