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

namespace Wpf.AdornerProject.Sample.UI.Units
{
    
    public class CustomControl : ContentControl
    {
        static CustomControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomControl), new FrameworkPropertyMetadata(typeof(CustomControl)));
        }



        public bool IsEditable
        {
            get { return (bool)GetValue(IsEditableProperty); }
            set { SetValue(IsEditableProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsEditable.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsEditableProperty =
            DependencyProperty.Register("IsEditable", typeof(bool), typeof(CustomControl), new PropertyMetadata(false));



        public Brush Fill
        {
            get { return (Brush)GetValue(FillProperty); }
            set { SetValue(FillProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Fill.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FillProperty =
            DependencyProperty.Register("Fill", typeof(Brush), typeof(CustomControl), new PropertyMetadata(Brushes.Transparent));




        public double ShapeWidth
        {
            get { return (double)GetValue(ShapeWidthProperty); }
            set { SetValue(ShapeWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShapeWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShapeWidthProperty =
            DependencyProperty.Register("ShapeWidth", typeof(double), typeof(CustomControl), new PropertyMetadata(20d));




        public double ShapeHeight
        {
            get { return (double)GetValue(ShapeHeightProperty); }
            set { SetValue(ShapeHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShapeHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShapeHeightProperty =
            DependencyProperty.Register("ShapeHeight", typeof(double), typeof(CustomControl), new PropertyMetadata(20d));




        public bool IsShowLable
        {
            get { return (bool)GetValue(IsShowLableProperty); }
            set { SetValue(IsShowLableProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsShowLable.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsShowLableProperty =
            DependencyProperty.Register("IsShowLable", typeof(bool), typeof(CustomControl), new PropertyMetadata(false));




        public string Lable
        {
            get { return (string)GetValue(LableProperty); }
            set { SetValue(LableProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Lable.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LableProperty =
            DependencyProperty.Register("Lable", typeof(string), typeof(CustomControl), new PropertyMetadata(String.Empty));



        public double LableWidth
        {
            get { return (double)GetValue(LableWidthProperty); }
            set { SetValue(LableWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LableWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LableWidthProperty =
            DependencyProperty.Register("LableWidth", typeof(double), typeof(CustomControl), new PropertyMetadata(20d));





        public double LableHeight
        {
            get { return (double)GetValue(LableHeightProperty); }
            set { SetValue(LableHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LableHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LableHeightProperty =
            DependencyProperty.Register("LableHeight", typeof(double), typeof(CustomControl), new PropertyMetadata(10d));




    }
}
