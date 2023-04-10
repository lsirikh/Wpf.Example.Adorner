using Caliburn.Micro;
using Ironwall.Framework.ViewModels;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Wpf.AdornerProject.Sample.Events;
using Wpf.AdornerProject.Sample.Models;
using Wpf.AdornerProject.Sample.Providers;
using Wpf.AdornerProject.Sample.ViewModels.Elements;
using Wpf.AdornerProject.Sample.ViewModels.Properties;
using Wpf.AdornerProject.Sample.ViewModels.Shapes;

namespace Wpf.AdornerProject.Sample.ViewModels
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 4/4/2023 9:41:05 AM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public sealed class ShellViewModel : BaseShellViewModel
    {

        #region - Ctors -
        public ShellViewModel(ShapeCollectionViewModel shapeCollectionViewModel
            , PropertyControlViewModel propertyControlViewModel
            , ShapeProvider circleShapeProvider)
        {
            ShapeCollectionViewModel = shapeCollectionViewModel;
            PropertyControlViewModel = propertyControlViewModel;
            ShapeProvider = circleShapeProvider;
        }
        #endregion
        #region - Implementation of Interface -
        #endregion
        #region - Overrides -
        protected override async Task OnActivateAsync(CancellationToken cancellationToken)
        {
            await base.OnActivateAsync(cancellationToken);
            await ShapeCollectionViewModel.ActivateAsync();
            await PropertyControlViewModel.ActivateAsync();
        }

        
        #endregion
        #region - Binding Methods -
        public void OnEditShape()
        {
            IsOnEditShape = true;
            foreach (var item in ShapeProvider.ToList())
            {
                item.OnEditable = true;
            }
        }

        public async void OffEditShape()
        {
            IsOnEditShape = false;
            foreach (var item in ShapeProvider.ToList())
            {
                if (item.IsEditable)
                {
                    var vm = IoC.Get<PropertyControlViewModel>();
                    vm.ClearModel();
                    item.IsEditable = false;

                    await _eventAggregator.PublishOnUIThreadAsync(new EditShapeMessage(item.IsEditable, item));
                }
                item.OnEditable = false;
            }
        }

        public void AddCircle()
        {
            SelectedSymbol = new CircleShapeViewModel(new PropertyModel()
            {
                X = 0,
                Y = 0,
                Width = 80,
                Height = 80,
                Angle = 0,
                Stroke = "#FFFF0000",
                StrokeThickness = 2,
                Fill = "#FFFF0000",
                //ShapeWidth = 30,
                //ShapeHeight = 30,
                //LableWidth = 50,
                //LableHeight = 20,
                FontSize = 15,
                Lable = "noname",
                IsShowLable = true
            });

            int largestId = ShapeProvider.Any() ? (int)ShapeProvider.Max(s => s.Id) : 0;
            SelectedSymbol.Id = largestId + 1;
            SelectedSymbol.OnEditable = true;
            
        }

        public void AddRectangle()
        {
            SelectedSymbol = new RectangleShapeViewModel(new PropertyModel()
            {
                X = 0,
                Y = 0,
                Width = 80,
                Height = 80,
                Angle = 0,
                Stroke = "#FFFF0000",
                StrokeThickness = 2,
                Fill = "#FFFF0000",
                //ShapeWidth = 30,
                //ShapeHeight = 30,
                //LableWidth = 50,
                //LableHeight = 20,
                FontSize = 15,
                Lable = "noname",
                IsShowLable = true
            });

            int largestId = ShapeProvider.Any() ? (int)ShapeProvider.Max(s => s.Id) : 0;
            SelectedSymbol.Id = largestId + 1;
            SelectedSymbol.OnEditable = true;
        }

        public void AddTriangle()
        {

        }

        public void AddLine()
        {
            SelectedSymbol = new LineShapeViewModel(new PropertyModel()
            {
                X = 0,
                Y = 0,
                Width = 80,
                Height = 80,
                Angle = 0,
                Stroke = "#FFFF0000",
                StrokeThickness = 2,
                Fill = "#FFFF0000",
                //ShapeWidth = 30,
                //ShapeHeight = 30,
                //LableWidth = 50,
                //LableHeight = 20,
                FontSize = 15,
                Lable = "noname",
                IsShowLable = true
            });

            int largestId = ShapeProvider.Any() ? (int)ShapeProvider.Max(s => s.Id) : 0;
            SelectedSymbol.Id = largestId + 1;
            SelectedSymbol.OnEditable = true;
        }

        public void OnClickAdd(object sender, MouseButtonEventArgs e)
        {
            Point position = e.GetPosition(e.Source as IInputElement);

            if(SelectedSymbol != null)
            {

                SelectedSymbol.X = position.X;
                SelectedSymbol.Y = position.Y;
                //if (SelectedSymbol is CircleShapeViewModel circleShapeViewModel) 
                //{
                //}
                ShapeProvider.Add(SelectedSymbol);
                
            }
            SelectedSymbol = null;
        }


        public void OnClickFinish(object sender, MouseButtonEventArgs e)
        {

        }
        #endregion
        #region - Processes -

        #endregion
        #region - IHanldes -
        #endregion
        #region - Properties -
        public ShapeCollectionViewModel ShapeCollectionViewModel { get; set; }
        public PropertyControlViewModel PropertyControlViewModel { get; set; }
        public ShapeProvider ShapeProvider { get; }

        public IShapeViewModel SelectedSymbol { get; set; }
        public bool IsOnEditShape
        {
            get { return _isOnEditShape; }
            set { _isOnEditShape = value; NotifyOfPropertyChange(() => IsOnEditShape); }
        }

        #endregion
        #region - Attributes -
        private bool _isOnEditShape;
        #endregion
    }
}
