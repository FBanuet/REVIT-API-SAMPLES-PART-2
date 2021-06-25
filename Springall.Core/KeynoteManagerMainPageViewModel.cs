
namespace Springall.Core
{
    using System.Windows.Input;
    using Autodesk.Revit.UI;

    public class KeynoteManagerMainPageViewModel : BaseViewModel
    {

        public ApplicationPageType currentPage { get; set; } = ApplicationPageType.Keynote;


        public ICommand KeynoteManagerBTNCommand { get; set; }

        public ICommand FamilySetupBNTCommand { get; set; }


        public KeynoteManagerMainPageViewModel()
        {

            KeynoteManagerBTNCommand = new RouteCommands(() => currentPage = ApplicationPageType.Keynote);
            FamilySetupBNTCommand = new RouteCommands(() => currentPage = ApplicationPageType.FamilySetup);
        }

       
    }
}
