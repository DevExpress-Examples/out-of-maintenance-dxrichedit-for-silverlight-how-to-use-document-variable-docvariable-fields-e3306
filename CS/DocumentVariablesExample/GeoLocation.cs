using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Web;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using System.Globalization;
using DevExpress.Utils;
using System.Windows.Browser;
using System.Threading;
using System.Xml.Linq;
using System.Linq;
using DevExpress.Xpf.Collections;

namespace DocumentVariablesExample
{
    public class GeoLocation
    {
        static WebClient wbc;
        static List<GeoLocation> coordinates;

        private double _Latitude;
        public double Latitude
        {
            get { return _Latitude; }
            set
            {
                _Latitude = value;
            }
        }
        private double _Longitude;
        public double Longitude
        {
            get { return _Longitude; }
            set
            {
                _Longitude = value;
            }
        }
        private string _Address;
        public string Address
        {
            get { return _Address; }
            set
            {
                _Address = value;
            }
        }

        public GeoLocation(double latitude, double longitude, string address)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Address = address;
        }


        public static GeoLocation[] GeocodeAddress(string address, ArrayList _geolocationdata)
        {
            coordinates = new List<GeoLocation>();

            var query =
                    from GeoLocation location in _geolocationdata
                    where location.Address == address
                    select location;

            foreach (GeoLocation g in query)
                coordinates.Add(g);
            return coordinates.ToArray();
        }

    }
}
