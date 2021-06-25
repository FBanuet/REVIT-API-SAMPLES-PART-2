using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.ApplicationServices;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Springall.Core
{
    [TransactionAttribute(TransactionMode.Manual)]
    public class NavisWorksMasterExporterCommand : IExternalCommand , IOpenFromCloudCallback
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;
            OpenOptions opt = new OpenOptions();
            NavisworksExportOptions nweOptions = new NavisworksExportOptions();



            /// INSTANCEANDO LA CLASE ZIP PARA ITERAR CON MAS DE 1 ARRAY [] DE DATOS
            /// 

            Guid GlobalProjectGuid = new Guid("7df25be5-6220-4950-9b7f-61f5010226ce");

            Guid SOT_ModelGuid = new Guid("e9d3d065-5919-4b9b-9864-023332e3deee");
            Guid TOPO_modelguid = new Guid("4f68151e-aaf1-4f8a-a409-b9a359f40ef6");
            Guid FAC_E_modelguid = new Guid("52625d7d-5632-4ea2-8205-1066477bff16");
            Guid FAC_N_modelguid = new Guid("5c5fc2a1-a897-4fc1-89c7-2dcc3b98af9b");
            Guid FAC_O_modelguid = new Guid("62094045-3ae8-40d8-a731-2cc111a8d43a");
            Guid FAC_S_modelguid = new Guid("4177854a-1b0f-41a8-95ef-e0304bc5eba5");
            Guid PAS_modelguid = new Guid("2715f5e5-1fa6-4abf-a835-3081cd6cbe4b");


            Dictionary<string, Guid> PMGuids = new Dictionary<string, Guid>();

            PMGuids.Add("SOTANO", SOT_ModelGuid);
            PMGuids.Add("TOPOGRAFÍA", TOPO_modelguid);
            PMGuids.Add("FACHADA ESTE", FAC_E_modelguid);
            PMGuids.Add("FACHADA NORTE", FAC_N_modelguid);
            PMGuids.Add("FACHADA OESTE", FAC_O_modelguid);
            PMGuids.Add("FACHADA SUR", FAC_S_modelguid);
            PMGuids.Add("PASILLOS", PAS_modelguid);

            DefaultOpenFromCloudCallback defaultOpen = new DefaultOpenFromCloudCallback();

            //UIDocument rvtBIM360 = null;
            //string data = "";
            string ViewNames = "";

            foreach (KeyValuePair<String, Guid> PandMguid in PMGuids)
            {
                ModelPath modelpath = ModelPathUtils.ConvertCloudGUIDsToCloudPath(GlobalProjectGuid, PandMguid.Value);
                //rvtBIM360 = uiapp.OpenAndActivateDocument(modelpath, opt, false, defaultOpen);
                Document doc360 = app.OpenDocumentFile(modelpath, opt, defaultOpen);
                View3D VISTAnwc = bimview(doc360);
                Parameter par = VISTAnwc.LookupParameter("Title on Sheet");
                string nn = par.AsString();
                ViewNames += par.AsString() + Environment.NewLine;
                nweOptions.ExportScope = NavisworksExportScope.View;
                nweOptions.ViewId = VISTAnwc.Id;

                doc360.Export(@"C:\Users\SMK\BIM 360\Akurat - Arq\Explanada AGS\Project Files\01.ARQUITECTURA\MODELOS NWC", nn + "_19" + ".nwc", nweOptions);
                doc360.Close(false);

                //data += "MODELO ABIERTO : " + PandMguid.Key + Environment.NewLine + "VISTA ENCONTRADA : " + Environment.NewLine + VISTAnwc.Name + VISTAnwc.Id.ToString()
                //    + Environment.NewLine +Environment.NewLine;

            }

            TaskDialog.Show("LOS DATOS PA!", "LA VISTA QUE SE EXPORTO A NAVIS FUE :" + " - " + ViewNames);



            return Result.Succeeded;
        }


        public static string GetNamespaceCmmnd()
        {
            return typeof(NavisWorksMasterExporterCommand).Namespace + "." + nameof(NavisWorksMasterExporterCommand);
        }

        public OpenConflictResult OnOpenConflict(OpenConflictScenario scenario)
        {

            throw new NotImplementedException();
        }

        public View3D bimview(Document doc)
        {

            View3D vistaNWC = null;
            List<View3D> all3dviews = new FilteredElementCollector(doc).OfClass(typeof(View3D)).Cast<View3D>().ToList();

            bool checker = false;


            foreach (View3D vista in all3dviews)
            {
                if (vista.IsTemplate == checker && vista.Name == "SMK-NAVIS-BIM360")
                {

                    vistaNWC = vista;


                }

            }

            return vistaNWC;
        }


    }
}
