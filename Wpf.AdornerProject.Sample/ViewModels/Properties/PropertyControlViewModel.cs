using Caliburn.Micro;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using Wpf.AdornerProject.Sample.Events;
using Wpf.AdornerProject.Sample.Models;
using Wpf.AdornerProject.Sample.Providers;
using Wpf.AdornerProject.Sample.ViewModels.Elements;

namespace Wpf.AdornerProject.Sample.ViewModels.Properties
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 4/4/2023 2:45:16 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class PropertyControlViewModel : Screen
        ,IHandle<EditShapeMessage>
    {
        #region - Ctors -
        public PropertyControlViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }
        #endregion
        #region - Implementation of Interface -
        public Task HandleAsync(EditShapeMessage message, CancellationToken cancellationToken)
        {
            if (message.IsEditable)
            {
                IsEnable = true;
            }
            else
            {
                IsEnable = false;
            }
            return Task.CompletedTask;
        }
        #endregion
        #region - Overrides -
        protected override Task OnActivateAsync(CancellationToken cancellationToken)
        {
            Model = new ShapeBaseViewModel();
            _eventAggregator.SubscribeOnUIThread(this);
            return base.OnActivateAsync(cancellationToken);
        }
        protected override Task OnDeactivateAsync(bool close, CancellationToken cancellationToken)
        {
            _eventAggregator.Unsubscribe(this);
            return base.OnDeactivateAsync(close, cancellationToken);
        }
        #endregion
        #region - Binding Methods -
        #endregion
        #region - Processes -
        public void InsertModel(ShapeBaseViewModel model)
        {
            Model = model;
            Debug.WriteLine($"PropertyControlViewModel Hash : {Model.GetHashCode()} ");
            Refresh();
        }

        public void ClearModel()
        {
            Model = new ShapeBaseViewModel();
        }

        
        #endregion
        #region - IHanldes -
        #endregion
        #region - Properties -

        public ShapeBaseViewModel Model
        {
            get { return _model; }
            set 
            {
                _model = value; 
                NotifyOfPropertyChange(() => Model);
            }
        }

        public bool IsEnable
        {
            get { return _isEnable; }
            set { _isEnable = value; NotifyOfPropertyChange(() => IsEnable); }
        }

        #endregion
        #region - Attributes -
        private bool _isEnable;
        private ShapeBaseViewModel _model;
        private IEventAggregator _eventAggregator;
        #endregion
    }
}
