using Caliburn.Micro;
using System.Runtime.InteropServices;
using System.Windows.Media;
using Wpf.AdornerProject.Sample.Models;

namespace Wpf.AdornerProject.Sample.ViewModels.Elements
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 4/4/2023 3:18:41 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public abstract class ShapeBaseViewModel : Screen, IShapeBaseViewModel
    {

        #region - Ctors -
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
        public int Id
        {
            get { return _model.Id; }
            set
            {
                _model.Id = value;
                NotifyOfPropertyChange(() => Id);
            }
        }

        public double X
        {
            get { return _model.X; }
            set
            {
                _model.X = value;
                NotifyOfPropertyChange(() => X);
            }
        }

        public double Y
        {
            get { return _model.Y; }
            set
            {
                _model.Y = value;
                NotifyOfPropertyChange(() => Y);
            }
        }
        public double Width
        {
            get { return _model.Width; }
            set
            {
                _model.Width = value;
                NotifyOfPropertyChange(() => Width);
            }
        }

        public double Height
        {
            get { return _model.Height; }
            set
            {
                _model.Height = value;
                NotifyOfPropertyChange(() => Height);
            }
        }

        public double Angle
        {
            get { return _model.Angle; }
            set
            {
                _model.Angle = value;
                NotifyOfPropertyChange(() => Angle);
            }
        }

        public double StrokeThickness
        {
            get { return _model.StrokeThickness; }
            set
            {
                _model.StrokeThickness = value;
                NotifyOfPropertyChange(() => StrokeThickness);
            }
        }

        public string Stroke
        {
            get { return _model.Stroke; }
            set
            {
                _model.Stroke = value;
                NotifyOfPropertyChange(() => Stroke);
            }
        }

        public string Fill
        {
            get { return _model.Fill; }
            set
            {
                _model.Fill = value;
                NotifyOfPropertyChange(() => Fill);
            }
        }

        public string Lable
        {
            get { return _model.Lable; }
            set
            {
                _model.Lable = value;
                NotifyOfPropertyChange(() => Lable);
            }
        }

        public double FontSize
        {
            get { return _model.FontSize; }
            set
            {
                _model.FontSize = value;
                NotifyOfPropertyChange(() => FontSize);
            }
        }

        public bool IsShowLable
        {
            get { return _model.IsShowLable; }
            set
            {
                _model.IsShowLable = value;
                NotifyOfPropertyChange(() => IsShowLable);
            }
        }

        public bool IsSelected
        {
            get { return _model.IsSelected; }
            set
            {
                _model.IsSelected = value;
                NotifyOfPropertyChange(() => IsSelected);
            }
        }

        

        #endregion
        #region - Attributes -
        protected PropertyModel _model { get; set; }
        
        #endregion
    }
}
