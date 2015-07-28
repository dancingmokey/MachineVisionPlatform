using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Data;

namespace VideoDetectSystem.DatabaseControl
{
    /// <summary>
    /// Configuration Class
    /// </summary>
    public class RecordControl
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataSet select_vds_recordlist()
        {
            //
            string strSql = "select RecordNo, DeviceName, RecordName, RecordTime, RecordPath, RecordLength from recordlist";

            //
            return AccessHelper.ExecuteDataSet(AccessHelper.conn_str, strSql, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="strPath"></param>
        /// <param name="strTime"></param>
        /// <param name="nLength"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="strPath"></param>
        /// <param name="strTime"></param>
        /// <param name="nLength"></param>
        /// <returns></returns>
        public int delete_vds_recordlist(int nRecordNo)
        {
            //
            string strSql = "delete from recordlist where RecordNo = @rn";
            OleDbParameter[] pParames = {
                                             new OleDbParameter("@rn", nRecordNo)
                                         };

            //
            return AccessHelper.ExecuteNonQuery(AccessHelper.conn_str, strSql, pParames);
        }
    }
}
