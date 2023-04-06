using System;
using System.Globalization;
using System.Windows.Data;

namespace Wpf.AdornerProject.Sample.Utils
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 4/5/2023 1:47:09 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class ShapeSizeWithLableConverter : IMultiValueConverter
    {

        #region - Ctors -
        #endregion
        #region - Implementation of Interface -
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double shapeSize = 0d;
            
            if (parameter.ToString() == "Width")
            {
                double totalSize = (double)values[0];

                shapeSize = totalSize  - MARGIN;
                return shapeSize;
            }
            else if(parameter.ToString() == "Height")
            {
                double totalSize = (double)values[0];
                double elementSize = (double)values[1];

                shapeSize = totalSize - elementSize - MARGIN;
                return shapeSize;
            }
            else
            {
                return shapeSize;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
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
        #endregion
        #region - Attributes -
        private const double MARGIN = 5.0;
        #endregion

    }
}
