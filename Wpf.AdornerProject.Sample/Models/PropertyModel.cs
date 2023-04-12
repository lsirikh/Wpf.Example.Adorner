using System.Windows.Media;

namespace Wpf.AdornerProject.Sample.Models
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 4/4/2023 10:51:11 AM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class PropertyModel : IPropertyModel
    {

        #region - Ctors -
        public PropertyModel()
        {
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
        public int Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Angle { get; set; }
        public bool IsShowLable { get; set; }
        public string Lable { get; set; }
        public double FontSize { get; set; }
        //public bool IsEditable { get; set; }
        public bool IsSelected { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}
