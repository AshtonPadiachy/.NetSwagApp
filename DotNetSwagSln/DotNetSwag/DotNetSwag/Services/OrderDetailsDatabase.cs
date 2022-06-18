using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DotNetSwag.Models;
using SQLite;


namespace DotNetSwag.Services
{
    public class OrderDetailsDatabase
    {
        static SQLiteConnection Database;


        public static OrderDetailsDatabase Instance
        {
            get
            {
                var instance = new OrderDetailsDatabase();
                CreateTableResult result = Database.CreateTable<OrderDetails>();
                return instance;
            }
        }

        public static class Constants
        {
            public const string DatabaseFilename = "DotNetSwagSQLite.db3";

            public const SQLiteOpenFlags Flags =
                // open the database in read/write mode
                SQLiteOpenFlags.ReadWrite |
                // create the database if it doesn't exist
                SQLiteOpenFlags.Create |
                // enable multi-threaded database access
                SQLiteOpenFlags.SharedCache;

            public static string DatabasePath
            {
                get
                {
                    var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    return Path.Combine(basePath, DatabaseFilename);
                }
            }
        }

        public OrderDetailsDatabase()
        {
            Database = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);

        }

        public List<OrderDetails> GetOrder()
        {
            return Database.Table<OrderDetails>().ToList();
        }

        public List<OrderDetails> GetNoOrder()
        {
            return Database.Query<OrderDetails>("SELECT * FROM [OrderDetails] WHERE [Done] = 0");
        }

        public OrderDetails GetOrder(int id)
        {
            return Database.Table<OrderDetails>().Where(i => i.ID == id).FirstOrDefault();
        }

        public int SaveOrder(OrderDetails detail)
        {
            if (detail.ID != 0)
            {
                return Database.Update(detail);
            }
            else
            {
                return Database.Insert(detail);
            }
        }

        public int DeleteOrder(OrderDetails detail)
        {
            return Database.Delete(detail);

        }
    }
}
