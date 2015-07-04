using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS
{
    public class GPSCtrl
    {
        /// <summary>
        /// 推荐最小定位信息
        /// </summary>
        private static GPRMCData _pRmcData = null;
        public GPRMCData RMCData { get { return _pRmcData; } }

        /// <summary>
        /// 定义错误字符串
        /// </summary>
        private string _strErrorMsg = null;
        public string ErrorMsg { get { return _strErrorMsg; } set { _strErrorMsg = value; } }

        /// <summary>
        /// 
        /// </summary>
        public GPSCtrl()
        {
        }

        public void CreateGPSCtrl()
        {
            _pRmcData = new GPRMCData();
            GPSComm.StartWorking(8234);
        }

        public void DestroyGPSCtrl()
        {
            GPSComm.StopWorking();
        }

        /// <summary>
        /// 
        /// </summary>
        ~GPSCtrl()
        {
            GPSComm.StopWorking();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pRecvData"></param>
        public static void AnalysisData(Byte[] pRecvData)
        {
            string strRecvData = System.Text.Encoding.ASCII.GetString(pRecvData);


            int nRmcStartIdx = strRecvData.IndexOf("$GPRMC");
            if (nRmcStartIdx < 0)
                return;

            int nRmcEndIdx = strRecvData.IndexOf("$", nRmcStartIdx + 1);
            if (nRmcEndIdx < 0)
                return;

            string strRMCData = strRecvData.Substring(nRmcStartIdx, nRmcEndIdx - nRmcStartIdx);
            Console.WriteLine("RMC Data = " + strRMCData);


            if (_pRmcData.AnalysisData(strRMCData) == true)
            {
                Console.WriteLine("Status : " + _pRmcData.Status.ToString());
                Console.WriteLine("Date Time : " + _pRmcData.UTCDate + " " + _pRmcData.UTCTime);
                Console.WriteLine("Latitude : " + _pRmcData.LatitudeDirection.ToString() + " " + _pRmcData.Latitude);
                Console.WriteLine("Logtitude : " + _pRmcData.LongitudeDirection.ToString() + " " + _pRmcData.Longitude);
                Console.WriteLine("Speed : " + _pRmcData.Speed.ToString() + " knot");
                Console.WriteLine("Position Angle : " + _pRmcData.PosAngle.ToString());
                Console.WriteLine("MagDeclination : " + _pRmcData.MagDirection.ToString() + " " + _pRmcData.MagDeclination.ToString());
            }



            Console.WriteLine(strRecvData);
            Console.WriteLine("\n");
        }




    }
}
