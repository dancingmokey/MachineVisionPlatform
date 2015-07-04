using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPS
{
    public class GPSFunctions
    {
        public static string ParseValue(string strValue)
        {
            //
            string strDestValue = null;

            //
            double dTempVal = Double.Parse(strValue);
            dTempVal /= 100.00d;

            //
            int nDegreeVal = (int)dTempVal;

            //
            double dRightVal = (dTempVal - nDegreeVal) * 60.0d;
            int nMinVal = (int)(dRightVal * 60);

            //
            dRightVal = (dRightVal - nMinVal) * 60.0d;
            double dSecVal = (int)(dRightVal * 60);

            //
            strDestValue = nDegreeVal.ToString() + nMinVal.ToString() + dSecVal.ToString();

            return strDestValue;
        }
    }
}
