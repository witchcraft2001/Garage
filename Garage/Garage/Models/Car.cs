using SQLite;

namespace Garage.Models
{
    [Table("Cars")]
    public class Car : BaseDataObject
    {
        string name = string.Empty;
        [NotNull]
        [MaxLength(32)]
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }
        
        int year;
        public int Year
        {
            get { return year; }
            set { SetProperty(ref year, value); }
        }

        string vin = string.Empty;

        [MaxLength(17)]
        public string Vin
        {
            get { return vin; }
            set { SetProperty(ref vin, value); }
        }

        string description = string.Empty;

        [MaxLength(128)]
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }
    }
}
