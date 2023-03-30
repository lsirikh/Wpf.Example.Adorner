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

namespace Wpf.Example.OnCanvas.Adorner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            
            canvas.PreviewMouseDown += Canvas_PreviewMouseDown;
            canvas.PreviewMouseMove += Canvas_PreviewMouseMove;
            canvas.PreviewMouseUp += Canvas_PreviewMouseUp;
        }

        




        #region  - Overrridings -
        #endregion

        #region  - Methods -
        private void Canvas_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (resizeAdorner != null)
            {
                adornerLayer.Remove(resizeAdorner);
                resizeAdorner?.Dispose();
            }

            startPoint = e.GetPosition(canvas);

            VisualTreeHelper.HitTest(canvas, null, HitTestCallback, new PointHitTestParameters(startPoint));

            if (selectedElement != null)
            {
                Debug.WriteLine($"selectedElement : {selectedElement}");
                
                adornerLayer = AdornerLayer.GetAdornerLayer(selectedElement);
                resizeAdorner = new ResizeAdorner(selectedElement);
                adornerLayer.Add(resizeAdorner);
                e.Handled = true;
            }
            else
            {
                resizeAdorner?.Dispose();
                Debug.WriteLine($"selectedElement : null");
            }
        }

        private void Canvas_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void Canvas_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (selectedElement != null && e.LeftButton == MouseButtonState.Pressed)
            {
                Point endPoint = e.GetPosition(canvas);

                if (resizeAdorner != null)
                {

                    //resizeAdorner.Resize(startPoint, endPoint);

                    double horizontalChange = endPoint.X - startPoint.X;
                    double verticalChange = endPoint.Y - startPoint.Y;

                    Canvas.SetLeft(selectedElement, Canvas.GetLeft(selectedElement) + horizontalChange);
                    Canvas.SetTop(selectedElement, Canvas.GetTop(selectedElement) + verticalChange);

                    startPoint = endPoint;
                }
                else
                {
                    double horizontalChange = endPoint.X - startPoint.X;
                    double verticalChange = endPoint.Y - startPoint.Y;

                    Canvas.SetLeft(selectedElement, Canvas.GetLeft(selectedElement) + horizontalChange);
                    Canvas.SetTop(selectedElement, Canvas.GetTop(selectedElement) + verticalChange);

                    startPoint = endPoint;
                }
            }
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
        #endregion

        #region  - Fields -
        private AdornerLayer adornerLayer;
        private UIElement selectedElement;
        private Point startPoint;
        private ResizeAdorner resizeAdorner;
        #endregion
    }
}
