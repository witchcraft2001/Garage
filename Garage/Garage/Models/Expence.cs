using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Models
{
    [Table("Expences")]
    public class Expence : BaseDataObject
    {
        DateTime added;
        public DateTime Added
        {
            get { return added; }
            set { SetProperty(ref added, value); }
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
