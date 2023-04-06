using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Wpf.AdornerProject.Sample.Behaviors
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 4/3/2023 5:46:46 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class SelectionShapeBehavior : Behavior<ContentControl>
    {

        #region - Ctors -
        public SelectionShapeBehavior()
        {

        }
        #endregion
        #region - Implementation of Interface -
        #endregion
        #region - Overrides -
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.MouseLeftButtonDown += OnShapeClick;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.MouseLeftButtonDown -= OnShapeClick;
            base.OnDetaching();
        }

        private void OnShapeClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2) // Check for double-click
            {
                ContentControl contentControl = sender as ContentControl;
                if (contentControl != null)
                {
                    bool currentSelection = Selector.GetIsSelected(contentControl);
                    Selector.SetIsSelected(contentControl, !currentSelection);

                    //ToggleIsHitTestVisible(contentControl);
                }
            }
        }

        private void ToggleIsHitTestVisible(DependencyObject parent)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (child is Shape element)
                {
                    element.IsHitTestVisible = !element.IsHitTestVisible;
                }

                ToggleIsHitTestVisible(child);
            }
        }
        #endregion
        #region - Binding Methods -
        #endregion
        #region - Processes -
        #endregion
        #region - IHanldes -
        #endregion
        #region - Properties -
        #endregion
        #region - Attributes -
        #endregion
    }
}
