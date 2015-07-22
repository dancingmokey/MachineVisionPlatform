using System;
using System.Collections.Generic;
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
    /// <summary>
    /// InfoListExt.xaml 的交互逻辑
    /// </summary>
    public partial class InfoListExt : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        enum ILE_STYLE
        { 
            Normal = 0x01, 
            Hidden_Filter = 0x02
        }

        public InfoListExt()
        {
            InitializeComponent();
        }

        private void InfoListExt_Initialized(object sender, EventArgs e)
        {

        }

        ///// <summary>
        ///// 
        ///// </summary>
        //public void SetInfoListStyle(ILE_STYLE eStyle)
        //{
        //    if (eStyle == ILE_STYLE.Hidden_Filter)
        //    {
        //    }
        //    else
        //    {

        //    }
        //}
    }
}
