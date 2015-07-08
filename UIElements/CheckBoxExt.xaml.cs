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

namespace UIElements
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class CheckBoxExt : UserControl
    {  
        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty IsCheckedProperty = 
            DependencyProperty.Register("IsChecked", typeof(bool), 
            typeof(CheckBoxExt),
            new PropertyMetadata(default(bool),
                OnIsCheckedChanged));     
        /// <summary>
        /// 
        /// </summary>
        public event RoutedEventHandler Checked;
        public event RoutedEventHandler UnChecked;

        /// <summary>
        /// 
        /// </summary>
        public bool IsChecked         
        {             
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }   

        /// <summary>
        /// 
        /// </summary>
        public CheckBoxExt()
        {
            InitializeComponent();
        }        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="args"></param>
        private static void OnIsCheckedChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)         
        {             
            (obj as CheckBoxExt).OnIsCheckedChanged(args);
        }         
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        private void OnIsCheckedChanged(DependencyPropertyChangedEventArgs args)         
        {             
            fillRectangle.Visibility = IsChecked ? Visibility.Visible : Visibility.Collapsed;
            slideBorder.HorizontalAlignment = IsChecked ? HorizontalAlignment.Right : HorizontalAlignment.Left;

            if (IsChecked && Checked != null)             
            {                 
                Checked(this, new RoutedEventArgs()); 
            }             
            
            if (!IsChecked && UnChecked != null)
            {                 
                UnChecked(this, new RoutedEventArgs());             
            }         
        }        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs args)
        {             
            args.Handled = true;             
            IsChecked ^= true;             
            base.OnMouseLeftButtonUp(args);         
        }  
    }
}



