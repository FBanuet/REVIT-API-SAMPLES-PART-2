using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Springall.UI;
using SpringallSrc;
using Springall.Core;


namespace SpringallMKMainCore
{
    public class InterfaceSetup
    {




        public InterfaceSetup()
        {

        }

    
        
        public void Initialize(UIControlledApplication app)
        {
            string tabName = "SpringallMKBIMTools";
            app.CreateRibbonTab(tabName);

            var manageCommandsPanel = app.CreateRibbonPanel(tabName, "ManageCommands");
            var InformationModelPanel = app.CreateRibbonPanel(tabName, "BIManager");



            var NavisWorksMasterExporterButtonData = new RevitPushButtonDataModel
            {
                Label = "ExportNWCBIM360",
                Panel = manageCommandsPanel,
                Tooltip = "Exportar Vistas a BIM360 COMO NWC",
                CommandNameSpacePath = NavisWorksMasterExporterCommand.GetNamespaceCmmnd(),
                IconImageName =  "revitnavis32x16.png",
                TooltipImageName = "revitnavis320x320.png"
            };

            


            var NavisworksButton = RevitPushButton.create(NavisWorksMasterExporterButtonData);




            var KeynoteManagerShowButtonData = new RevitPushButtonDataModel
            {
                Label = "Iniciar MasterFormatManagerPanel",
                Panel = InformationModelPanel,
                Tooltip = "Despliuega la Interfaz del Panel deL MasterFormatClassificationManager",
                CommandNameSpacePath = ShowKeynoteManagerCommand.GetCommandPath(),
                IconImageName = "ShowMF32X32.png",
                TooltipImageName = "ShowMF320X320.png",

            };

            var KeynoteManagerShowButton = RevitPushButton.create(KeynoteManagerShowButtonData);

            var KeynoteManagerHideButtonData = new RevitPushButtonDataModel
            {
                Label = "Cerrar MasterFormatManagerPanel",
                Panel = InformationModelPanel,
                Tooltip = "Oculta la Interfaz del Panel deL MasterFormatClassificationManager",
                CommandNameSpacePath = HideKeynoteManagerCommand.GetPath(),
                IconImageName = "HideMF32X32.png",
                TooltipImageName = "HideMF320X320.png",
            };

            var KeynoteManagerHideButton = RevitPushButton.create(KeynoteManagerHideButtonData);

        }


    }

}
