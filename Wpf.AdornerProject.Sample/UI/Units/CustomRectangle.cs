using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    
    public class CustomRectangle : Control
    {
        static CustomRectangle()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomRectangle), new FrameworkPropertyMetadata(typeof(CustomRectangle)));
        }

        public double ShapeWidth
        {
            get => (double)GetValue(ShapeWidthProperty);
            set => SetValue(ShapeWidthProperty, value);
        }

        public static readonly DependencyProperty ShapeWidthProperty =
            DependencyProperty.Register("ShapeWidth", typeof(double), typeof(CustomRectangle), new PropertyMetadata(100d));

        public double ShapeHeight
        {
            get => (double)GetValue(ShapeHeightProperty);
            set => SetValue(ShapeHeightProperty, value);
        }

        public static readonly DependencyProperty ShapeHeightProperty =
            DependencyProperty.Register("ShapeHeight", typeof(double), typeof(CustomRectangle), new PropertyMetadata(100d));

        public Brush Fill
        {
            get => (Brush)GetValue(FillProperty);
            set => SetValue(FillProperty, value);
        }

        public static readonly DependencyProperty FillProperty =
            DependencyProperty.Register("Fill", typeof(Brush), typeof(CustomRectangle), new PropertyMetadata(Brushes.Red));


    }
}
