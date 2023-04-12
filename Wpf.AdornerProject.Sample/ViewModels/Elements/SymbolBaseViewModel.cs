using Caliburn.Micro;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using Wpf.AdornerProject.Sample.Models;

namespace Wpf.AdornerProject.Sample.ViewModels.Elements
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 4/11/2023 10:07:20 AM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public abstract class SymbolBaseViewModel : Screen, ISymbolBaseViewModel, IDisposable
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
        public abstract void Dispose();
        public abstract void OnClickEdit(object sender, RoutedEventArgs args);
        public abstract void OnClickExit(object sender, RoutedEventArgs args);
        public abstract void OnClickDelete(object sender, RoutedEventArgs args);
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
        protected PropertyModel _model { get; set; }
        #endregion
        #region - Attributes -
        private bool _onEditable;
        private bool _isEditable;
        protected IEventAggregator _eventAggregator;
        #endregion
    }
}
