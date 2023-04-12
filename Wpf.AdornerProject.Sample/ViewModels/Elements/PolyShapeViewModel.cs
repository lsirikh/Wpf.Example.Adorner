using Caliburn.Micro;
using Ironwall.Libraries.Utils;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;
using Wpf.AdornerProject.Sample.Models;

namespace Wpf.AdornerProject.Sample.ViewModels.Elements
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 4/10/2023 4:13:05 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class PolyShapeViewModel : ShapeViewModel
    {

        #region - Ctors -
        public PolyShapeViewModel(PropertyModel model)
        {
            _model = model;
            _eventAggregator = IoC.Get<IEventAggregator>();

            _points = new PointCollection();
        }
        #endregion
        #region - Implementation of Interface -
        #endregion
        #region - Overrides -
        public override void Dispose()
        {
            base.Dispose();
            _points = null;
        }
        #endregion
        #region - Binding Methods -
        #endregion
        #region - Processes -
        #endregion
        #region - IHanldes -
        #endregion
        #region - Properties -
        public PointCollection Points
        {
            get => _points;
            set
            {
                if (_points != value)
                {
                    _points = value;
                    NotifyOfPropertyChange(()=>Points);
                }
            }
        }
        #endregion
        #region - Attributes -
        private PointCollection _points;
        #endregion
    }
}
