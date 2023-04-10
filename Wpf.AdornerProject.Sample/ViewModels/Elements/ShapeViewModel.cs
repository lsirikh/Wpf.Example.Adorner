using Caliburn.Micro;
using System;
using System.Windows;
using Wpf.AdornerProject.Sample.Events;
using Wpf.AdornerProject.Sample.Models;
using Wpf.AdornerProject.Sample.ViewModels.Properties;

namespace Wpf.AdornerProject.Sample.ViewModels.Elements
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 4/7/2023 1:55:14 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class ShapeViewModel : ShapeBaseViewModel, IShapeViewModel, IDisposable
    {

        #region - Ctors -
        public ShapeViewModel()
        {
            _model = new PropertyModel();
        }
        #endregion
        #region - Implementation of Interface -
        public virtual void Dispose()
        {
            _model = null;
            GC.Collect();
        }
        #endregion
        #region - Overrides -
        #endregion
        #region - Binding Methods -
        #endregion
        #region - Processes -
        public virtual async void OnClickEdit(object sender, RoutedEventArgs args)
        {
            var vm = IoC.Get<PropertyControlViewModel>();
            vm.InsertModel(this);
            IsEditable = true;

            await _eventAggregator.PublishOnUIThreadAsync(new EditShapeMessage(IsEditable, this));
        }

        public virtual async void OnClickExit(object sender, RoutedEventArgs args)
        {
            var vm = IoC.Get<PropertyControlViewModel>();
            vm.ClearModel();
            IsEditable = false;

            await _eventAggregator.PublishOnUIThreadAsync(new EditShapeMessage(IsEditable, this));
        }

        public virtual async void OnClickDelete(object sender, RoutedEventArgs args)
        {
            if (IsEditable)
            {
                var vm = IoC.Get<PropertyControlViewModel>();
                vm.ClearModel();
                IsEditable = false;
                await _eventAggregator.PublishOnUIThreadAsync(new EditShapeMessage(IsEditable, this));
            }

            await _eventAggregator.PublishOnUIThreadAsync(new DeleteShapeMessage(this));
        }
        #endregion
        #region - IHanldes -
        #endregion
        #region - Properties -
        public bool IsEditable
        {
            get { return _isEditable; }
            set
            {
                _isEditable = value;
                NotifyOfPropertyChange(() => IsEditable);
            }
        }

        public bool OnEditable
        {
            get { return _onEditable; }
            set
            {
                _onEditable = value;
                NotifyOfPropertyChange(() => OnEditable);
            }
        }
        #endregion
        #region - Attributes -
        private bool _onEditable;
        private bool _isEditable;
        protected IEventAggregator _eventAggregator;

        
        #endregion
    }
}
