using Caliburn.Micro;
using System;
using System.Windows;
using Wpf.AdornerProject.Sample.Events;
using Wpf.AdornerProject.Sample.ViewModels.Properties;

namespace Wpf.AdornerProject.Sample.ViewModels.Elements
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 4/12/2023 9:40:48 AM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class SymbolViewModel : SymbolBaseViewModel, ISymbolViewModel
    {
        #region - Ctors -
        #endregion
        #region - Implementation of Interface -
        #endregion
        #region - Overrides -
        public override void Dispose()
        {
            _model = null;
            GC.Collect();
        }
        public override async void OnClickEdit(object sender, RoutedEventArgs args)
        {
            var vm = IoC.Get<PropertyControlViewModel>();
            vm.InsertModel(this);
            IsEditable = true;

            await _eventAggregator.PublishOnUIThreadAsync(new EditShapeMessage(IsEditable, this));
        }

        public override async void OnClickExit(object sender, RoutedEventArgs args)
        {
            var vm = IoC.Get<PropertyControlViewModel>();
            vm.ClearModel(this);
            IsEditable = false;

            await _eventAggregator.PublishOnUIThreadAsync(new EditShapeMessage(IsEditable, this));
        }

        public override async void OnClickDelete(object sender, RoutedEventArgs args)
        {
            if (IsEditable)
            {
                var vm = IoC.Get<PropertyControlViewModel>();
                vm.ClearModel(this);
                IsEditable = false;
                await _eventAggregator.PublishOnUIThreadAsync(new EditShapeMessage(IsEditable, this));
            }

            await _eventAggregator.PublishOnUIThreadAsync(new DeleteShapeMessage(this));
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
