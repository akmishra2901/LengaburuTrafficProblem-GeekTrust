using System;
using System.Collections.Generic;
using System.Text;
using geektrust.Vehicle;

namespace geektrust.Base
{
    public sealed class ObjectFactory
    {
        private static Car CarInstance = null;
        private static Bike BikeInstance = null;
        private static Tuktuk TukTukInstance = null;
        private ObjectFactory() { }
        public static Car GetCarInstance
        {
            get
            {
                if (CarInstance == null)
                    CarInstance = new Car();
                return CarInstance;
            }
        }
        public static Bike GetBikeInstance
        {
            get
            {
                if (BikeInstance == null)
                    BikeInstance = new Bike();
                return BikeInstance;
            }
        }
        public static Tuktuk GetTuktukInstance
        {
            get
            {
                if (TukTukInstance == null)
                    TukTukInstance = new Tuktuk();
                return TukTukInstance;
            }
        }
    }
}
