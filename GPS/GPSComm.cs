using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GPS
{
    public class GPSComm
    {
        /// <summary>
        /// 定义通信端口
        /// </summary>
        private static int _nCommPort = 0;
        public int CommPort { get { return _nCommPort; } set { _nCommPort = value; } }

        /// <summary>
        /// 定义错误字符串
        /// </summary>
        private string _strErrorMsg = null;
        public string ErrorMsg { get { return _strErrorMsg; } set { _strErrorMsg = value; } }

        private static bool _bEnableRunning = false;
        private static Thread _pWorkThread = null;
        private delegate void GPSCommDelegate(Byte[] pRecvData); 

        /// <summary>
        /// 
        /// </summary>
        public GPSComm(int nCommPort)
        {
            _nCommPort = nCommPort;
        }

        public static void StartWorking(int nCommPort)
        {
            _nCommPort = nCommPort;
            _bEnableRunning = true;
            _pWorkThread = new Thread(RecvGPSData);
            _pWorkThread.Start();
        }

        public static void StopWorking()
        {
            //
            if (_bEnableRunning == true)
            {
                _bEnableRunning = false;
                _pWorkThread.Join();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private static void RecvGPSData()
        {
            // 定义网络接口
            UdpClient pUdpReceiver = null;
            IPEndPoint pIPEndPoint = null;

            // 定义接收缓冲区
            Byte[] pRecvData = new Byte[1024];

            // 定义代理
            GPSCommDelegate pDelegate = new GPSCommDelegate(GPS.GPSCtrl.AnalysisData);

            // 开始循环接受数据
            while (_bEnableRunning == true)
            {
                try
                {
                    // 初始化Udp连接
                    if ((pUdpReceiver == null) || (pIPEndPoint == null))
                    {
                        pUdpReceiver = new UdpClient(_nCommPort);
                        pUdpReceiver.Client.ReceiveBufferSize = 51200;
                        pIPEndPoint = new IPEndPoint(IPAddress.Any, _nCommPort);
                    }

                    // 接收数据
                    if (pUdpReceiver != null)
                    {
                        // 检查数据长度
                        pRecvData = pUdpReceiver.Receive(ref pIPEndPoint);
                        if (pRecvData.Length > 0)
                        {
                            // 通过代理传递数据
                            pDelegate(pRecvData);
                        }
                    }
                }
                catch (Exception exception)
                {
                    // 输出异常信息
                    Console.WriteLine(exception.StackTrace + " : " + exception.Message);
                }
                finally
                {
                }
            }

            if (pUdpReceiver != null)
            {
                pUdpReceiver.Close();
            }

            Console.WriteLine("GPS Communicate Thread Exit!!");
        }
    }
}
