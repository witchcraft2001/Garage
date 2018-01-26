using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Garage.Interfaces;
using Garage.Models;

namespace Garage.DB
{
    public class DbContext
    {
        private SQLiteConnection database;
        private static object collisionLock = new object();
        
        public DbContext()
        {
            database = DependencyService.Get<IDatabaseConnection>().DbConnection();
            database.CreateTable<Car>();
        }

        #region Cars
        public IEnumerable<Car> GetCars()
        {
            lock (collisionLock)
            {
                return new ObservableCollection<Car>(database.Table<Car>());
            }
        }

        public Car GetCar(int id)
        {
            lock (collisionLock)
            {
                return database.Table<Car>().FirstOrDefault(c => c.Id == id);
            }
        }

        public int SaveCar(Car carInstance)
        {
            lock (collisionLock)
            {
                if (carInstance.Id == 0)
                {
                    database.Insert(carInstance);
                }
                else
                {
                    carInstance.ChangedAt = DateTimeOffset.Now;
                    database.Update(carInstance);
                }
                return carInstance.Id;
            }
        }

        public int DeleteCar(int id)
        {
            if (id != 0)
            {
                lock (collisionLock)
                {
                    database.Delete<Car>(id);
                }
            }
            return id;
        }

        public int DeleteCar(Car carInstance)
        {
            var id = carInstance.Id;
            return DeleteCar(id);
        }
        #endregion
    }
}
