using System.Windows.Media;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Shapes;
using System;
using System.Windows.Controls.Primitives;
using System.Diagnostics;

namespace Wpf.Example.OnCavas.RotateAdorner.Adorners
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 3/28/2023 2:24:38 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class RotateAdorner : Adorner
    {

        #region - Ctors -
        public RotateAdorner(UIElement adornedElement) : base(adornedElement)
        {
            // VisualCollection을 초기화합니다.
            visualCollection = new VisualCollection(this);

            // 회전용 원을 만들고, 원의 이벤트를 처리합니다.


            BuildAdornerCorner(ref circleTh, Cursors.ScrollAll, new DragDeltaEventHandler(circleTh_DragDelta));

            //Ellipse circle = new Ellipse
            //{
            //    Width = circleSize,
            //    Height = circleSize,
            //    Fill = Brushes.White,
            //    Stroke = Brushes.Black,
            //    StrokeThickness = 1,
            //    Cursor = Cursors.Hand
            //};
            //circleTh.MouseDown += Circle_MouseDown;
            //circleTh.MouseMove += Circle_MouseMove;
            //circleTh.MouseUp += Circle_MouseUp;

            // 회전용 원을 visualChildren에 추가합니다.
        }

       

        #endregion
        #region - Implementation of Interface -
        #endregion
        #region - Overrides -
        protected override int VisualChildrenCount => visualCollection.Count;

        protected override Visual GetVisualChild(int index) => visualCollection[index];

        protected override Size ArrangeOverride(Size finalSize)
        {
            // 회전용 원을 가운데로 이동시킵니다.
            double left = (AdornedElement.RenderSize.Width / 2) - (circleSize / 2);
            double top = -circleSize;
            circleTh.Arrange(new Rect(left, top, circleSize, circleSize));
            return finalSize;
        }
        #endregion
        #region - Binding Methods -
        // Thumb 요소를 빌드하는 메서드입니다.
        private void BuildAdornerCorner(ref Thumb thumb, Cursor customizedCursor, DragDeltaEventHandler dragDeltaCallback)
        {
            // 이미 Thumb 요소가 존재하면 메서드를 종료합니다.
            if (thumb != null) return;

            // Thumb 요소를 생성합니다.
            thumb = new Thumb
            {
                Cursor = customizedCursor, // 사용자 지정 커서를 설정합니다.
                
            };

            // DragDelta 이벤트 핸들러를 등록합니다.
            thumb.DragDelta += dragDeltaCallback;

            // VisiualCollection에 추가합니다.
            visualCollection.Add(thumb);
        }
        #endregion
        #region - Processes -
        private void Circle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = Mouse.GetPosition(this);
            endPoint = startPoint;
        }

        private void Circle_MouseUp(object sender, MouseButtonEventArgs e)
        {
            startPoint = new Point(0, 0);
            endPoint = new Point(0, 0);
        }

        private void Circle_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                endPoint = Mouse.GetPosition(this);

                // 회전을 위한 RotateTransform을 만듭니다.
                RotateTransform rotateTransform = new RotateTransform(GetAngle(), AdornedElement.RenderSize.Width / 2, AdornedElement.RenderSize.Height / 2);

                // AdornedElement의 RenderTransform을 변경하여 회전합니다.
                AdornedElement.RenderTransform = rotateTransform;
            }
        }

        private void circleTh_DragDelta(object sender, DragDeltaEventArgs e)
        {

            Debug.WriteLine($"{e.VerticalChange} / {e.HorizontalChange}");
            RotateTransform rotateTransform;
            // 회전을 위한 RotateTransform을 만듭니다.
            if (e.HorizontalChange >= e.VerticalChange)
            {
                rotateTransform = new RotateTransform(e.HorizontalChange, AdornedElement.RenderSize.Width / 2, AdornedElement.RenderSize.Height / 2);
            }
            else
            {
                rotateTransform = new RotateTransform(e.VerticalChange, AdornedElement.RenderSize.Width / 2, AdornedElement.RenderSize.Height / 2);
            }
            

            // AdornedElement의 RenderTransform을 변경하여 회전합니다.
            AdornedElement.RenderTransform = rotateTransform;
        }
        
        private double GetAngle()
        {
            // 시작 점과 끝 점으로 벡터를 만들고, 두 벡터의 각도를 구합니다.
            Vector startVector = new Vector(startPoint.X - (AdornedElement.RenderSize.Width / 2), startPoint.Y - (AdornedElement.RenderSize.Height / 2));
            Vector endVector = new Vector(endPoint.X - (AdornedElement.RenderSize.Width / 2), endPoint.Y - (AdornedElement.RenderSize.Height / 2));
            double angle = Vector.AngleBetween(startVector, endVector);
            
            // 회전 방향을 결정합니다.
            Point centerPoint = new Point(AdornedElement.RenderSize.Width / 2, AdornedElement.RenderSize.Height / 2);
            Vector vector = Point.Subtract(endPoint, centerPoint);
            
            if (vector.Y < 0)
            {
                angle = -angle;
            }

            return angle;
        }
        #endregion
        #region - IHanldes -
        #endregion
        #region - Properties -
        #endregion
        #region - Attributes -
        private Thumb circleTh;
        private const double circleSize = 16;

        private readonly VisualCollection visualCollection;
        private Point startPoint;
        private Point endPoint;

       
        #endregion
    }
}
