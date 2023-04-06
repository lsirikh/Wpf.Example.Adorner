using Microsoft.Xaml.Behaviors;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace Wpf.AdornerProject.Sample.Behaviors
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 4/4/2023 10:19:23 AM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class MoveShapeBehavior : Behavior<ContentControl>
    {

        #region - Ctors -
        public MoveShapeBehavior()
        {

        }
        #endregion
        #region - Implementation of Interface -
        #endregion
        #region - Overrides -
        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.MouseEnter += OnMouseEnter;
            AssociatedObject.MouseLeave += OnMouseLeave;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.MouseEnter -= OnMouseEnter;
            AssociatedObject.MouseLeave -= OnMouseLeave;
        }


        #endregion
        #region - Binding Methods -
        #endregion
        #region - Processes -
        //private void OnMouseMove(object sender, MouseEventArgs e)
        //{
        //    if (!(e.Source is ContentControl contentControl))
        //        return;


        //    if (e.LeftButton == MouseButtonState.Pressed)
        //    {
        //        var currentPosition = e.GetPosition(AssociatedObject);
        //        var delta = currentPosition - _previousMousePosition;
        //        _previousMousePosition = currentPosition;

        //        Canvas.SetLeft(contentControl, Canvas.GetLeft(contentControl) + delta.X);
        //        Canvas.SetTop(contentControl, Canvas.GetTop(contentControl) + delta.Y);
        //    }
        //}

        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            Debug.WriteLine($"{e.Source}");
            if (!(e.Source is ContentControl contentControl))
                return;

            if (contentControl.IsMouseOver)
            {
                Mouse.OverrideCursor = Cursors.SizeAll;
            }
        }

        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            Mouse.OverrideCursor = null;
        }
        #endregion
        #region - IHanldes -
        #endregion
        #region - Properties -
        #endregion
        #region - Attributes -
        private Point _previousMousePosition;
        #endregion
    }
}
