using Caliburn.Micro;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using Wpf.AdornerProject.Sample.Events;
using Wpf.AdornerProject.Sample.Models;
using Wpf.AdornerProject.Sample.ViewModels.Properties;

namespace Wpf.AdornerProject.Sample.ViewModels.Elements
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 4/4/2023 11:17:43 AM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class CircleEntityViewModel : ShapeBaseViewModel
    {

        #region - Ctors -
        public CircleEntityViewModel()
        {
        }

        public CircleEntityViewModel(PropertyModel model)
        {
            _model = model;
            _eventAggregator = IoC.Get<IEventAggregator>();
        }
        #endregion
        #region - Implementation of Interface -
        #endregion
        #region - Overrides -
        protected override void OnViewAttached(object view, object context)
        {
            base.OnViewAttached(view, context);
        }
        #endregion
        #region - Binding Methods -
        #endregion
        #region - Processes -
        public async void OnClickEdit(object sender, RoutedEventArgs args)
        {
            var vm = IoC.Get<PropertyControlViewModel>();
            vm.InsertModel(this);
            IsEditable = true;

            await _eventAggregator.PublishOnUIThreadAsync(new EditShapeMessage(IsEditable, this));
        }

        public async void OnClickExit(object sender, RoutedEventArgs args)
        {
            var vm = IoC.Get<PropertyControlViewModel>();
            vm.ClearModel();
            IsEditable = false;

            await _eventAggregator.PublishOnUIThreadAsync(new EditShapeMessage(IsEditable, this));
        }
        #endregion
        #region - IHanldes -
        #endregion
        #region - Properties -
        #endregion
        #region - Attributes -
        private IEventAggregator _eventAggregator;
        #endregion
    }
}
