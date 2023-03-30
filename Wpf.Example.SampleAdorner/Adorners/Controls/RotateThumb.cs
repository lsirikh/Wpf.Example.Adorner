using System.Windows.Controls;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Input;
using System;

namespace Wpf.Example.SampleAdorner.Adorners.Controls
{
    /****************************************************************************
        Purpose      : RotateThumb 클래스는 Thumb 클래스를 상속하여 도형 회전에 사용되는 Thumb 컨트롤을 구현합니다.                                                          
        Created By   : GHLee                                                
        Created On   : 3/30/2023 1:06:37 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class RotateThumb : Thumb
    {

        #region - Ctors -
        // RotateThumb 생성자에서 이벤트 핸들러를 등록합니다.
        public RotateThumb()
        {
            DragDelta += new DragDeltaEventHandler(this.RotateThumb_DragDelta);
            DragStarted += new DragStartedEventHandler(this.RotateThumb_DragStarted);
        }
        #endregion
        #region - Implementation of Interface -
        #endregion
        #region - Overrides -
        #endregion
        #region - Binding Methods -
        #endregion
        #region - Processes -
        // 드래그가 시작되면 호출되는 메서드
        private void RotateThumb_DragStarted(object sender, DragStartedEventArgs e)
        {
            // DataContext에서 designerItem을 가져옵니다.
            this.designerItem = DataContext as ContentControl;

            if (this.designerItem != null)
            {
                // designerItem의 부모를 designerCanvas로 가져옵니다.
                this.designerCanvas = VisualTreeHelper.GetParent(this.designerItem) as Canvas;

                if (this.designerCanvas != null)
                {
                    // 회전 중심점을 계산합니다.
                    this.centerPoint = this.designerItem.TranslatePoint(
                        new Point(this.designerItem.Width * this.designerItem.RenderTransformOrigin.X,
                                  this.designerItem.Height * this.designerItem.RenderTransformOrigin.Y),
                                  this.designerCanvas);

                    // 드래그 시작점을 가져옵니다.
                    Point startPoint = Mouse.GetPosition(this.designerCanvas);
                    this.startVector = Point.Subtract(startPoint, this.centerPoint);

                    // 기존 RotateTransform을 가져오거나 새로 만듭니다.
                    this.rotateTransform = this.designerItem.RenderTransform as RotateTransform;
                    if (this.rotateTransform == null)
                    {
                        this.designerItem.RenderTransform = new RotateTransform(0);
                        this.initialAngle = 0;
                    }
                    else
                    {
                        this.initialAngle = this.rotateTransform.Angle;
                    }
                }
            }
        }

        // 드래그 중에 호출되는 메서드
        private void RotateThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            if (this.designerItem != null && this.designerCanvas != null)
            {
                // 현재 마우스 위치를 가져옵니다.
                Point currentPoint = Mouse.GetPosition(this.designerCanvas);
                Vector deltaVector = Point.Subtract(currentPoint, this.centerPoint);

                // 시작 벡터와 델타 벡터 사이의 각도를 계산합니다.
                double angle = Vector.AngleBetween(this.startVector, deltaVector);

                // RotateTransform의 각도를 업데이트하고 요소의 레이아웃을 갱신합니다.
                RotateTransform rotateTransform = this.designerItem.RenderTransform as RotateTransform;
                rotateTransform.Angle = this.initialAngle + Math.Round(angle, 0);
                this.designerItem.InvalidateMeasure();
            }
        }
        #endregion
        #region - IHanldes -
        #endregion
        #region - Properties -
        #endregion
        #region - Attributes -
        private Point centerPoint;
        private Vector startVector;
        private double initialAngle;
        private Canvas designerCanvas;
        private ContentControl designerItem;
        private RotateTransform rotateTransform;
        #endregion
    }
}
