using Caliburn.Micro;
using Ironwall.Framework.ViewModels;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using Wpf.AdornerProject.Sample.Events;
using Wpf.AdornerProject.Sample.Models;
using Wpf.AdornerProject.Sample.Providers;
using Wpf.AdornerProject.Sample.ViewModels.Elements;

namespace Wpf.AdornerProject.Sample.ViewModels.Shapes
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 4/4/2023 10:41:26 AM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class ShapeCollectionViewModel : Screen
        , IHandle<EditShapeMessage>
        , IHandle<DeleteShapeMessage>
    {

        #region - Ctors -
        public ShapeCollectionViewModel(SymbolProvider provider
            , IEventAggregator eventAggregator)
        {
            SymbolProvider = provider;
            _eventAggregator = eventAggregator;
        }
        #endregion
        #region - Implementation of Interface -
        public Task HandleAsync(EditShapeMessage message, CancellationToken cancellationToken)
        {
            if (message.IsEditable)
            {
                if(_prviousViewModel != null)
                {
                    _prviousViewModel.IsEditable = false;
                }
                _prviousViewModel = message.ViewModel as ISymbolViewModel;
            }
            else
            {
                _prviousViewModel = null;
            }

            return Task.CompletedTask;
        }

        public Task HandleAsync(DeleteShapeMessage message, CancellationToken cancellationToken)
        {
            if (!(message.ViewModel is ISymbolViewModel viewModel))
                return Task.CompletedTask;

            SymbolProvider.Remove(viewModel);
            viewModel.Dispose();
            return Task.CompletedTask;
        }
        #endregion
        #region - Overrides -
        protected override Task OnActivateAsync(CancellationToken cancellationToken)
        {
            //CreateEntity();
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
        private void CreateEntity()
        {
            var vm1 = new CircleShapeViewModel(new ShapePropertyModel()
            {
                X = 200,
                Y = 100,
                Width = 80,
                Height = 80,
                Angle = 20,
                ShapeFill = "##00FFFFFF",
                ShapeStroke = "#FFFF0000",
                FontSize = 15,
                Lable = "테스트1",
                IsShowLable = true
            });
            var vm2 = new CircleShapeViewModel(new ShapePropertyModel()
            {
                X = 100,
                Y = 200,
                Width = 100,
                Height = 100,
                Angle = 0,
                ShapeFill = "#00FFFFFF",
                ShapeStroke = "#FFFF0000",
                FontSize = 15,
                Lable = "테스트2",
                IsShowLable = true
            });

            SymbolProvider.Add(vm1);
            SymbolProvider.Add(vm2);

        }

        


        #endregion
        #region - IHanldes -
        #endregion
        #region - Properties -
        public SymbolProvider SymbolProvider { get; set; }
        #endregion
        #region - Attributes -
        private IEventAggregator _eventAggregator;
        private ISymbolBaseViewModel _prviousViewModel;
        #endregion
    }
}
