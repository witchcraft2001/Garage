using System;
using System.IO;
using Garage.Interfaces;
using Garage.iOS.DB;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(IOSDatabaseConnection))]
namespace Garage.iOS.DB
{
    public class IOSDatabaseConnection : IDatabaseConnection
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "garage.db";
            string personalFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryFolder = Path.Combine(personalFolder, "..", "Library");
            var path = Path.Combine(libraryFolder, dbName);
            return new SQLiteConnection(path);
        }
    }
}