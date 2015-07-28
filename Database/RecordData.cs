using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoDetectSystem.DatabaseControl
{
    public class RecordData
    {
        /// <summary>
        /// 
        /// </summary>
        private int _nRecordNo;
        public int RecordNo { get { return _nRecordNo; } set { _nRecordNo = value; } }

        /// <summary>
        /// 
        /// </summary>
        private string _strRecordName;
        public string RecordName { get { return _strRecordName; } set { _strRecordName = value; } }

        /// <summary>
        /// 
        /// </summary>
        private string _strRecordTime;
        public string RecordTime { get { return _strRecordTime; } set { _strRecordTime = value; } }

        /// <summary>
        /// 
        /// </summary>
        private string _strRecordSavePath;
        public string RecordSavePath { get { return _strRecordSavePath; } set { _strRecordSavePath = value; } }

        /// <summary>
        /// 
        /// </summary>
        private int _nRecordLength;
        public int RecordLength { get { return _nRecordLength; } set { _nRecordLength = value; } }

        /// <summary>
        /// 
        /// </summary>
        private bool _bIsRecordAdded;
        public bool IsRecordAdded { get { return _bIsRecordAdded; } set { _bIsRecordAdded = value; } }

        /// <summary>
        /// 
        /// </summary>
        private bool _bHaveFront;
        public bool IsHaveFront { get { return _bHaveFront; } set { _bHaveFront = value; } }

        /// <summary>
        /// 
        /// </summary>
        private bool _bHaveBack;
        public bool IsHaveBack { get { return _bHaveBack; } set { _bHaveBack = value; } }

        /// <summary>
        /// 
        /// </summary>
        private bool _bIsPreview;
        public bool IsPreview { get { return _bIsPreview; } set { _bIsPreview = value; } }
    }
}
