using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Models
{
    [Table("Fuelings")]
    public class Fueling : BaseDataObject
    {
        bool fullTank;
        public bool FullTank
        {
            get { return fullTank; }
            set { SetProperty(ref fullTank, value); }
        }

        DateTime added;
        public DateTime Added
        {
            get { return added; }
            set { SetProperty(ref added, value); }
        }

        double amount;
        public double Amount
        {
            get { return amount; }
            set { SetProperty(ref amount, value); }
        }

        double cost;
        public double Cost
        {
            get { return cost; }
            set { SetProperty(ref cost, value); }
        }

        long mileage;
        public long Mileage
        {
            get { return mileage; }
            set { SetProperty(ref mileage, value); }
        }

        string note = string.Empty;
        [MaxLength(128)]
        public string Note
        {
            get { return note; }
            set { SetProperty(ref note, value); }
        }
    }
}
