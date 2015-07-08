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
using System.IO;

namespace UIDemo
{
    public partial class AvtForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        private bool _bIsStart = false;
        private bool _bIsSave = false;
        private int _nSaveCount = 0;
        private static GPSCtrl _pGPSCtrl = new GPSCtrl();

        /// <summary>
        /// 
        /// </summary>
        private delegate void DeviceLostDelegate();
        private delegate void ShowBufferDelegate(TIS.Imaging.ImageBuffer buffer);

        private FileStream _fsGPSRecord = null;
        private StreamWriter _swGPSRecord = null;

        public AvtForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CtrlBtn_Click(object sender, EventArgs e)
        {
            if (_bIsStart == false)
            {
                _pGPSCtrl.CreateGPSCtrl();

                _fsGPSRecord = new FileStream("GPS_Record_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".log", FileMode.Create, FileAccess.Write);
                _swGPSRecord = new StreamWriter(_fsGPSRecord);
                _swGPSRecord.AutoFlush = true;

                _nSaveCount = 0;
                StartLiveVideo();

                UpdateTimeTicker.Start();

                CtrlBtn.Text = "Stop";
                _bIsStart = true;
            }
            else
            {
                _pGPSCtrl.DestroyGPSCtrl();

                _swGPSRecord.Close();
                _fsGPSRecord.Close();

                StopLiveVideo();

                UpdateTimeTicker.Stop();

                CtrlBtn.Text = "Start";
                _bIsStart = false;
            }
        }

        private void SettingBtn_Click(object sender, EventArgs e)
        {
            if (CameraCtrl.DeviceValid)
            {
                CameraCtrl.LiveStop(); ;
            }
            else
            {
                CameraCtrl.Device = "";
            }
            CameraCtrl.ShowDeviceSettingsDialog();

            if (CameraCtrl.DeviceValid)
            {
                // Save the currently used device into a file in order to be able to open it
                // automatically at the next program start.
                CameraCtrl.SaveDeviceStateToFile("device.xml");
            }
        }

        private void PropertyBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CameraCtrl.DeviceValid)
                {
                    CameraCtrl.ShowPropertyDialog();
                    CameraCtrl.SaveDeviceStateToFile("device.xml");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateTimeTicker_Tick(object sender, EventArgs e)
        {
            if (_bIsStart == true)
            {
                StatusLabel.Text = "状态:运行中";
                TimeLabel.Text = "UTC时间:" + _pGPSCtrl.RMCData.LocalTime;
                LongitudeLabel.Text = "经度:" + _pGPSCtrl.RMCData.Longitude;
                LatitudeLabel.Text = "纬度:" + _pGPSCtrl.RMCData.Latitude;
                SpeedLabel.Text = "速度:" + (_pGPSCtrl.RMCData.Speed * 1.8).ToString();
                FrameCntLabel.Text = "帧数:" + _nSaveCount.ToString();

                _swGPSRecord.WriteLine(_pGPSCtrl.RMCData.LocalTime + "\t" +
                    _pGPSCtrl.RMCData.Longitude + "\t" +
                    _pGPSCtrl.RMCData.Latitude + "\t" +
                    (_pGPSCtrl.RMCData.Speed * 1.8).ToString() + "\t" + 
                    _pGPSCtrl.RMCData.OrgData);
            }
        }

        private void SaveCBox_CheckedChanged(object sender, EventArgs e)
        {
            _bIsSave = SaveCBox.Checked;
        }

        private void CameraCtrl_DeviceLost(object sender, TIS.Imaging.ICImagingControl.DeviceLostEventArgs e)
        {
            BeginInvoke(new DeviceLostDelegate(ref DeviceLost));
        }

        private void AvtForm_Load(object sender, EventArgs e)
        {
            // Try to load the previously used device. 
            try
            {
                CameraCtrl.LoadDeviceStateFromFile("device.xml", true);
            }
            catch
            {
                // Either the xml file does not exist or the device
                // could not be loaded. In both cases we do nothing and proceed.
            }

            CameraCtrl.LiveDisplayDefault = false;
            CameraCtrl.LiveDisplayHeight = CameraCtrl.Height;
            CameraCtrl.LiveDisplayWidth = CameraCtrl.Width;
            CameraCtrl.LiveCaptureContinuous = true;
            CameraCtrl.LiveDisplay = false;
            CameraCtrl.OverlayBitmap.Enable = true;
        }

        private void AvtForm_SizeChanged(object sender, EventArgs e)
        {
            if (CameraCtrl.DeviceValid)
            {
                CameraCtrl.LiveDisplayHeight = CameraCtrl.Height;
                CameraCtrl.LiveDisplayWidth = CameraCtrl.Width;
            }
        }

        private void AvtForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CameraCtrl.DeviceValid)
            {
                CameraCtrl.LiveStop();
            }

            if (_bIsStart == true)
            {
                _pGPSCtrl.DestroyGPSCtrl();
            }
        }

        ////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Start the live video and update the state of the start/stop button.
        /// </summary>LiveVideo()
        private void StartLiveVideo()
        {
            CameraCtrl.LiveStart();
        }

        /// <summary>
        /// Stop the live video and update the state of the start/stop button.
        /// </summary>
        private void StopLiveVideo()
        {
            CameraCtrl.LiveStop();
        }
        /// <summary>
        /// Handle the DeviceLost event.
        /// </summary>
        private void DeviceLost()
        {
            MessageBox.Show("Device Lost!");
        }

        /// <summary>
        /// Show assigned image buffer.
        /// </summary>
        /// <param name="buffer"></param>
        private void ShowImageBuffer(TIS.Imaging.ImageBuffer buffer)
        {
            CameraCtrl.DisplayImageBuffer(buffer);
            buffer.Unlock();
        }

        private void CameraCtrl_ImageAvailable(object sender, TIS.Imaging.ICImagingControl.ImageAvailableEventArgs e)
        {
            try
            {
                CameraCtrl.OverlayBitmap.DrawText(Color.Red, 10, 10, _pGPSCtrl.RMCData.LocalTime);
                CameraCtrl.OverlayBitmap.DrawText(Color.Red, 150, 10, "Lat:" + _pGPSCtrl.RMCData.Latitude + " Log:" + _pGPSCtrl.RMCData.Longitude);
                CameraCtrl.OverlayBitmap.DrawText(Color.Red, 550, 10, "Speed:" + _pGPSCtrl.RMCData.Speed.ToString());
                
                TIS.Imaging.ImageBuffer ImgBuffer;
                ImgBuffer = CameraCtrl.ImageActiveBuffer;
                ImgBuffer.Lock();

                // Display the processed image in the IC Imaging Control window.
                this.BeginInvoke(new ShowBufferDelegate(ShowImageBuffer), ImgBuffer);

                if (_bIsSave == true)
                {
                    string strFileName = String.Format("image_{0}_{1}.bmp", (_nSaveCount++), DateTime.Now.ToString("yyyyMMddHHmmssfff"));
                    ImgBuffer.SaveAsBitmap(strFileName);
                }


            }
            catch (Exception ex)
            {
                // An exception that occurs here cannot be handled elsewhere. 
                // Therefore, if you are using the ImageAvailable event, watch the debug
                // output window of your Visual Studio because the message (see below)
                // will appear there.
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}
