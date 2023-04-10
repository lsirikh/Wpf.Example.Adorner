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

    /// <summary>
    /// Shape Edit 이벤트 메시지
    /// </summary>
    public class EditShapeMessage
    {
        public EditShapeMessage(bool isEditable, object viewModel)
        {
            IsEditable = isEditable;
            ViewModel = viewModel;
        }

        /// <summary>
        /// Shape Edit Option
        /// True/False
        /// </summary>
        public bool IsEditable { get; }
        /// <summary>
        /// 편집 할 인스턴스
        /// </summary>
        public object ViewModel { get; }
    }

    /// <summary>
    /// Shape 삭제 이벤트 메시지
    /// </summary>
    public class DeleteShapeMessage
    {
        public DeleteShapeMessage(object viewModel)
        {
            ViewModel = viewModel;
        }

        /// <summary>
        /// 삭제 할 인스턴스
        /// </summary>
        public object ViewModel { get; }
    }
}
