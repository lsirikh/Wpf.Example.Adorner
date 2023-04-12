using Caliburn.Micro;
using Wpf.AdornerProject.Sample.Models;

namespace Wpf.AdornerProject.Sample.ViewModels.Elements
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 4/7/2023 2:31:29 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class RectangleShapeViewModel : ShapeViewModel
    {

        #region - Ctors -
        public RectangleShapeViewModel(ShapePropertyModel model)
        {
            _model = model;
            _eventAggregator = IoC.Get<IEventAggregator>();
        }
        #endregion
        #region - Implementation of Interface -
        #endregion
        #region - Overrides -
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
