using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GPS
{
    public class GPSFunctions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strDate"></param>
        /// <param name="strTime"></param>
        /// <returns></returns>
        public static string ParseDateTime(string strDate, string strTime)
        {
            try
            {
                // 检查输入值
                if (strDate == string.Empty || strTime == string.Empty)
                    return null;

                // 取得日期时间值
                DateTime dtVal = DateTime.ParseExact(strDate + strTime, "ddMMyyHHmmss.ff", System.Globalization.CultureInfo.CurrentCulture);
                dtVal = dtVal.AddHours(8);
                
                // 转换为字符串
                string strDateTime = dtVal.ToString("yyyy-MM-dd HH:mm:ss");

                // 返回值
                return strDateTime;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public static double ParseSpeed(string strSpeed)
        {
            try
            {
                // 检查输入值
                if (strSpeed == string.Empty)
                    return Double.MinValue;

                // 取得速度值
                double dValue = Double.Parse(strSpeed);
                dValue *= 1.8d;

                // 返回值
                return dValue;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Double.MinValue;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="drValue"></param>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static string ParseLatitudeAndLongitude(string strDirection, string strValue)
        {
            try
            {
                // 检查输入值
                if (strDirection == string.Empty || strValue == string.Empty)
                    return null;

                // 取得经纬度值
                double dValue = Double.Parse(strValue);
                dValue /= 100.00d;

                // 取得经纬度-度
                int nDegreeVal = (int)dValue;

                // 取得经纬度-分
                double dMinuteVal = (dValue - nDegreeVal) * 60;
                int nMinuteVal = (int)dMinuteVal;

                // 取得经纬度-秒
                double dSecondVal = (dMinuteVal - nMinuteVal) * 60;

                // 转换为字符串
                string strDest = strDirection;
                strDest += " ";
                strDest += nDegreeVal.ToString();
                strDest += "°";
                strDest += nMinuteVal.ToString();
                strDest += "'";
                strDest += dSecondVal.ToString();

                // 返回值
                return strDest;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
