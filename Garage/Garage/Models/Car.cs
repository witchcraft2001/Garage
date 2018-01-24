namespace Garage.Models
{
    public class Car : BaseDataObject
    {
        int id;
        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        string name = string.Empty;
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
        public string Vin
        {
            get { return vin; }
            set { SetProperty(ref vin, value); }
        }

        string description = string.Empty;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }
    }
}
