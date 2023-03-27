using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf.Example.Adorner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AdornerLayer _adornerLayer;
        private FrameworkElement _adornedElement;
        private ResizeAdorner _resizeAdorner;

        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;
            MouseLeave += MainWindow_MouseLeave;
            Keyboard.AddKeyDownHandler(this, KeyEvent_EscHandler);
        }

        private void KeyEvent_EscHandler(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Escape)
                ReleaseAdorner();
        }

        

        private void MainWindow_MouseLeave(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                Debug.WriteLine($"Mouse is Out with button pressed");
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _adornerLayer = AdornerLayer.GetAdornerLayer(myRectangle);
            myRectangle.MouseLeftButtonDown += MyRectangle_MouseLeftButtonDown;
        }

        private void MyRectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (_resizeAdorner != null)
                return;

            _adornedElement = sender as FrameworkElement;
            _resizeAdorner = new ResizeAdorner(_adornedElement);
            _adornerLayer.Add(_resizeAdorner);
            _resizeAdorner.MouseLeftButtonDown += ResizeAdorner_MouseLeftButtonDown;
            _resizeAdorner.MouseMove += ResizeAdorner_MouseMove;
            _resizeAdorner.MouseLeftButtonUp += ResizeAdorner_MouseLeftButtonUp;
        }

        private void ReleaseAdorner()
        {
            if (_resizeAdorner == null)
                return;

            _resizeAdorner.ReleaseMouseCapture();
            _adornerLayer.Remove(_resizeAdorner);
            _resizeAdorner.MouseLeftButtonDown -= ResizeAdorner_MouseLeftButtonDown;
            _resizeAdorner.MouseMove -= ResizeAdorner_MouseMove;
            _resizeAdorner.MouseLeftButtonUp -= ResizeAdorner_MouseLeftButtonUp;
            _resizeAdorner.Dispose();
            _resizeAdorner = null;
        }

        private void ResizeAdorner_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _resizeAdorner.CaptureMouse();
        }

        private void ResizeAdorner_MouseMove(object sender, MouseEventArgs e)
        {
            if (_resizeAdorner.IsMouseCaptured)
            {
                Point currentPosition = e.GetPosition(_adornedElement);
                double width = currentPosition.X + 10;
                double height = currentPosition.Y + 10;
                _adornedElement.Width = width > 0 ? width : 0;
                _adornedElement.Height = height > 0 ? height : 0;
                _resizeAdorner.InvalidateVisual();
            }
        }

        private void ResizeAdorner_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _resizeAdorner.ReleaseMouseCapture();
        }



    }
}
