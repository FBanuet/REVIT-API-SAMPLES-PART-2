using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;

namespace Springall.Core
{
    [TransactionAttribute(TransactionMode.Manual)]
    public class ShowKeynoteManagerCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var dpid = new DockablePaneId(PaneIdentifiers.KeynotePaneIdentifier());
            var dp = commandData.Application.GetDockablePane(dpid);
            dp.Show();
            

            return Result.Succeeded;
        }


        public static string GetCommandPath()
        {
            return typeof(ShowKeynoteManagerCommand).Namespace + "." + nameof(ShowKeynoteManagerCommand);
        }
    }
}
