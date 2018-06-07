using MVVM.Model;
using MVVM.Service;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MVVM.DataBase
{
    public class MobileDataBase
    {
        protected SQLiteConnection database;


        public MobileDataBase()
        {
            database = DependencyService.Get<ISQLite>().GetConnectionSQL();
            CreateAllTables();
        }

        public void CreateAllTables()
        {
            database.CreateTable<Usuario>();
            database.CreateTable<Cliente>();
            database.CreateTable<Produto>();
            database.CreateTable<Pedido>();
        }

        public SQLiteCommand CreateCommand(string cmdText, params object[] ps)
        {
            return database.CreateCommand(cmdText, ps);
        }

        public void Commit()
        {
            database.Commit();
        }

        public IEnumerable<T> GetAll<T>() where T : class, new()
        {
            return (from i in database.Table<T>()
                    select i).ToList();
        }

        public IEnumerable<T> GetBySpcification<T>(Func<T, bool> predicate) where T : class, new()
        {
            return database.Table<T>().Where(predicate);
        }

        public T GetFirstBySpcification<T>(Func<T, bool> predicate) where T : class, new()
        {
            return database.Table<T>().FirstOrDefault(predicate);
        }

        public void Update<T>(T item) where T : class
        {
            database.Update(item);
        }

        public void Insert<T>(T item) where T : class
        {
            database.Insert(item);
        }

        public void Delete<T>(T item) where T : class, new()
        {
            database.Delete<T>(item);
        }

        public int Delete<T>(int id) where T : class, new()
        {
            return database.Delete<T>(id);
        }

        public int Execute(string query, params object[] args)
        {
            return database.Execute(query, args);
        }

        public bool TableExists(string table)
        {
            var command = database.CreateCommand("SELECT name FROM sqlite_master WHERE type='table' AND name='" + table + "'");
            var result = command.ExecuteScalar<string>();

            if ((result != null) && (result.Trim().Length > 0))
                return true;
            else
                return false;
        }
    }
}
