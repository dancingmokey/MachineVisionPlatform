using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Windows.Controls.Ribbon;

namespace SystemUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        public int ncount = 0;
        public MainWindow()
        {
            InitializeComponent();

            // Insert code required on object creation below this point.
        }

        private void RunCtrlBtn_Click(object sender, RoutedEventArgs e)
        {
            if ((ncount++)%2 == 0)
            {
                this.RTCtrl.InfoListExtDisplay(UIElements.ILE_STYLE.Hidden_Filter);
            }
            else
            {
                this.RTCtrl.InfoListExtDisplay(UIElements.ILE_STYLE.Normal);
            }
        }

        private void GPSShowChBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CamShowChBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void TransShowChBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void RunShowChBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void DevListShowChBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Ribbon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //
            int CurrIdx = Ribbon.SelectedIndex;

            //
            switch (CurrIdx)
            {
                case 0:
                    {
                        this.RTCtrl.Visibility = Visibility.Visible;
                        this.RLCtrl.Visibility = Visibility.Hidden;
                        this.MgCtrl.Visibility = Visibility.Hidden;
                        break;
                    }
                case 1:
                    {
                        this.RTCtrl.Visibility = Visibility.Hidden;
                        this.RLCtrl.Visibility = Visibility.Visible;
                        this.MgCtrl.Visibility = Visibility.Hidden;
                        break;
                    }
                case 2:
                    {
                        this.RTCtrl.Visibility = Visibility.Hidden;
                        this.RLCtrl.Visibility = Visibility.Hidden;
                        this.MgCtrl.Visibility = Visibility.Visible;
                        break;
                    }
                default:
                    {
                        this.RTCtrl.Visibility = Visibility.Visible;
                        this.RLCtrl.Visibility = Visibility.Hidden;
                        this.MgCtrl.Visibility = Visibility.Hidden;
                        break;
                    }
            }
        }
    }
}
