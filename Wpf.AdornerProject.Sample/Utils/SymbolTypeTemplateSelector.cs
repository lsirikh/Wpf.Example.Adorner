using System.Windows;
using System.Windows.Controls;
using Wpf.AdornerProject.Sample.ViewModels.Elements;

namespace Wpf.AdornerProject.Sample.Utils
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 4/11/2023 4:36:21 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class SymbolTypeTemplateSelector : DataTemplateSelector
    {

        #region - Ctors -
        #endregion
        #region - Implementation of Interface -
        #endregion
        #region - Overrides -
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is TextInfoViewModel)
                return SymbolTemplate;
            else if(item is ShapeViewModel)
                return ShapeTemplate;
            else
                return null;
        }
        #endregion
        #region - Binding Methods -
        #endregion
        #region - Processes -
        #endregion
        #region - IHanldes -
        #endregion
        #region - Properties -
        public DataTemplate SymbolTemplate { get; set; }
        public DataTemplate ShapeTemplate { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}
