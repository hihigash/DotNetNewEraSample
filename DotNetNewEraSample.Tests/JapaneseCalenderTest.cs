using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotNetNewEraSample.Tests
{
    [TestClass]
    public class JapaneseCalenderTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var cultureInfo = new CultureInfo("ja-JP")
            {
                DateTimeFormat = {Calendar = new JapaneseCalendar()}
            };

            var formattedString = "平成32年2月1日 0:00:00";
            var dateTime = DateTime.Parse(formattedString, cultureInfo);

            var roundTrippedString = dateTime.ToString("gg", cultureInfo);
            if (roundTrippedString.IndexOf("平成") < 0)
            {
                Console.WriteLine("Detected failure in round tripping ");
            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            var calendar = new JapaneseCalendar();
            var dateTime = calendar.ToDateTime(65, 1, 9, 15, 0, 0, 0, 3);
            Console.WriteLine(dateTime);

            // The output from the example includes the following:
            // Unhandled Exception: System.ArgumentOutOfRangeException:
            //    Valid values are between 1 and 64, inclusive.
            //    Parameter name: year
        }

        [TestMethod]
        public void TestMethod3()
        {
            var calendar = new JapaneseCalendar();
            var cultureInfo = new CultureInfo("ja-JP");
            cultureInfo.DateTimeFormat.Calendar = calendar;

            var dateTime = calendar.ToDateTime(31, 8, 18, 0, 0, 0, 0, 4);
            Console.WriteLine($"{dateTime:d}");

            CultureInfo.CurrentCulture = cultureInfo;
            Console.WriteLine($"{dateTime:g yyyy-MM-dd}");
            // The example displays the following output:
            //      8/18/2019
            //      ?? 01-08-18
        }

        [TestMethod]
        public void TestMethod4()
        {
            var dateTime = new DateTime(1989, 8, 18);
            var calendar = new JapaneseCalendar();
            var cultureInfo = new CultureInfo("ja-JP");
            cultureInfo.DateTimeFormat.Calendar = calendar;
            CultureInfo.CurrentCulture = cultureInfo;

            Console.WriteLine($"{dateTime:ggy年M月d日}");
            Console.WriteLine($"{dateTime:ggy'年'M'月'd'日'}");

            // If run under a .NET implementation that does not support Gannen:
            //    平成1年8月18日
            //    平成1年8月18日
            // If run under a .NET implementation that supports Gannen:
            //    平成元年8月18日
            //    平成元年8月18日
        }

        [TestMethod]
        public void TestMethod5()
        {
            var cal = new JapaneseCalendar();
            var dat = cal.ToDateTime(2, 1, 2, 0, 0, 0, 0);
            Console.WriteLine($"{dat:s}");
            dat = new DateTime(2, 1, 2, cal);
            Console.WriteLine($"{dat:s}");

            // Output with the Heisei era current:
            //      1990-01-02T00:00:00
            //      1990-01-02T00:00:00
            // Output with the new era current:
            //      2020-01-02T00:00:00
            //      2020-01-02T00:00:00
        }

        [TestMethod]
        public void TestMethod6()
        {
            var cal = new JapaneseCalendar();
            foreach (var era in cal.Eras)
            {
                Console.WriteLine($"{cal.ToDateTime(2, 1, 2, 0, 0, 0, 0, era):s}");
            }
        }
    }
}
