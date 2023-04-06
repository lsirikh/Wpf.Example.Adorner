using Ironwall.Framework;
using System.Diagnostics;
using System.Windows;
using System;
using Wpf.AdornerProject.Sample.ViewModels;
using Autofac;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Wpf.AdornerProject.Sample.Providers;
using Wpf.AdornerProject.Sample.ViewModels.Shapes;
using Wpf.AdornerProject.Sample.ViewModels.Elements;
using Wpf.AdornerProject.Sample.ViewModels.Properties;

namespace Wpf.AdornerProject.Sample
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 4/4/2023 9:37:59 AM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class Bootstrapper : ParentBootstrapper<ShellViewModel>
    {

        #region - Ctors -
        public Bootstrapper()
        {
            Initialize();
        }
        #endregion
        #region - Implementation of Interface -
        #endregion
        #region - Overrides -
        protected override async void OnStartup(object sender, StartupEventArgs e)
        {

            base.OnStartup(sender, e);

            await Start();
            await DisplayRootViewForAsync<ShellViewModel>();
        }

        protected override void OnExit(object sender, EventArgs e)
        {
            Stop();
        }

        protected override void ConfigureContainer(ContainerBuilder builder)
        {
            try
            {
                base.ConfigureContainer(builder);
                //builder.RegisterType<CircleEntityViewModel>().SingleInstance();
                builder.RegisterType<CirclesViewModel>().SingleInstance();
                builder.RegisterType<CircleShapeProvider>().SingleInstance();
                builder.RegisterType<PropertyControlViewModel>().SingleInstance();

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Raised Exception in {nameof(ConfigureContainer)} : {ex.Message}");
            }
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            var assemblies = new List<Assembly>();
            assemblies.AddRange(base.SelectAssemblies());
            //Load new ViewModels here
            string[] fileEntries = Directory.GetFiles(Directory.GetCurrentDirectory());

            ///Load DLL each
            /////////////////////////////////////////////////////////////////////////////
            //assemblies.AddRange(from fileName in fileEntries
            //                    where fileName.Contains("Ironwall.Framework.dll")
            //                    select Assembly.LoadFile(fileName));
            //assemblies.AddRange(from fileName in fileEntries
            //                    where fileName.Contains("Ironwall.Libraries.Utils.dll")
            //                    select Assembly.LoadFile(fileName));
            //assemblies.AddRange(from fileName in fileEntries
            //                    where fileName.Contains("Ironwall.Libraries.Enums.dll")
            //                    select Assembly.LoadFile(fileName));
            assemblies.AddRange(from fileName in fileEntries
                                where fileName.Equals("Wpf.Libraries.AdornerDecorator.dll")
                                select Assembly.LoadFile(fileName));
            /////////////////////////////////////////////////////////////////////////////
            return assemblies;
        }
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
        #endregion
    }
}
