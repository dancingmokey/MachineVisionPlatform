using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GPS;

namespace UIDemo
{
    public partial class MainForm : Form
    {
        private bool _bIsStart = false;
        private bool _bIsSave = false;
        private int _nSaveCount = 0;
        private static GPSCtrl _pGPSCtrl = new GPSCtrl();

        public MainForm()
        {
            InitializeComponent();
            InitializeEnv();
        }

        private void InitializeEnv()
        {
            CameraCBox.Items.Clear();
            CameraCBox.SelectedIndex = -1;

            System.Array arCameraList = (System.Array)CameraCtrl.GetCameraList();
            for (int i = 0; i < arCameraList.Length; i++)
            {
                CameraCBox.Items.Add(arCameraList.GetValue(i));
                CameraCBox.SelectedIndex = i;
            }


        }

        private void CtrlBtn_Click(object sender, EventArgs e)
        {
            if (_bIsStart == false)
            {
                _pGPSCtrl.CreateGPSCtrl();

                _nSaveCount = 0;
                CameraCtrl.Acquisition = 1;

                UpdateTimeTicker.Start();

                CtrlBtn.Text = "Stop";
                _bIsStart = true;
            }
            else
            {
                _pGPSCtrl.DestroyGPSCtrl();

                CameraCtrl.Acquisition = 0;

                UpdateTimeTicker.Stop();

                CtrlBtn.Text = "Start";
                _bIsStart = false;
            }
        }

        private void PropertyBtn_Click(object sender, EventArgs e)
        {
            try
            {
                CameraCtrl.ShowPropertyPage();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CameraCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CameraCtrl.Camera = CameraCBox.SelectedIndex;
                CameraCtrl.DigitalZoom(0);
                CameraCtrl.BayerConversion = 1;
                CameraCtrl.Overlay = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CameraCtrl_ImageReceived(object sender, AxNeptuneLib._INeptuneEvents_ImageReceivedEvent e)
        {
            try
            {
                if (_bIsStart == true)
                {
                    string strGPS = _pGPSCtrl.RMCData.UTCDate + " " + _pGPSCtrl.RMCData.UTCTime;
                    strGPS += " ";
                    strGPS += _pGPSCtrl.RMCData.LongitudeDirection.ToString().Substring(0, 1) + _pGPSCtrl.RMCData.Longitude;
                    strGPS += " ";
                    strGPS += _pGPSCtrl.RMCData.LatitudeDirection.ToString().Substring(0, 1) + _pGPSCtrl.RMCData.Latitude;
                    strGPS += " ";
                    strGPS += (_pGPSCtrl.RMCData.Speed * 1.8).ToString();
                    
                    CameraCtrl.ClearOverlay();
                    CameraCtrl.DrawOverlayText(20, 20, 80, 255, 0, 0, strGPS);

                    if (_bIsSave == true)
                    {
                        string strFileName = String.Format("image_{0}_{1}.jpg", (_nSaveCount++), strGPS);
                        CameraCtrl.SaveImage(strFileName, 100);
                    }

                }
            }
            catch
            {
                MessageBox.Show("Unavailable Capture Path.");
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_bIsStart == true)
            {
                _pGPSCtrl.DestroyGPSCtrl();
            }
        }

        private void UpdateTimeTicker_Tick(object sender, EventArgs e)
        {
            if (_bIsStart == true)
            {
                StatusLabel.Text = "状态:运行中";
                TimeLabel.Text = "UTC时间:" + _pGPSCtrl.RMCData.UTCDate + " " + _pGPSCtrl.RMCData.UTCTime;
                LongitudeLabel.Text = "经度:" + _pGPSCtrl.RMCData.LongitudeDirection.ToString().Substring(0, 1) + _pGPSCtrl.RMCData.Longitude;
                LatitudeLabel.Text = "纬度:" + _pGPSCtrl.RMCData.LatitudeDirection.ToString().Substring(0, 1) + _pGPSCtrl.RMCData.Latitude;
                SpeedLabel.Text = "速度:" + (_pGPSCtrl.RMCData.Speed * 1.8).ToString();
                FrameCntLabel.Text = "帧数:" + _nSaveCount.ToString();
            }
        }

        private void SaveCBox_CheckedChanged(object sender, EventArgs e)
        {
            _bIsSave = SaveCBox.Checked;
        }
    }
}
