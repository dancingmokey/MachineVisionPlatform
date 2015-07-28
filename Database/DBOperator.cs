using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Data;

namespace Database
{
    class DBOperator
    {
        /// <summary>
        /// 
        /// </summary>
        private static string InsertUserInfoSql = "Insert into  UserID, UserName, UserPwd, UserDept, UserTel, UserEmail, CreateTime, ModifyTime From UserInfo";
        private static string UpdateUserInfoSql = "Insert into  UserID, UserName, UserPwd, UserDept, UserTel, UserEmail, CreateTime, ModifyTime From UserInfo";
        private static string DeleteUserInfoSql = "Delete UserInfo Where";

        private static string QueryLineInfoSql = "Select LineID, LineName, CreateTime, ModifyTime From LineInfo";

        private static string QueryDevicesInfoSql = "Select DeviceID, DeviceName, DeviceType, CreateTime, ModifyTime From DevicesInfo";

        private static string QueryDeviceInfoSql = "Select DeviceID, DeviceIndex, LineIndex, DeviceNo, DeviceSide, DeviceMile, DeviceLatitude, DeviceLongitude, CreateTime, ModifyTime From DeviceInfo";

        private static string QueryRecordsInfoSql = "Select RecordID, LineIndex, UserIndex, RecordName, StartTime, EndTime, CreateTime, ModifyTime From RecordsInfo";

        private static string QueryRecordInfoSql = "Select RecordID, RecordIndex, FileName, FileOffset, GPSTime, Speed, Latitude, Longitude, CreateTime, ModifyTime From RecordsInfo";

        private static string QueryConfigHistorySql = "Select ConfigID, CamName, CamFactory, CamModel, CamSerial, GPSAddr, GPSPort, TransAddr, TransPort, CreateTime, ModifyTime From ConfigHistory";




        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string QueryUserInfo()
        {
            //
            string strSql = null;
            strSql += "Select ";
            strSql += "UserID,";
            strSql += "UserName,";
            strSql += "UserPwd,";
            strSql += "UserDept,";
            strSql += "UserTel,";
            strSql += "UserEmail,";
            strSql += "CreateTime,";
            strSql += "ModifyTime ";
            strSql += "From ";
            strSql += "UserInfo ";

            //
            return AccessHelper.ExecuteDataSet(AccessHelper.conn_str, strSql, null).GetXml();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="strPath"></param>
        /// <param name="strTime"></param>
        /// <param name="nLength"></param>
        public int insert_vds_recordlist(string strDevice, string strName, string strTime, string strPath, int nLength)
        {
            //
            string strSql = "insert into recordlist (DeviceName, RecordName, RecordTime, RecordPath, RecordLength)  values (@dn, @rn, @rt, @rp, @rl)";
            OleDbParameter[] pParames = {
                                             new OleDbParameter("@dn", strDevice),
                                             new OleDbParameter("@rn", strName),
                                             new OleDbParameter("@rt",  strTime),
                                             new OleDbParameter("@rp", strPath),
                                             new OleDbParameter("@rl", nLength)
                                         };

            //
            return AccessHelper.ExecuteNonQuery(AccessHelper.conn_str, strSql, pParames);
        }
    }
}
