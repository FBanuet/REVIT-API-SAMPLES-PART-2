using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;

namespace SMKWindowsPF
{
    [Transaction(TransactionMode.Manual)]
    public class ViewWPFModelCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document document = commandData.Application.ActiveUIDocument.Document;

            SMKViewer viewer = new SMKViewer(document);
            viewer.ShowDialog();

            return Result.Succeeded;
        }
    }
}
