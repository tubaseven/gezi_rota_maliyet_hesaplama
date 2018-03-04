using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            TestObject t1 = new TestObject() { value = 5 };
            TestObject t2 = t1;

            t2 = null;
            Console.WriteLine(t1.value);

            //Console.WriteLine( GetDistanceAsKM(40.76694, 29.91694, 37.76441, 38.27629));
            Console.Read();
        }

        private static int GetDistanceAsKM(double sLatitude, double sLongitude, double eLatitude, double eLongitude)
        {
            var sCoord = new GeoCoordinate(sLatitude, sLongitude);
            var eCoord = new GeoCoordinate(eLatitude, eLongitude);

            return (int)(sCoord.GetDistanceTo(eCoord) / 1000);
        }

    }

    public class TestObject
    {
        public int value { get; set; }
    }
}
