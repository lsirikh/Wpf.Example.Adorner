using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Wpf.Example.OnCavas.RotateAdorner
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 3/28/2023 3:49:42 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class RotateAdorner2 : Adorner
    {

        #region - Ctors -
        public RotateAdorner2(UIElement adornedElement) : base(adornedElement)
        {
            visualChildren = new VisualCollection(this);

            // 회전을 위한 원을 만듭니다.
            circle = new Ellipse
            {
                Width = circleSize,
                Height = circleSize,
                Fill = Brushes.White,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };

            // 원의 이벤트를 처리합니다.
            circle.MouseEnter += Circle_MouseEnter;
            circle.MouseLeave += Circle_MouseLeave;
            circle.MouseDown += Circle_MouseDown;
            circle.MouseUp += Circle_MouseUp;
            circle.MouseMove += Circle_MouseMove;

            // 회전용 원을 추가합니다.
            visualChildren.Add(circle);
        }
        #endregion
        #region - Implementation of Interface -
        #endregion
        #region - Overrides -
        private double GetAngle()
        {
            // Calculate the angle between the start and end points
            double angle = Vector.AngleBetween(startVector, endPoint - new Point(AdornedElement.RenderSize.Width / 2, AdornedElement.RenderSize.Height / 2));

            // Make sure the angle is positive
            if (angle < 0)
            {
                angle += 360;
            }

            return angle;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            // Position the adorner at the top-left corner of the adorned element
            circle.Arrange(new Rect(new Point(-circleSize / 2, -circleSize / 2), new Size(circleSize, circleSize)));

            // Rotate the adorned element to match the new angle
            double angle = GetAngle();
            AdornedElement.RenderTransformOrigin = new Point(0.5, 0.5);
            AdornedElement.RenderTransform = new RotateTransform(angle);

            return finalSize;
        }

        protected override Visual GetVisualChild(int index)
        {
            return visualChildren[index];
        }

        protected override int VisualChildrenCount
        {
            get { return visualChildren.Count; }
        }
        #endregion
        #region - Binding Methods -
        #endregion
        #region - Processes -
        private void Circle_MouseEnter(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Hand;
        }

        private void Circle_MouseLeave(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Arrow;
        }

        private void Circle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(AdornedElement);
            startVector = Point.Subtract(endPoint, new Point(AdornedElement.RenderSize.Width / 2, AdornedElement.RenderSize.Height / 2));
            circle.CaptureMouse();
        }

        private void Circle_MouseUp(object sender, MouseButtonEventArgs e)
        {
            circle.ReleaseMouseCapture();
        }

        private void Circle_MouseMove(object sender, MouseEventArgs e)
        {
            if (circle.IsMouseCaptured)
            {
                endPoint = e.GetPosition(AdornedElement);

                // Calculate the angle between the start and end points relative to the center of the circle
                double angle = Vector.AngleBetween(startVector, endPoint - new Point(AdornedElement.RenderSize.Width / 2, AdornedElement.RenderSize.Height / 2));
                Point centerPoint = new Point(AdornedElement.RenderSize.Width / 2, AdornedElement.RenderSize.Height / 2);
                Vector vectorToCenter = Point.Subtract(endPoint, centerPoint);
                double distanceToCenter = vectorToCenter.Length;

                // Convert the angle to radians
                double radians = angle * Math.PI / 180;

                // Calculate the new X and Y positions of the endpoint based on the distance to the center
                double newX = centerPoint.X + Math.Cos(radians) * distanceToCenter;
                double newY = centerPoint.Y + Math.Sin(radians) * distanceToCenter;

                // Update the endpoint to the new position
                endPoint = new Point(newX, newY);

                // Redraw the adorner
                InvalidateArrange();
            }
        }
        #endregion
        #region - IHanldes -
        #endregion
        #region - Properties -
        #endregion
        #region - Attributes -
        private const double circleSize = 16;
        private const double circleMargin = 4;

        private readonly VisualCollection visualChildren;
        private readonly Ellipse circle;

        private Point startPoint;
        private Point endPoint;
        private Vector startVector;
        #endregion

    }
}
