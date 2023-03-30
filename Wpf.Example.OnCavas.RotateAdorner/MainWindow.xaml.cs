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
using Wpf.Example.OnCavas.RotateAdorner.Adorners;

namespace Wpf.Example.OnCavas.RotateAdorner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RotateAdorner2 rotateAdorner;
        //private Rectangle rectangle;
        private AdornerLayer adornerLayer;
        private UIElement selectedElement;
        private Point startPoint;

        public MainWindow()
        {
            InitializeComponent();

            // Create a new Rectangle object and add it to the Canvas
            //rectangle = new Rectangle
            //{
            //    Width = 100,
            //    Height = 50,
            //    Fill = Brushes.Blue
            //};
            //Canvas.SetTop(rectangle, 100);
            //Canvas.SetLeft(rectangle, 100);
            //canvas.Children.Add(rectangle);


            //adornerLayer = AdornerLayer.GetAdornerLayer(rectangle);
            //// Create a new RotateAdorner object and attach it to the Rectangle
            //rotateAdorner = new RotateAdorner2(rectangle);
            //adornerLayer.Add(rotateAdorner);

            canvas.PreviewMouseDown += Canvas_PreviewMouseDown;
            canvas.PreviewMouseMove += Canvas_PreviewMouseMove;
            canvas.PreviewMouseUp += Canvas_PreviewMouseUp;
        }

        private void Canvas_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (rotateAdorner != null)
            {
                adornerLayer.Remove(rotateAdorner);
                rotateAdorner = null;
            }

            startPoint = e.GetPosition(canvas);

            VisualTreeHelper.HitTest(canvas, null, HitTestCallback, new PointHitTestParameters(startPoint));

            if (selectedElement != null)
            {
                Debug.WriteLine($"selectedElement : {selectedElement}");

                adornerLayer = AdornerLayer.GetAdornerLayer(selectedElement);
                rotateAdorner = new RotateAdorner2(selectedElement);
                adornerLayer.Add(rotateAdorner);
                e.Handled = true;
            }
            else
            {
                Debug.WriteLine($"selectedElement : null");
            }
        }

        private void Canvas_PreviewMouseMove(object sender, MouseEventArgs e)
        {
        }

        private void Canvas_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
        }

        private HitTestResultBehavior HitTestCallback(HitTestResult result)
        {
            if (result.VisualHit is Rectangle rectangle)
            {
                selectedElement = rectangle;
                return HitTestResultBehavior.Stop;
            }
            else if (result.VisualHit is Ellipse ellipse)
            {
                selectedElement = ellipse;
                return HitTestResultBehavior.Stop;
            }

            return HitTestResultBehavior.Continue;
        }
    }
}
