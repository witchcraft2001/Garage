using System.IO;
using Garage.Droid.DB;
using Garage.Interfaces;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidDatabaseConnection))]
namespace Garage.Droid.DB
{
    public class AndroidDatabaseConnection : IDatabaseConnection
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "garage.db";
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbName);
            return new SQLiteConnection(path);
        }
    }
}