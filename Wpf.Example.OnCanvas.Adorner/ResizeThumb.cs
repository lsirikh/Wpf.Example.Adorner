using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Wpf.Example.OnCanvas.Adorner
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 3/27/2023 6:25:40 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class ResizeThumb : Thumb
    {

        #region - Ctors -
        public ResizeThumb()
        {
            DragDelta += ResizeThumb_DragDelta;
        }



        #endregion
        #region - Implementation of Interface -
        #endregion
        #region - Overrides -
        #endregion
        #region - Binding Methods -
        #endregion
        #region - Processes -
        private void ResizeThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            FrameworkElement element = DataContext as FrameworkElement;
            if (element != null)
            {
                double deltaX = e.HorizontalChange;
                double deltaY = e.VerticalChange;
                double newWidth = element.Width + deltaX;
                double newHeight = element.Height + deltaY;
                if (newWidth > 10 && newHeight > 10)
                {
                    element.Width = newWidth;
                    element.Height = newHeight;
                }
            }
        }
        #endregion
        #region - IHanldes -
        #endregion
        #region - Properties -
        #endregion
        #region - Attributes -
        #endregion
    }
}
