using System;
using System.Collections.Generic;
using System.Text;
using geektrust.Enums;

namespace geektrust.Utility
{
    public static class Utility
    {
        public static Tuple<VehicleTypeEnum, double> GetMinKeyValueFromDictionary(Dictionary<VehicleTypeEnum, double> keyValuePairs) {
            double value = double.MaxValue;
            VehicleTypeEnum retval = VehicleTypeEnum.NONE;
            foreach (KeyValuePair<VehicleTypeEnum, double> keyValuePair in keyValuePairs) {
                if (keyValuePair.Value < value) {
                    value = keyValuePair.Value;
                    retval = keyValuePair.Key;
                }
            }
            return new Tuple<VehicleTypeEnum, double>(retval, value);
        }
    }
}
