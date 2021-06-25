using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Springall.UI.UIx;
using System.Windows;
using Springall.Core;
using Autodesk.Revit.UI.Events;
using Autodesk.Revit.DB.Events;

namespace Springall.UI
{
    [TransactionAttribute(TransactionMode.Manual)]
    public class RegisterKeynoteManagerCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {


            return Execute(commandData.Application);
        }

        //KeynoteManagerMainPage dockableWindow = null;
        //ExternalCommandData edata = null;

        public Result Execute(UIApplication uIApplication)
        {

            

            var data = new DockablePaneProviderData();
            var managerPage = new KeynoteManagerMainPage();




            data.FrameworkElement = managerPage as FrameworkElement;

            var state = new DockablePaneState
            {
                DockPosition = DockPosition.Right,
            };

            var dpid = new DockablePaneId(PaneIdentifiers.KeynotePaneIdentifier());
            uIApplication.RegisterDockablePane(dpid, "KEYNOTEMANAGER", managerPage as IDockablePaneProvider);

            //edata.Application.Application.DocumentOpened += new EventHandler<DocumentOpenedEventArgs>(Application_DocumentOpened);
            //edata.Application.ViewActivated += new EventHandler<ViewActivatedEventArgs>(Application_ViewActivated);





            return Result.Succeeded;
        }


      

        //public void Application_ViewActivated(object sender,ViewActivatedEventArgs e)
        //{
        //    dockableWindow.CustomInitiator(edata);
        //}

        //public void Application_DocumentOpened(object sender,DocumentOpenedEventArgs e)
        //{
        //    dockableWindow.CustomInitiator(edata);
        //}
    }
}
