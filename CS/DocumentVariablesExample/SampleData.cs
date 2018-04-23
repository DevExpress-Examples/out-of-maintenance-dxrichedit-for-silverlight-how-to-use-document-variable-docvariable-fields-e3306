using System;
using System.Text;
using DevExpress.Xpf.Collections;
using System.Collections.Generic;

namespace DocumentVariablesExample
{
    class SampleData : ArrayList
    {
        public SampleData()
        {
            Add(new AddresseeRecord("Maria", "Alfreds Futterkiste", "Obere Str. 57, Berlin", "Berlin"));
            Add(new AddresseeRecord("Laurence", "Bon app'", "12, rue des Bouchers, Marseille", "Marseille"));
            Add(new AddresseeRecord("Patricio", "Cactus Comidas para llevar", "Cerrito 333, Buenos Aires", "Buenos Aires"));
            Add(new AddresseeRecord("Thomas", "Around the Horn", "120 Hanover Sq., London", "London"));
            Add(new AddresseeRecord("Boris", "Express Developers", "Krasnoarmeiskiy prospect 25, Tula", "Tula"));
        }
    }

    public class AddresseeRecord
    {
        private string _Name;
        private string _Company;
        private string _Address;
        private string _City;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public string Company
        {
            get { return _Company; }
            set { _Company = value; }
        }
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

        public AddresseeRecord(string _Name, string _Company, string _Address, string _City)
        {
            this._Name = _Name;
            this._Company = _Company;
            this._Address = _Address;
            this._City = _City;
        }
    }

    class GeoLocationData : ArrayList {
        public GeoLocationData() {
            Add(new GeoLocation(51.5001524, -0.126236, "London"));
            Add(new GeoLocation(54.1444253, 37.4897691, "Tula"));
            Add(new GeoLocation(52.5234051, 13.4113999, "Berlin"));
            Add(new GeoLocation(43.1664080, 5.1136612, "Marseille"));
            Add(new GeoLocation(-34.6084175, -58.3731613, "Buenos Aires"));
        }
    }

    class ConditionsData : ArrayList {
        public ConditionsData() { 
            Add(new Conditions("London","Chance of Rain"));
            Add(new Conditions("Tula","Partly Cloudy"));
            Add(new Conditions("Berlin","Chance of Storm"));
            Add(new Conditions("Marseille", "Sunny"));
            Add(new Conditions("Buenos Aires","Overcast" ));
        }
    
    }
}
