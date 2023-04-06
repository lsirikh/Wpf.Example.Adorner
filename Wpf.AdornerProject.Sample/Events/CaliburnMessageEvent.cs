namespace Wpf.AdornerProject.Sample.Events
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 4/5/2023 4:37:43 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class EditShapeMessage
    {
        public EditShapeMessage(bool isEditable, object viewModel)
        {
            IsEditable = isEditable;
            ViewModel = viewModel;
        }

        public bool IsEditable { get; }
        public object ViewModel { get; }
    }
}
