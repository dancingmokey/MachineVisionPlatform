using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UIElements
{
    public class GPS_Json_Format
    {

    }

    public class Image_Json_Format
    {

    }

    public class Running_Json_Format
    {

    }

    public class Replay_Json_Format
    {

    }




    /// <summary>
    /// 
    /// </summary>
    public enum ILE_STYLE
    {
        Normal = 0x01,
        Hidden_Filter = 0x02
    }

    /// <summary>
    /// InfoListExt.xaml 的交互逻辑
    /// </summary>
    public partial class InfoListExt : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        private ILE_STYLE _style = ILE_STYLE.Normal;
        public ILE_STYLE ShowStyle 
        { 
            get 
            { 
                return _style; 
            } 
            
            set 
            { 
                _style = value;
                this.ResetShowStyle();
            } 
        }

        /// <summary>
        /// 
        /// </summary>
        private string _content = null;
        public string Content 
        { 
            get 
            { 
                return _content; 
            } 
            
            set 
            { 
                _content = value;
                this.ResetContent();
            } 
        }


        /// <summary>
        /// 
        /// </summary>
        public InfoListExt()
        {
            InitializeComponent();
        }

        public void CustomInitialize(ILE_STYLE CustomStyle, string ContentStr)
        {
            this.ShowStyle = CustomStyle;

            this.Content = Content;
        }

        /// <summary>
        /// 
        /// </summary>
        private void ResetShowStyle()
        {
            if (_style == ILE_STYLE.Hidden_Filter)
            {
                FilterGridRow.Height = new GridLength(0);
            }
            else
            {
                FilterGridRow.Height = new GridLength(30);
            }
        }

        private void ResetContent()
        {
            // 解析Json字符串
            JsonReader contentReader = new JsonTextReader(new StringReader(_content));

            while (contentReader.Read())
            {
                if (contentReader.TokenType == JsonToken.PropertyName)
                {

                }
                else if (contentReader.TokenType == JsonToken.String)
                {

                }
            }
        }
    }
}
