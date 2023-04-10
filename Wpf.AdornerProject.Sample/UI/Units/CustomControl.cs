using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Wpf.AdornerProject.Sample.UI.Units
{
    
    public class CustomControl : ContentControl
    {
        static CustomControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomControl), new FrameworkPropertyMetadata(typeof(CustomControl)));
        }

        public bool OnEditable
        {
            get { return (bool)GetValue(OnEditableProperty); }
            set { SetValue(OnEditableProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OnEditable.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OnEditableProperty =
            DependencyProperty.Register("OnEditable", typeof(bool), typeof(ContentControl), new PropertyMetadata(false));


        public bool IsEditable
        {
            get { return (bool)GetValue(IsEditableProperty); }
            set { SetValue(IsEditableProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsEditable.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsEditableProperty =
            DependencyProperty.Register("IsEditable", typeof(bool), typeof(CustomControl), new PropertyMetadata(false));


        public string Fill
        {
            get { return (string)GetValue(FillProperty); }
            set { SetValue(FillProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Fill.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FillProperty =
            DependencyProperty.Register("Fill", typeof(string), typeof(CustomControl), new PropertyMetadata("#000000"));


        public bool IsShowLable
        {
            get { return (bool)GetValue(IsShowLableProperty); }
            set { SetValue(IsShowLableProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsShowLable.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsShowLableProperty =
            DependencyProperty.Register("IsShowLable", typeof(bool), typeof(CustomControl), new PropertyMetadata(false));





        public double Angle
        {
            get { return (double)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Angle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AngleProperty =
            DependencyProperty.Register("Angle", typeof(double), typeof(CustomControl), new PropertyMetadata(0d));




        public string Lable
        {
            get { return (string)GetValue(LableProperty); }
            set { SetValue(LableProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Lable.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LableProperty =
            DependencyProperty.Register("Lable", typeof(string), typeof(CustomControl), new PropertyMetadata(String.Empty));



        //public void SizeChange(object sender, MouseEventArgs e)
        //{
        //    if(!(sender is Ellipse ellipse))
        //        return;

        //    Debug.WriteLine($"{ellipse.Width} {ellipse.Height}");
        //}
    }
}
