using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYHDemo
{
    internal class SensorData
    {
        public SensorData(int hastighet, int bränsle, int motorvärme, int rpm, double lat, double lon, string felkod)
        {
            Hastighet = hastighet;
            Bränsle = bränsle;
            Motorvärme = motorvärme;
            RPM = rpm;
            Latitude = lat;
            Longitude = lon;
            Felkod = felkod;
        }

        public int RPM { get; set; }
        public int Hastighet { get; set; }
        public int Bränsle { get; set; }
        public int Motorvärme { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Felkod { get; set; }
    }
}
