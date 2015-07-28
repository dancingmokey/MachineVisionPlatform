using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    /// <summary>
    /// 
    /// </summary>
    public class ConfigHistory
    {
        public int ConfigID;
        public string CamName;
        public string CamFactory;
        public string CamModel;
        public string CamSerial;
        public string GPSAddr;
        public int GPSPort;
        public string TransAddr;
        public int TransPort;
    }

    /// <summary>
    /// 
    /// </summary>
    public class LineInfo
    {
        public int LineID;
        public string LineName;
    }
    
    /// <summary>
    /// 
    /// </summary>
    public class DevicesInfo
    {
        public int DeviceID;
        public string DeviceName;
        public string DeviceType;
    }

    /// <summary>
    /// 
    /// </summary>
    public class DeviceInfo
    {
        public int DeviceID;
        public int DeviceIndex;
        public int LineIndex;
        public string DeviceNo;
        public bool DeviceSide;
        public int DeviceMile;
        public string DeviceLatitude;
        public string DeviceLongitude;
    }

    /// <summary>
    /// 
    /// </summary>
    public class RecordsInfo
    {
        public int RecordID;
        public int LineIndex;
        public int UserIndex;
        public string RecordName;
        public string StartTime;
        public string EndTime;
        public string ContentTime;
    }

    /// <summary>
    /// 
    /// </summary>
    public class RecordInfo
    {
        public int RecordID;
        public int RecordIndex;
        public string FileName;
        public int FileOffset;
        public string GPSTime;
        public string Speed;
        public string Latitude;
        public string Longitude;
    }

    /// <summary>
    /// 
    /// </summary>
    public class UserInfo
    {
        public int UserID;
        public string UserName;
        public string UserPwd;
        public string UserDept;
        public string UserTel;
        public string UserEmail;
    }
}
