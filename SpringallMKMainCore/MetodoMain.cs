using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using Springall.UI;

namespace SpringallMKMainCore
{
    public class MetodoMain : IExternalApplication
    {


        public Result OnStartup(UIControlledApplication application)
        {

            var ui = new InterfaceSetup();
            ui.Initialize(application);

            application.ControlledApplication.ApplicationInitialized += DockablePaneRegisters;

            return Result.Succeeded;
        }

        

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        private void DockablePaneRegisters(object sender, ApplicationInitializedEventArgs e)
        {
            var KeynoteManagerRegisterCommand = new RegisterKeynoteManagerCommand();
            KeynoteManagerRegisterCommand.Execute(new UIApplication(sender as Application));

        }

    }
}
