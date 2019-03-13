using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;

[assembly: CommandClass(typeof(TestPlugin.Commands))]
namespace TestPlugin
{
    class Commands
    {
        [CommandMethod("AUTOCAD")]
        public void AutocadCommand()
        {
            MainWindow mainWindow = new MainWindow();
            Application.ShowModalWindow(mainWindow);
        }
    }
}
