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
    /// RealTimeCtrl.xaml 的交互逻辑
    /// </summary>
    public partial class RealTimeCtrl : UserControl
    {
        public RealTimeCtrl()
        {
            InitializeComponent();
        }

        public void InfoListExtDisplay(ILE_STYLE eIleStyle)
        {
            this.GPSInfoListExt.SetInfoListStyle(eIleStyle);
            this.ImageInfoListExt.SetInfoListStyle(eIleStyle);
            this.TransInfoListExt.SetInfoListStyle(eIleStyle);
        }
    }

}
