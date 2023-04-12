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

    public class ShapeViewModel :SymbolViewModel, IShapeViewModel
    {

        #region - Ctors -
        public ShapeViewModel()
        {
            _model = new ShapePropertyModel();
        }
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
        public double ShapeStrokeThick
        {
            get { return (_model as ShapePropertyModel).ShapeStrokeThick; }
            set
            {
                (_model as ShapePropertyModel).ShapeStrokeThick = value;
                NotifyOfPropertyChange(() => ShapeStrokeThick);
            }
        }

        public string ShapeStroke
        {
            get { return (_model as ShapePropertyModel).ShapeStroke == null ? "#FFFF0000" : (_model as ShapePropertyModel).ShapeStroke; }
            set
            {
                (_model as ShapePropertyModel).ShapeStroke = value;
                NotifyOfPropertyChange(() => ShapeStroke);
            }
        }

        public string ShapeFill
        {
            get { return (_model as ShapePropertyModel).ShapeFill == null ? "#00FFFFFF" : (_model as ShapePropertyModel).ShapeFill; }
            set
            {
                (_model as ShapePropertyModel).ShapeFill = value;
                NotifyOfPropertyChange(() => ShapeFill);
            }
        }
        #endregion
        #region - Attributes -

        #endregion
    }
}
