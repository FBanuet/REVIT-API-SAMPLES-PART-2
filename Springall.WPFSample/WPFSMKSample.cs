using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;



namespace Springall.WPFSample
{
    [Transaction(TransactionMode.Manual)]
    public class WPFSMKSample : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document document = commandData.Application.ActiveUIDocument.Document;

            SampleViewer sampleviewer = new SampleViewer(document);
            sampleviewer.ShowDialog();

            return Result.Succeeded;
        }


        public static string GetNamespaceCmmnd()
        {
            return typeof(WPFSMKSample).Namespace + "." + nameof(WPFSMKSample);
        }
    }
}
