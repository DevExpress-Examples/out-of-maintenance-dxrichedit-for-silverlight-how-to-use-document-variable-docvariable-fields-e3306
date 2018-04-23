using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Net;
using System.Web;
using DevExpress.Utils;
using System.Windows.Browser;
using DevExpress.Xpf.Collections;

namespace DocumentVariablesExample
{
    class Weather
    {

        public static Conditions GetCurrentConditions(string _city, ArrayList _conditionsdata)
        {
            List<Conditions> weather_conditions = new List<Conditions>();

            var query =
                    from Conditions conds in _conditionsdata
                    where conds.City == _city
                    select conds;

            foreach (Conditions c in query)
                weather_conditions.Add(c);

            return weather_conditions[0];
        }

  
    }
    public class Conditions
    {
        string city = "No Data";
        string dayOfWeek = DateTime.Now.DayOfWeek.ToString();
        string condition = "No Data";

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public string Condition
        {
            get { return condition; }
            set { condition = value; }
        }

        public Conditions(string city, string condition) {
            this.City = city;
            this.Condition = condition;
        }
    }
}
