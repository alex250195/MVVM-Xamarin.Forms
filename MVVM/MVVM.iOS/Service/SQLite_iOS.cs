using MVVM.Service;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_iOS))]
namespace MVVM.Service
{
    public class SQLite_iOS : ISQLite
    {
        public SQLite_iOS() { }

        public SQLiteConnection GetConnectionSQL()
        {
            var sqliteFilename = "MobileDataBase.db3";

            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            string libraryPath = Path.Combine(documentsPath, ".. ", "Library");
            var path = Path.Combine(libraryPath, sqliteFilename);
            var conn = new SQLite.SQLiteConnection(path);

            return conn;
        }
    }
}
