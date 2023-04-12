using Caliburn.Micro;
using Ironwall.Framework.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
            , SymbolProvider circleShapeProvider)
        {
            ShapeCollectionViewModel = shapeCollectionViewModel;
            PropertyControlViewModel = propertyControlViewModel;
            SymbolProvider = circleShapeProvider;
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
            foreach (var item in SymbolProvider.ToList())
            {
                item.OnEditable = true;
            }
        }

        public async void OffEditShape()
        {
            IsOnEditShape = false;
            foreach (var item in SymbolProvider.ToList())
            {
                if (item.IsEditable)
                {
                    var vm = IoC.Get<PropertyControlViewModel>();
                    vm.ClearModel(item);
                    item.IsEditable = false;

                    await _eventAggregator.PublishOnUIThreadAsync(new EditShapeMessage(item.IsEditable, item));
                }
                item.OnEditable = false;
            }
        }

        public void AddCircle()
        {
            SelectedSymbol = new CircleShapeViewModel(new ShapePropertyModel()
            {
                X = 0,
                Y = 0,
                Width = 80,
                Height = 80,
                Angle = 0,
                ShapeStroke = "#FFFF0000",
                ShapeStrokeThick = 2,
                ShapeFill = "#FFFF0000",
                //ShapeWidth = 30,
                //ShapeHeight = 30,
                //LableWidth = 50,
                //LableHeight = 20,
                FontSize = 15,
                Lable = "noname",
                IsShowLable = true
            });

            int largestId = SymbolProvider.Any() ? (int)SymbolProvider.Max(s => s.Id) : 0;
            SelectedSymbol.Id = largestId + 1;
            SelectedSymbol.OnEditable = true;
            
        }

        public void AddRectangle()
        {
            SelectedSymbol = new RectangleShapeViewModel(new ShapePropertyModel()
            {
                X = 0,
                Y = 0,
                Width = 80,
                Height = 80,
                Angle = 0,
                ShapeStroke = "#FFFF0000",
                ShapeStrokeThick = 2,
                ShapeFill = "#FFFF0000",
                //ShapeWidth = 30,
                //ShapeHeight = 30,
                //LableWidth = 50,
                //LableHeight = 20,
                FontSize = 15,
                Lable = "noname",
                IsShowLable = true
            });

            int largestId = SymbolProvider.Any() ? (int)SymbolProvider.Max(s => s.Id) : 0;
            SelectedSymbol.Id = largestId + 1;
            SelectedSymbol.OnEditable = true;
        }

        public void AddTriangle()
        {

        }

        public void AddLine()
        {
            SelectedSymbol = new LineShapeViewModel(new ShapePropertyModel()
            {
                //X = 0,
                //Y = 0,
                //Width = 200,
                //Height = 200,
                Angle = 0,
                ShapeStroke = "#FFFF0000",
                ShapeStrokeThick = 2,
                ShapeFill = "#FFFF0000",
                //ShapeWidth = 30,
                //ShapeHeight = 30,
                //LableWidth = 50,
                //LableHeight = 20,
                FontSize = 15,
                Lable = "noname",
                IsShowLable = true
            });

            int largestId = SymbolProvider.Any() ? (int)SymbolProvider.Max(s => s.Id) : 0;
            SelectedSymbol.Id = largestId + 1;
            SelectedSymbol.OnEditable = true;

            InsertedPoints = new ObservableCollection<Point>();
            
        }

        public void AddText()
        {
            SelectedSymbol = new TextInfoViewModel(new PropertyModel()
            {
                //X = 0,
                //Y = 0,
                Width = 200,
                Height = 80,
                Angle = 0,
                FontSize = 15,
                Lable = "noname",
                IsShowLable = true
            });

            int largestId = SymbolProvider.Any() ? (int)SymbolProvider.Max(s => s.Id) : 0;
            SelectedSymbol.Id = largestId + 1;
            SelectedSymbol.OnEditable = true;

            InsertedPoints = new ObservableCollection<Point>();
        }

        public void OnClickAdd(object sender, MouseButtonEventArgs e)
        {
            Point position = e.GetPosition(e.Source as IInputElement);

            if (SelectedSymbol == null) return;

            if (SelectedSymbol is CircleShapeViewModel circleShapeViewModel)
            {
                NormalShapeProcess(circleShapeViewModel, position);
            }
            else if (SelectedSymbol is RectangleShapeViewModel rectShapeViewModel)
            {
                NormalShapeProcess(rectShapeViewModel, position);
            }
            else if(SelectedSymbol is LineShapeViewModel lineShapeViewModel)
            {
                InsertedPoints.Add(position);

                if (InsertedPoints.Count > 1)
                {
                    double? x, y;
                    UpdateCoordinate(InsertedPoints, out x, out y);
                    lineShapeViewModel.X = (double)x;
                    lineShapeViewModel.Y = (double)y;

                    lineShapeViewModel.Points = RegerateRPoint((double)x, (double)y);

                    Debug.WriteLine($"Canvas Point : ({position.X}, {position.Y})");
                }
                else
                {
                    lineShapeViewModel.Points.Add(new Point(0, 0));
                    lineShapeViewModel.X = position.X;
                    lineShapeViewModel.Y = position.Y;

                    Debug.WriteLine($"Canvas Point : ({position.X}, {position.Y}), Relative Point : (0, 0)");
                }

                lineShapeViewModel.Width = (double)GetWidth();
                lineShapeViewModel.Height = (double)GetHeight();
                Debug.WriteLine($"Width : ({lineShapeViewModel.Width}), Height : ({lineShapeViewModel.Height})");
            }
            else if(SelectedSymbol is TextInfoViewModel textInfoViewModel)
            {
                NormalShapeProcess(textInfoViewModel, position);
            }
            else
            {
                SelectedSymbol = null;
            }
        }

        

        public void OnClickFinish(object sender, MouseButtonEventArgs e)
        {
            if (!(SelectedSymbol is LineShapeViewModel lineShape))
                return;

            Debug.WriteLine($"Start Point X : ({lineShape.X}), Y : ({lineShape.Y})");
            SymbolProvider.Add(SelectedSymbol);
            SelectedSymbol = null;
        }
        #endregion
        #region - Processes -
        private void NormalShapeProcess(ISymbolViewModel shapeViewModel, Point position)
        {
            SelectedSymbol.X = position.X - SelectedSymbol.Width / 2;
            SelectedSymbol.Y = position.Y - SelectedSymbol.Height / 2;

            SymbolProvider.Add(shapeViewModel);
            SelectedSymbol = null;
        }

        private PointCollection RegerateRPoint(double originX, double originY)
        {
            return new PointCollection(InsertedPoints.Select(p => new Point(p.X - originX, p.Y - originY)).ToList());
        }

        private void UpdateCoordinate(ObservableCollection<Point> insertedPoints, out double? x, out double? y)
        {
            double? tempX = null;
            double? tempY = null;
            foreach (var item in insertedPoints)
            {
                if (!tempX.HasValue || !tempY.HasValue)
                {
                    tempX = item.X; tempY = item.Y;
                    continue;
                }

                if (tempX > item.X)
                {
                    tempX = item.X;
                }

                if (tempY > item.Y)
                {
                    tempY = item.Y;
                }
            }

            x = tempX;
            y = tempY;
        }

        private double? GetWidth()
        {
            if (!(InsertedPoints.Count > 0))
                return null;

            double? left = null;
            double? right = null;

            foreach (var point in InsertedPoints)
            {
                if(!left.HasValue || !right.HasValue )
                {
                    left = point.X;
                    right = point.X;

                    continue;
                }

                if(left >= point.X)
                {
                    left = point.X;
                }else if(right <= point.X)
                {
                    right = point.X;
                }
            }

            return right - left + 6d;
        }

        private double? GetHeight()
        {
            if (!(InsertedPoints.Count > 0))
                return null;

            double? top = null;
            double? bottom = null;

            foreach (var point in InsertedPoints)
            {
                if (!top.HasValue || !bottom.HasValue)
                {
                    top = point.Y;
                    bottom = point.Y;

                    continue;
                }
                else
                {
                    if (bottom <= point.Y)
                    {
                        bottom = point.Y;
                    }
                    else if (top >= point.Y)
                    {
                        top = point.Y;
                    }
                }
            }

            return bottom - top + 30d;
        }

        #endregion
        #region - IHanldes -
        #endregion
        #region - Properties -
        public ShapeCollectionViewModel ShapeCollectionViewModel { get; set; }
        public PropertyControlViewModel PropertyControlViewModel { get; set; }
        public SymbolProvider SymbolProvider { get; }

        public ObservableCollection<Point> InsertedPoints { get; set; }

        public ISymbolViewModel SelectedSymbol { get; set; }
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
