using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Models
{
    [Table("GasTypes")]
    public class GasType : BaseDataObject
    {
        string name = string.Empty;
        [MaxLength(32)]
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }
    }
}
