using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Wpf.Example.Adorner
{
    #region Deprecated Code
    //public class ResizeAdorner : System.Windows.Documents.Adorner
    //{

    //    VisualCollection AdornerVisuals;

    //    Thumb thLT, thLC, thLB, thRT, thRC, thRB, thCT, thCB;

    //    Rectangle Rec;

    //    public bool IsActive;
    //    public ResizeAdorner(UIElement adornedElement) : base(adornedElement)
    //    {

    //        AdornerVisuals = new VisualCollection(this);

    //        thLT = new Thumb() { Background = Brushes.Coral, Height = 10, Width = 10 };
    //        thLC = new Thumb() { Background = Brushes.Coral, Height = 10, Width = 10 };
    //        thLB = new Thumb() { Background = Brushes.Coral, Height = 10, Width = 10 };
    //        thRT = new Thumb() { Background = Brushes.Coral, Height = 10, Width = 10 };
    //        thRC = new Thumb() { Background = Brushes.Coral, Height = 10, Width = 10 };
    //        thRB = new Thumb() { Background = Brushes.Coral, Height = 10, Width = 10 };
    //        thCT = new Thumb() { Background = Brushes.Coral, Height = 10, Width = 10 };
    //        thCB = new Thumb() { Background = Brushes.Coral, Height = 10, Width = 10 };

    //        thLT.MouseMove += ThLT_MouseMove;
    //        Rec = new Rectangle() { Stroke = Brushes.Coral, StrokeThickness = 2, StrokeDashArray = { 3, 2 } };

    //        thLT.DragDelta += Thumb1_DragDelta;
    //        thRB.DragDelta += Thumb2_DragDelta;

    //        AdornerVisuals.Add(Rec); 
    //        AdornerVisuals.Add(thLT);
    //        AdornerVisuals.Add(thLC);
    //        AdornerVisuals.Add(thLB);
    //        AdornerVisuals.Add(thRT); 
    //        AdornerVisuals.Add(thRC); 
    //        AdornerVisuals.Add(thRB); 
    //        AdornerVisuals.Add(thCT); 
    //        AdornerVisuals.Add(thCB); 

    //    }

    //    private void ThLT_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
    //    {
    //        if (!e.Handled)
    //            e.Handled = true;

    //        //Cursors.SizeNWSE
    //    }

    //    private void Thumb1_DragDelta(object sender, DragDeltaEventArgs e)
    //    {
    //        if (!IsActive)
    //            return;
    //        //Debug.WriteLine($"{e.VerticalChange}, {e.HorizontalChange}");
    //        var element = (FrameworkElement)AdornedElement;
    //        element.Height = element.Height - e.VerticalChange < 0 ? 0 : element.Height - e.VerticalChange;
    //        element.Width = element.Width - e.HorizontalChange < 0 ? 0 : element.Width - e.HorizontalChange;
    //    }

    //    private void Thumb2_DragDelta(object sender, DragDeltaEventArgs e)
    //    {
    //        if (!IsActive)
    //            return;
    //        //Debug.WriteLine($"{e.VerticalChange}, {e.HorizontalChange}");
    //        var element = (FrameworkElement)AdornedElement;
    //        element.Height = element.Height + e.VerticalChange < 0 ? 0 : element.Height + e.VerticalChange;
    //        element.Width = element.Width + e.HorizontalChange < 0 ? 0 : element.Width + e.HorizontalChange;
    //    }

    //    protected override Visual GetVisualChild(int index)
    //    {
    //        //return base.GetVisualChild(index);
    //        return AdornerVisuals[index];
    //    }

    //    protected override int VisualChildrenCount => AdornerVisuals.Count;

    //    protected override Size ArrangeOverride(Size finalSize)
    //    {
    //        ///Adorner 구성요소 Rearrange Configuration
    //        ///
    //        Rec.Arrange(new Rect(-2.5, -2.5, AdornedElement.DesiredSize.Width + 5, AdornedElement.DesiredSize.Height + 5));

    //        thLT.Arrange(new Rect(-5, -5, 10, 10));
    //        thLC.Arrange(new Rect(-5, AdornedElement.DesiredSize.Height/2 - 5, 10, 10));
    //        thLB.Arrange(new Rect(-5, AdornedElement.DesiredSize.Height - 5, 10, 10));

    //        thRT.Arrange(new Rect(AdornedElement.DesiredSize.Width - 5, -5, 10, 10));
    //        thRC.Arrange(new Rect(AdornedElement.DesiredSize.Width - 5, AdornedElement.DesiredSize.Height/2 - 5, 10, 10));
    //        thRB.Arrange(new Rect(AdornedElement.DesiredSize.Width - 5, AdornedElement.DesiredSize.Height - 5, 10, 10));

    //        thCT.Arrange(new Rect(AdornedElement.DesiredSize.Width / 2 - 5, -5, 10, 10));
    //        thCB.Arrange(new Rect(AdornedElement.DesiredSize.Width / 2 - 5, AdornedElement.DesiredSize.Height - 5, 10, 10));

    //        return base.ArrangeOverride(finalSize);
    //    }
    //}

    #endregion


    // Adorner를 사용하여 UIElement의 사각형 크기를 조정하는 클래스입니다.
    public class ResizeAdorner : System.Windows.Documents.Adorner, IDisposable
    {
        //Const Element
        const double RECT_MARGIN = 2.5;
        
        private VisualCollection visualCollection; // Adorner의 하위 요소를 저장하는 VisualCollection입니다.
        //private Thumb bottomRight; // 오른쪽 아래 모서리의 Thumb 요소입니다.

        private Thumb thLT, thLC, thLB, thRT, thRC, thRB, thCT, thCB; // 각 부분에 해당하는 Thumb Element입니다.

        private Rectangle Rec; // Adorner 영역을 잡아주는 사각형입니다.

        // 생성자입니다.
        public ResizeAdorner(UIElement adornedElement) : base(adornedElement)
        {
            // VisualCollection을 초기화합니다.
            visualCollection = new VisualCollection(this);

            // Left Top Thumb 요소를 빌드합니다.
            BuildAdornerCorner(ref thLT, Cursors.SizeNWSE, new DragDeltaEventHandler(thLT_DragDelta));

            // Left Center Thumb 요소를 빌드합니다.
            BuildAdornerCorner(ref thLC, Cursors.SizeWE, new DragDeltaEventHandler(thLC_DragDelta));

            // Left Bottom Thumb 요소를 빌드합니다.
            BuildAdornerCorner(ref thLB, Cursors.SizeNESW, new DragDeltaEventHandler(thLB_DragDelta));

            // Right Top Thumb 요소를 빌드합니다.
            BuildAdornerCorner(ref thRT, Cursors.SizeNESW, new DragDeltaEventHandler(thRT_DragDelta));

            // Right Center Thumb 요소를 빌드합니다.
            BuildAdornerCorner(ref thRC, Cursors.SizeWE, new DragDeltaEventHandler(thRC_DragDelta));

            // Right Bottom Thumb 요소를 빌드합니다.
            BuildAdornerCorner(ref thRB, Cursors.SizeNWSE, new DragDeltaEventHandler(thRB_DragDelta));

            // Top Center Thumb 요소를 빌드합니다.
            BuildAdornerCorner(ref thCT, Cursors.SizeNS, new DragDeltaEventHandler(thCT_DragDelta));
            
            // Bottom Center Thumb 요소를 빌드합니다.
            BuildAdornerCorner(ref thCB, Cursors.SizeNS, new DragDeltaEventHandler(thCB_DragDelta));


            // Adorner Rectangle 입니다.
            Rec = new Rectangle() { Stroke = Brushes.Coral, StrokeThickness = 2, StrokeDashArray = { 3, 2 } };

            // BottomRight Thumb 요소를 visualCollection에 추가합니다.
            visualCollection.Add(Rec);
            visualCollection.Add(thLT);
            visualCollection.Add(thLC);
            visualCollection.Add(thLB);
            visualCollection.Add(thRT);
            visualCollection.Add(thRC);
            visualCollection.Add(thRB);
            visualCollection.Add(thCT);
            visualCollection.Add(thCB);

            // Adorner의 히트 테스트를 허용합니다.
            this.IsHitTestVisible = true;
        }

        


        // Thumb 요소를 빌드하는 메서드입니다.
        private void BuildAdornerCorner(ref Thumb cornerThumb, Cursor customizedCursor, DragDeltaEventHandler dragDeltaCallback)
        {
            // 이미 Thumb 요소가 존재하면 메서드를 종료합니다.
            if (cornerThumb != null) return;

            // Thumb 요소를 생성합니다.
            cornerThumb = new Thumb
            {
                Cursor = customizedCursor, // 사용자 지정 커서를 설정합니다.
                //Height = 10, // Thumb 요소의 높이를 설정합니다.
                //Width = 10, // Thumb 요소의 너비를 설정합니다.
                //Opacity = 0.5, // Thumb 요소의 불투명도를 설정합니다.
                //Background = Brushes.Black, // Thumb 요소의 배경을 검정색으로 설정합니다.
                //BorderBrush = Brushes.White, // Thumb 요소의 테두리를 흰색으로 설정합니다.
                //BorderThickness = new Thickness(1), // Thumb 요소의 테두리 두께를 설정합니다.
                //Style = (Style)Application.Current.Resources["ThumbStyle"] // Thumb 요소의 스타일을 설정합니다.
            };

            // DragDelta 이벤트 핸들러를 등록합니다.
            cornerThumb.DragDelta += dragDeltaCallback;
        }

        private void thLT_DragDelta(object sender, DragDeltaEventArgs e)
        {
            // AdornedElement를 FrameworkElement로 캐스팅합니다.
            FrameworkElement adornedElement = this.AdornedElement as FrameworkElement;

            // FrameworkElement가 null이 아닌 경우
            if (adornedElement != null)
            {
                // FrameworkElement의 ActualWidth 및 ActualHeight 속성을 사용하여 너비와 높이를 조정합니다.
                adornedElement.Height = adornedElement.Height - e.VerticalChange < 0 ? 0 : adornedElement.Height -e.VerticalChange;
                adornedElement.Width = adornedElement.Width - e.HorizontalChange < 0 ? 0 : adornedElement.Width - e.HorizontalChange;
            }
        }

        private void thLC_DragDelta(object sender, DragDeltaEventArgs e)
        {
            // AdornedElement를 FrameworkElement로 캐스팅합니다.
            FrameworkElement adornedElement = this.AdornedElement as FrameworkElement;

            // FrameworkElement가 null이 아닌 경우
            if (adornedElement != null)
            {
                // FrameworkElement의 ActualWidth 및 ActualHeight 속성을 사용하여 너비와 높이를 조정합니다.
                adornedElement.Width = adornedElement.Width - e.HorizontalChange < 0 ? 0 : adornedElement.Width - e.HorizontalChange;
            }
        }

        private void thLB_DragDelta(object sender, DragDeltaEventArgs e)
        {
            // AdornedElement를 FrameworkElement로 캐스팅합니다.
            FrameworkElement adornedElement = this.AdornedElement as FrameworkElement;

            // FrameworkElement가 null이 아닌 경우
            if (adornedElement != null)
            {
                // FrameworkElement의 ActualWidth 및 ActualHeight 속성을 사용하여 너비와 높이를 조정합니다.
                adornedElement.Height = adornedElement.Height + e.VerticalChange < 0 ? 0 : adornedElement.Height + e.VerticalChange;
                adornedElement.Width = adornedElement.Width - e.HorizontalChange < 0 ? 0 : adornedElement.Width - e.HorizontalChange;
            }
        }

        private void thRT_DragDelta(object sender, DragDeltaEventArgs e)
        {
            // AdornedElement를 FrameworkElement로 캐스팅합니다.
            FrameworkElement adornedElement = this.AdornedElement as FrameworkElement;

            // FrameworkElement가 null이 아닌 경우
            if (adornedElement != null)
            {
                // FrameworkElement의 ActualWidth 및 ActualHeight 속성을 사용하여 너비와 높이를 조정합니다.
                adornedElement.Height = adornedElement.Height - e.VerticalChange < 0 ? 0 : adornedElement.Height - e.VerticalChange;
                adornedElement.Width = adornedElement.Width + e.HorizontalChange < 0 ? 0 : adornedElement.Width + e.HorizontalChange;
            }
        }

        private void thRC_DragDelta(object sender, DragDeltaEventArgs e)
        {
            // AdornedElement를 FrameworkElement로 캐스팅합니다.
            FrameworkElement adornedElement = this.AdornedElement as FrameworkElement;

            // FrameworkElement가 null이 아닌 경우
            if (adornedElement != null)
            {
                
                adornedElement.Width = adornedElement.Width + e.HorizontalChange < 0 ? 0 : adornedElement.Width + e.HorizontalChange;
            }
        }

        // BottomRight Thumb 요소의 DragDelta 이벤트 핸들러입니다.
        private void thRB_DragDelta(object sender, DragDeltaEventArgs e)
        {
            // AdornedElement를 FrameworkElement로 캐스팅합니다.
            FrameworkElement adornedElement = this.AdornedElement as FrameworkElement;

            // FrameworkElement가 null이 아닌 경우
            if (adornedElement != null)
            {
                // FrameworkElement의 ActualWidth 및 ActualHeight 속성을 사용하여 너비와 높이를 조정합니다.
                adornedElement.Height = adornedElement.Height + e.VerticalChange < 0 ? 0 : adornedElement.Height + e.VerticalChange;
                adornedElement.Width = adornedElement.Width + e.HorizontalChange < 0 ? 0 : adornedElement.Width + e.HorizontalChange;
            }
        }

        private void thCT_DragDelta(object sender, DragDeltaEventArgs e)
        {
            // AdornedElement를 FrameworkElement로 캐스팅합니다.
            FrameworkElement adornedElement = this.AdornedElement as FrameworkElement;

            // FrameworkElement가 null이 아닌 경우
            if (adornedElement != null)
            {
                // FrameworkElement의 ActualWidth 및 ActualHeight 속성을 사용하여 너비와 높이를 조정합니다.
                adornedElement.Height = adornedElement.Height - e.VerticalChange < 0 ? 0 : adornedElement.Height - e.VerticalChange;

            }
        }

        private void thCB_DragDelta(object sender, DragDeltaEventArgs e)
        {
            // AdornedElement를 FrameworkElement로 캐스팅합니다.
            FrameworkElement adornedElement = this.AdornedElement as FrameworkElement;

            // FrameworkElement가 null이 아닌 경우
            if (adornedElement != null)
            {
                // FrameworkElement의 ActualWidth 및 ActualHeight 속성을 사용하여 너비와 높이를 조정합니다.
                adornedElement.Height = adornedElement.Height + e.VerticalChange < 0 ? 0 : adornedElement.Height + e.VerticalChange;
               
            }
        }

        // Adorner의 하위 요소를 반환하는 메서드
        protected override int VisualChildrenCount
        {
            get { return visualCollection.Count; }
        }

        // Adorner의 특정 인덱스에 있는 하위 요소를 반환하는 메서드입니다.
        protected override Visual GetVisualChild(int index)
        {
            return visualCollection[index];
        }

        //// Adorner의 측정된 크기를 반환하는 메서드입니다.
        //protected override Size MeasureOverride(Size constraint)
        //{
        //    // visualCollection에 포함된 Thumb 요소의 크기를 측정합니다.
        //    thRB.Measure(constraint);

        //    // visualCollection에 포함된 Thumb 요소의 측정된 크기를 반환합니다.
        //    return thRB.DesiredSize;
        //}

        // Adorner의 레이아웃을 업데이트하는 메서드입니다.
        protected override Size ArrangeOverride(Size finalSize)
        {
            // visualCollection에 포함된 Thumb 요소의 위치를 조정합니다.
            //bottomRight.Arrange(new Rect(finalSize));
            //bottomRight.Arrange(new Rect(-5, -5, 10, 10));
            Rec.Arrange(new Rect(-RECT_MARGIN, -RECT_MARGIN, AdornedElement.DesiredSize.Width + RECT_MARGIN * 2, AdornedElement.DesiredSize.Height + RECT_MARGIN * 2));

            thLT.Arrange(new Rect(-((thLT.Width + RECT_MARGIN) / 2), -((thLT.Height + RECT_MARGIN) / 2), thLT.Width, thLT.Height));
            thLC.Arrange(new Rect(-((thLT.Width + RECT_MARGIN) / 2), AdornedElement.DesiredSize.Height / 2 - RECT_MARGIN * 2, thLC.Width, thLC.Height));
            thLB.Arrange(new Rect(-((thLT.Width + RECT_MARGIN) / 2), AdornedElement.DesiredSize.Height - RECT_MARGIN, thLB.Width, thLB.Height));
            
            thRT.Arrange(new Rect(AdornedElement.DesiredSize.Width - RECT_MARGIN, -((thLT.Height + RECT_MARGIN) / 2), thRT.Width, thRT.Height));
            thRC.Arrange(new Rect(AdornedElement.DesiredSize.Width - RECT_MARGIN, AdornedElement.DesiredSize.Height / 2 - RECT_MARGIN * 2, thRC.Width, thRC.Height));
            thRB.Arrange(new Rect(AdornedElement.DesiredSize.Width - RECT_MARGIN, AdornedElement.DesiredSize.Height - RECT_MARGIN, thRB.Width, thRB.Height));
            
            thCT.Arrange(new Rect(AdornedElement.DesiredSize.Width / 2 - RECT_MARGIN * 2, -((thLT.Height + RECT_MARGIN) / 2), thCT.Width, thCT.Height));
            thCB.Arrange(new Rect(AdornedElement.DesiredSize.Width / 2 - RECT_MARGIN * 2, AdornedElement.DesiredSize.Height - RECT_MARGIN, thCB.Width, thCB.Height));
            // visualCollection에 포함된 Thumb 요소의 최종 크기를 반환합니다.
            return finalSize;
        }

        public void Dispose()
        {
            thLT.DragDelta -= thLT_DragDelta;
            thLC.DragDelta -= thLC_DragDelta;
            thLB.DragDelta -= thLB_DragDelta;
            thRT.DragDelta -= thRT_DragDelta;
            thRC.DragDelta -= thRC_DragDelta;
            thRB.DragDelta -= thRB_DragDelta;
            thCT.DragDelta -= thCT_DragDelta;
            thCB.DragDelta -= thCB_DragDelta;

            visualCollection.Clear();

            thLT = null; thLC = null; thLB = null; 
            thRT = null; thRC = null; thRB = null; 
            thCT = null; thCB = null;

            Rec = null;
        }
    }
}
