using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS
{
    /// <summary>
    /// 定义公共枚举变量：方向(东、南、西、北)
    /// </summary>
    public enum Direction
    {
        North = 0x01,
        South,
        West,
        East,
        Unknown
    }

    /// <summary>
    /// 定义公共枚举变量：GPS状态(0=未定位，1=非差分定位，2=差分定位，3=无效PPS，6=正在估算)
    /// </summary>
    public enum GpsStatus
    {
        UnPosition = 0x00,
        Non_DiffPosition = 0x01,
        DiffPosition = 0x02,
        InvalidPosition = 0x03,
        CalcPosition = 0x06,
    }

    /// <summary>
    /// 定义公共枚举变量：定位模式(A=自动手动2D/3D，M=手动2D/3D)
    /// </summary>
    public enum PositionMode
    {
        Auto = 0x00,
        Manual = 0x01,
    }

    /// <summary>
    /// 定义公共枚举变量：定位类型(1=未定位，2=2D定位，3=3D定位)
    /// </summary>
    public enum PositionType
    {
        UnPosition = 0x01,
        D2Position = 0x02,
        D3Position = 0x03,
    }

    public class GPSData
    {
    }

    /// <summary>
    /// 全球定位数据(Global )
    /// </summary>
    public class GPGGAData
    {
        /// <summary>
        /// 定义原始数据
        /// </summary>
        private string _strOrgData = null;
        public string OrgData { get { return _strOrgData; } set { _strOrgData = value; } }

        /// <summary>
        /// 定义UTC时间，格式为 hhmmss.sss
        /// </summary>
        private string _strUTCTime = null;
        public string UTCTime { get { return _strUTCTime; } set { _strUTCTime = value; } }

        /// <summary>
        /// 定义纬度，格式为 ddmm.mmmm
        /// </summary>
        private string _strLatitude = null;
        public string Latitude { get { return _strLatitude; } set { _strLatitude = value; } }

        /// <summary>
        /// 定义纬度方向，N（北纬）/ S（南纬）
        /// </summary>
        private Direction _drLatitude = Direction.Unknown;
        public Direction LatitudeDirection { get { return _drLatitude; } set { _drLatitude = value; } }

        /// <summary>
        /// 定义经度，格式为 ddmm.mmmm
        /// </summary>
        private string _strLongitude = null;
        public string Longitude { get { return _strLongitude; } set { _strLongitude = value; } }

        /// <summary>
        /// 定义经度方向，E（东经）/ W（西经）
        /// </summary>
        private Direction _drLongitude = Direction.Unknown;
        public Direction LongitudeDirection { get { return _drLongitude; } set { _drLongitude = value; } }

        /// <summary>
        /// 定义GPS状态，0（未定位）/ 1（非差分定位）/ 2（差分定位）/ 3（无效PPS）/ 6（正在估算）
        /// </summary>
        private GpsStatus _gsStatus = GpsStatus.UnPosition;
        public GpsStatus Status { get { return _gsStatus; } set { _gsStatus = value; } }

        /// <summary>
        /// 定义卫星数量，0-12
        /// </summary>
        private int _nSatelliteCnt = 0;
        public int SatelliteCnt { get { return _nSatelliteCnt; } set { _nSatelliteCnt = value; } }

        /// <summary>
        /// 定义HDOP水平精度因子，0.5 - 99.9
        /// </summary>
        private double _dHDOPFactor = 0.0d;
        public double HDOPFactor { get { return _dHDOPFactor; } set { _dHDOPFactor = value; } }

        /// <summary>
        /// 定义海拔高度，-9999.9 - 99999.9
        /// </summary>
        private double _dElevation = 0.0d;
        public double Elevation { get { return _dElevation; } set { _dElevation = value; } }

        /// <summary>
        /// 定义地球椭球面相对大地水准面的高度
        /// </summary>
        private double _dHeight = 0.0d;
        public double Height { get { return _dHeight; } set { _dHeight = value; } }

        /// <summary>
        /// 定义差分时间
        /// </summary>
        private int _nDiffTime = 0;
        public int DiffTime { get { return _nDiffTime; } set { _nDiffTime = value; } }

        /// <summary>
        /// 定义差分站ID号
        /// </summary>
        private string _strDiffStationID = null;
        public string DiffStationID { get { return _strDiffStationID; } set { _strDiffStationID = value; } }

        /// <summary>
        /// 定义校验值
        /// </summary>
        private string _strVerify = null;
        public string Verify { get { return _strVerify; } set { _strVerify = value; } }

    }

    /// <summary>
    /// 当前卫星信息(GPS DOP and Active Satellites（GSA）)
    /// </summary>
    public class GPGSAData
    {
        /// <summary>
        /// 定义原始数据
        /// </summary>
        private string _strOrgData = null;
        public string OrgData { get { return _strOrgData; } set { _strOrgData = value; } }

        /// <summary>
        /// 定义定位模式，A（自动手动2D/3D） / M（手动2D/3D）
        /// </summary>
        private PositionMode _pmMode = PositionMode.Auto;
        public PositionMode Mode { get { return _pmMode; } set { _pmMode = value; } }

        /// <summary>
        /// 定义定位类型，1（未定位） / 2（2D定位） / 3（3D定位）
        /// </summary>
        private PositionType _ptType = PositionType.UnPosition;
        public PositionType Type { get { return _ptType; } set { _ptType = value; } }

        /// <summary>
        /// 定义PRN码（伪随机噪声码）
        /// </summary>
        private string _strPRNCodeCH1 = null;
        private string _strPRNCodeCH2 = null;
        private string _strPRNCodeCH3 = null;
        private string _strPRNCodeCH4 = null;
        private string _strPRNCodeCH5 = null;
        private string _strPRNCodeCH6 = null;
        private string _strPRNCodeCH7 = null;
        private string _strPRNCodeCH8 = null;
        private string _strPRNCodeCH9 = null;
        private string _strPRNCodeCH10 = null;
        private string _strPRNCodeCH11 = null;
        private string _strPRNCodeCH12 = null;
        public string PRNCodeCH1 { get { return _strPRNCodeCH1; } set { _strPRNCodeCH1 = value; } }
        public string PRNCodeCH2 { get { return _strPRNCodeCH2; } set { _strPRNCodeCH2 = value; } }
        public string PRNCodeCH3 { get { return _strPRNCodeCH3; } set { _strPRNCodeCH3 = value; } }
        public string PRNCodeCH4 { get { return _strPRNCodeCH4; } set { _strPRNCodeCH4 = value; } }
        public string PRNCodeCH5 { get { return _strPRNCodeCH5; } set { _strPRNCodeCH5 = value; } }
        public string PRNCodeCH6 { get { return _strPRNCodeCH6; } set { _strPRNCodeCH6 = value; } }
        public string PRNCodeCH7 { get { return _strPRNCodeCH7; } set { _strPRNCodeCH7 = value; } }
        public string PRNCodeCH8 { get { return _strPRNCodeCH8; } set { _strPRNCodeCH8 = value; } }
        public string PRNCodeCH9 { get { return _strPRNCodeCH9; } set { _strPRNCodeCH9 = value; } }
        public string PRNCodeCH10 { get { return _strPRNCodeCH10; } set { _strPRNCodeCH10 = value; } }
        public string PRNCodeCH11 { get { return _strPRNCodeCH11; } set { _strPRNCodeCH11 = value; } }
        public string PRNCodeCH12 { get { return _strPRNCodeCH12; } set { _strPRNCodeCH12 = value; } }

        /// <summary>
        /// 定义PDOP综合位置精度因子，0.5 - 99.9
        /// </summary>
        private double _dPDOPFactor = 0.0d;
        public double PDOPFactor { get { return _dPDOPFactor; } set { _dPDOPFactor = value; } }

        /// <summary>
        /// 定义HDOP水平精度因子，0.5 - 99.9
        /// </summary>
        private double _dHDOPFactor = 0.0d;
        public double HDOPFactor { get { return _dHDOPFactor; } set { _dHDOPFactor = value; } }

        /// <summary>
        /// 定义VDOP垂直精度因子，0.5 - 99.9
        /// </summary>
        private double _dVDOPFactor = 0.0d;
        public double VDOPFactor { get { return _dVDOPFactor; } set { _dVDOPFactor = value; } }

        /// <summary>
        /// 定义校验值
        /// </summary>
        private string _strVerify = null;
        public string Verify { get { return _strVerify; } set { _strVerify = value; } }
    }

    /// <summary>
    /// 推荐最小定位信息(Recommended Minimum Specific GPS/TRANSIT Data（RMC）)
    /// </summary>
    public class GPRMCData
    {
        /// <summary>
        /// 定义原始数据
        /// </summary>
        private string _strOrgData = null;
        public string OrgData { get { return _strOrgData; } set { _strOrgData = value; } }

        /// <summary>
        /// 定义错误字符串
        /// </summary>
        private string _strErrorMsg = null;
        public string ErrorMsg { get { return _strErrorMsg; } set { _strErrorMsg = value; } }

        /// <summary>
        /// 定义UTC时间，格式为 hhmmss.sss
        /// </summary>
        private string _strUTCTime = null;
        public string UTCTime { get { return _strUTCTime; } set { _strUTCTime = value; } }

        /// <summary>
        /// 定义GPS状态，0（未定位）/ 1（非差分定位）/ 2（差分定位）/ 3（无效PPS）/ 6（正在估算）
        /// </summary>
        private GpsStatus _gsStatus = GpsStatus.UnPosition;
        public GpsStatus Status { get { return _gsStatus; } set { _gsStatus = value; } }

        /// <summary>
        /// 定义纬度，格式为 ddmm.mmmm
        /// </summary>
        private string _strLatitude = null;
        public string Latitude { get { return _strLatitude; } set { _strLatitude = value; } }

        /// <summary>
        /// 定义纬度方向，N（北纬）/ S（南纬）
        /// </summary>
        private Direction _drLatitude = Direction.Unknown;
        public Direction LatitudeDirection { get { return _drLatitude; } set { _drLatitude = value; } }

        /// <summary>
        /// 定义经度，格式为 ddmm.mmmm
        /// </summary>
        private string _strLongitude = null;
        public string Longitude { get { return _strLongitude; } set { _strLongitude = value; } }

        /// <summary>
        /// 定义速度，节
        /// </summary>
        private Direction _drLongitude = Direction.Unknown;
        public Direction LongitudeDirection { get { return _drLongitude; } set { _drLongitude = value; } }

        /// <summary>
        /// 定义经度方向，E（东经）/ W（西经）
        /// </summary>
        private double _dSpeed = 0;
        public double Speed { get { return _dSpeed; } set { _dSpeed = value; } }

        /// <summary>
        /// 定义方位角，度
        /// </summary>
        private int _nPosAngle = 0;
        public int PosAngle { get { return _nPosAngle; } set { _nPosAngle = value; } }

        /// <summary>
        /// 定义UTC日期，格式为 DDMMYY
        /// </summary>
        private string _strUTCDate = null;
        public string UTCDate { get { return _strUTCDate; } set { _strUTCDate = value; } }

        /// <summary>
        /// 定义磁偏角，（0-180°）
        /// </summary>
        private int _nMagDeclination = 0;
        public int MagDeclination { get { return _nMagDeclination; } set { _nMagDeclination = value; } }

        /// <summary>
        /// 定义磁偏角，（0-180°）
        /// </summary>
        private Direction _drMagDeclination = Direction.Unknown;
        public Direction MagDirection { get { return _drMagDeclination; } set { _drMagDeclination = value; } }

        /// <summary>
        /// 定义校验值
        /// </summary>
        private string _strVerify = null;
        public string Verify { get { return _strVerify; } set { _strVerify = value; } }

        public Boolean AnalysisData(string strOrgData)
        {
            // 检查数据长度
            if (strOrgData == string.Empty)
            {
                _strErrorMsg = "RMC信息为空值";
                return false;
            }

            // 检查数据头
            if ((strOrgData.StartsWith("$GPRMC") == false) &&
                (strOrgData.StartsWith("GPRMC") == false))
            {
                _strErrorMsg = "RMC信息头错误";
                return false;
            }

            // 拆分信息
            string[] strMsgItems = strOrgData.Split(',');
            if (strMsgItems.Length != 13)
            {
                _strErrorMsg = "RMC信息条目错误";
                return false;
            }

            // 判断是否定位
            if (strMsgItems[2] == "V")
            {
                _strErrorMsg = "GPS未定位";
                return false;
            }

            // 解析消息
            try
            {
                // 解析日期及时间
                _strUTCTime = strMsgItems[1];
                _strUTCDate = strMsgItems[9];

                // 解析GPS状态
                _gsStatus = GpsStatus.Non_DiffPosition;

                // 解析经度
                _strLongitude = strMsgItems[5];
                _drLongitude = ((strMsgItems[6] == "E") ? Direction.East : Direction.West);

                // 解析纬度
                _strLatitude = strMsgItems[3];
                _drLatitude = ((strMsgItems[4] == "N") ? Direction.North : Direction.South);

                // 解析速度
                _dSpeed = Double.Parse((strMsgItems[7] == "") ? "0" : strMsgItems[7]);

                // 解析定位角
                _nPosAngle = Int32.Parse((strMsgItems[8] == "") ? "0" : strMsgItems[8]);

                // 解析磁偏角
                _nMagDeclination = Int32.Parse((strMsgItems[10] == "") ? "0" : strMsgItems[10]);
                _drMagDeclination = ((strMsgItems[11] == "E") ? Direction.East : Direction.West);

                // 解析校验码
                _strVerify = strMsgItems[12];
            }
            catch
            {

            }

            // 默认返回false
            _strErrorMsg = null;
            return true;
        }
    }
}
