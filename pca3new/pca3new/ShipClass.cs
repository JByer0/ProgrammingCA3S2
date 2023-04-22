using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pca3new
{
    public class shipfile
    {
        // properties for the different fields in the ship csv file
        public string PassengerFirstName { get; set; }
        public string PassengerSurname { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string DepartCountry { get; set; }
        public string Destination { get; set; }
        public string PassengerPort { get; set; }
        public string ManifestNum { get; set; }
        public string Date { get; set; }
        public string Occupation { get; set; }

        // constructor to initialize the object with the given field values
        public shipfile(string passengerSurname, string passengerFirstName, string age, string gender, string occupation, string departCountry, string destination, string passengerPort, string manifestNum, string date)
        {
            PassengerFirstName = passengerFirstName;
            PassengerSurname = passengerSurname;
            Age = age;
            Gender = gender;
            Occupation = occupation;
            DepartCountry = departCountry;
            Destination = destination;
            PassengerPort = passengerPort;
            ManifestNum = manifestNum;
            Date = date;
        }
    }
}
