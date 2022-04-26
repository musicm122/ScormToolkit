using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Manager
{
    public static class DbCore
    {
        public static string DbFile
        {
            get { return Environment.CurrentDirectory + "\\SimpleDb.sqlite"; }
        }

        public static SQLiteConnection DbConnection()
        {
            var conn = new SQLiteConnection("Data Source=" + DbFile);
            return conn;
        }

        //public Customer GetCustomer(long id)
        //{
        //    if (!File.Exists(DbFile)) return null;

        //    using (var cnn = SimpleDbConnection())
        //    {
        //        cnn.Open();
        //        Customer result = cnn.Query<Customer>(
        //            @"SELECT Id, FirstName, LastName, DateOfBirth
        //            FROM Customer
        //            WHERE Id = @id", new { id }).FirstOrDefault();
        //        return result;
        //    }
        //}

        //public void SaveCustomer(Customer customer)
        //{
        //    if (!File.Exists(DbFile))
        //    {
        //        CreateDatabase();
        //    }

        //    using (var cnn = SimpleDbConnection())
        //    {
        //        cnn.Open();
        //        customer.Id = cnn.Query<long>(
        //            @"INSERT INTO Customer 
        //            ( FirstName, LastName, DateOfBirth ) VALUES 
        //            ( @FirstName, @LastName, @DateOfBirth );
        //            select last_insert_rowid()", customer).First();
        //    }
        //}

        //private static void CreateDatabase()
        //{
        //    using (var cnn = DbConnection())
        //    {

        //    }
        //}
    }
}
