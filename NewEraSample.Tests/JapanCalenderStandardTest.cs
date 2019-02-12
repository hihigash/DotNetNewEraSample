using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NewEraSample.Tests
{
    [TestClass]
    public class JapanCalenderStandardTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            void DisplayValues( Calendar myCal, DateTime myDT )  {
                Console.WriteLine( "   Era:        {0}", myCal.GetEra( myDT ) );
                Console.WriteLine( "   Year:       {0}", myCal.GetYear( myDT ) );
                Console.WriteLine( "   Month:      {0}", myCal.GetMonth( myDT ) );
                Console.WriteLine( "   DayOfYear:  {0}", myCal.GetDayOfYear( myDT ) );
                Console.WriteLine( "   DayOfMonth: {0}", myCal.GetDayOfMonth( myDT ) );
                Console.WriteLine( "   DayOfWeek:  {0}", myCal.GetDayOfWeek( myDT ) );
                Console.WriteLine();
            }

            DateTime targetDateTime = new DateTime( 2018, 4, 3, new GregorianCalendar());
            JapaneseCalendar calendar = new JapaneseCalendar();

            Console.WriteLine( "April 3, 2018 of the Gregorian calendar equals the following in the Japanese calendar:" );
            DisplayValues( calendar, targetDateTime );

            targetDateTime = calendar.AddYears( targetDateTime, 2 );
            targetDateTime = calendar.AddMonths( targetDateTime, 10 );

            Console.WriteLine( "After adding two years and ten months:" );
            DisplayValues( calendar, targetDateTime );
        }
    }
}
