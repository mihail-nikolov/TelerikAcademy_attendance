using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Globalization;

namespace DayOfWeekServiceProvider
{
    public class DayOfWeekProvider : IDayOfWeekProviderService
    {

        public string GetDate(DateTime date)
        {
            var culture = new CultureInfo("bg-BG");
            return culture.DateTimeFormat.GetDayName(date.DayOfWeek).ToString();
        }
    }
}
