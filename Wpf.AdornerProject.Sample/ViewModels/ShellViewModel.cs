using Caliburn.Micro;
using Ironwall.Framework.ViewModels;
using System;
using System.Threading;
using System.Threading.Tasks;
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
        public ShellViewModel(CirclesViewModel circlesViewModel
            , PropertyControlViewModel propertyControlViewModel)
        {
            CirclesViewModel = circlesViewModel;
            PropertyControlViewModel = propertyControlViewModel;
        }
        #endregion
        #region - Implementation of Interface -
        #endregion
        #region - Overrides -
        protected override async Task OnActivateAsync(CancellationToken cancellationToken)
        {
            await base.OnActivateAsync(cancellationToken);
            await CirclesViewModel.ActivateAsync();
            await PropertyControlViewModel.ActivateAsync();
        }

        
        #endregion
        #region - Binding Methods -
        public void OnEditShape()
        {

        }

        public void OffEditShape()
        {

        }
        #endregion
        #region - Processes -
        private void SetupShapes()
        {

        }
        #endregion
        #region - IHanldes -
        #endregion
        #region - Properties -
        public CirclesViewModel CirclesViewModel { get; set; }
        public PropertyControlViewModel PropertyControlViewModel { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}
