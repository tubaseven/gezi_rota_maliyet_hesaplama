using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prolab11
{
    class Kodlar
    {
        public static int GetDistanceAsKM(double sLatitude, double sLongitude, double eLatitude, double eLongitude)
        {
            var sCoord = new GeoCoordinate(sLatitude, sLongitude);
            var eCoord = new GeoCoordinate(eLatitude, eLongitude);

            return (int)(sCoord.GetDistanceTo(eCoord) / 1000);
        }
    }
}
