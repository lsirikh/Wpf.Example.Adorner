using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace Wpf.Example.OnCavas.RotateAdorner
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 3/29/2023 10:13:13 AM                                                    
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

            _element = adornedElement;
            _thumb = new Thumb { Cursor = System.Windows.Input.Cursors.Hand }; // Thumb 생성 및 커서 설정
            _thumb.DragDelta += Thumb_DragDelta; // Thumb의 DragDelta 이벤트 처리기 등록

            // 기존의 RenderTransform에 RotateTransform이 있는지 확인하고, 없다면 새로 생성
            _rotateTransform = adornedElement.RenderTransform as RotateTransform;
            if (_rotateTransform == null)
            {
                _rotateTransform = new RotateTransform();
                _element.RenderTransform = _rotateTransform;
                _element.RenderTransformOrigin = new Point(0.5, 0.5); // 중심 축을 설정
            }

            _previousAngle = _rotateTransform.Angle;
            // Adorner Rectangle 입니다.
            Rec = new Rectangle() { Stroke = Brushes.Coral, StrokeThickness = 2, StrokeDashArray = { 3, 2 } };
           
            _rec_rotateTransform = Rec.RenderTransform as RotateTransform;
            if (_rec_rotateTransform == null)
            {
                _rec_rotateTransform = new RotateTransform();
                Rec.RenderTransform = _rec_rotateTransform;
                Rec.RenderTransformOrigin = new Point(0.5, 0.5); // 중심 축을 설정
            }
            

            visualCollection.Add(_thumb);
            visualCollection.Add(Rec);

            // AdornerLayer에 Thumb 추가
            //AddVisualChild(_thumb);
        }
        #endregion
        #region - Implementation of Interface -
        #endregion
        #region - Overrides -
        // 새로운 위치로 Thumb를 옮깁니다.
        protected override Size ArrangeOverride(Size finalSize)
        {

            // visualCollection에 포함된 Thumb 요소의 위치를 조정합니다.
            var rectWidth = AdornedElement.DesiredSize.Width + RECT_MARGIN * 2;
            var rectHeight = AdornedElement.DesiredSize.Height + RECT_MARGIN * 2;

            Rec.Arrange(new Rect(-RECT_MARGIN, -RECT_MARGIN, rectWidth, rectHeight));


            _thumb.Arrange(new Rect(new Point((AdornedElement.DesiredSize.Width - 10) / 2, -20), _thumb.DesiredSize));
            
            _centerPoint = new Point(AdornedElement.DesiredSize.Width / 2, AdornedElement.DesiredSize.Height / 2);

            Debug.WriteLine($"{_currentAngle}");

            
            return finalSize;
        }

        protected override int VisualChildrenCount => visualCollection.Count;

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);

            if(e.LeftButton == MouseButtonState.Pressed)
            {
                _startPoint = Mouse.GetPosition(this);
            }

        }

        protected override Visual GetVisualChild(int index) => visualCollection[index];
        #endregion
        #region - Binding Methods -
        #endregion
        #region - Processes -
        // Thumb의 드래그 이벤트 처리기입니다.
        private void Thumb_DragDelta(object sender, DragDeltaEventArgs e)
        {

            var currentPosition = Mouse.GetPosition(this);
            var diff = currentPosition - _centerPoint;

            _rec_rotateTransform.Angle = _previousAngle;
            // 두 점 사이의 각도를 계산합니다.
            _currentAngle = Math.Atan2(diff.Y, diff.X) * (180 / Math.PI);

            // 회전 각도를 설정합니다.
            _rotateTransform.Angle = _currentAngle;
            _rec_rotateTransform.Angle = _currentAngle;

            Debug.WriteLine($"Thumb_DragDelta - {_currentAngle}");
        }
        #endregion
        #region - IHanldes -
        #endregion
        #region - Properties -
        #endregion
        #region - Attributes -
        private Rectangle Rec; // Adorner 영역을 잡아주는 사각형입니다.
        private VisualCollection visualCollection;

        private readonly RotateTransform _rotateTransform;
        private readonly RotateTransform _rec_rotateTransform;
        private readonly UIElement _element;
        private readonly Thumb _thumb;

        private double _previousAngle;
        private double _currentAngle;
        private Point _startPoint;
        private Point _centerPoint;

        //Const Element
        const double RECT_MARGIN = 2.5;
        const double MIN_SIZE = 2;
        #endregion
    }
}
