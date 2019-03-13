using Autodesk.AutoCAD.ApplicationServices;
using System.Collections.Generic;

namespace TestPlugin
{
    public static class DataValidation
    {
        public static double ValidRadius(double newRadius, double currentRadius)
        {
            if (newRadius > 0)
                return newRadius;

            ErrorInfo("Радиус окружности должен быть положительным");
            return currentRadius;
        }

        public static List<string> LayerNames = new List<string> { };

        public static string ValidLayerName(string newName, string currentName)
        {
            newName = newName.Trim();

            if (newName == currentName)
                return currentName;

            if (currentName == "0")
            {
                ErrorInfo("Не допускается переименование слоя 0");
                return currentName;               
            }                           
            if (LayerNames.Contains(newName))
            {
                ErrorInfo("Данное имя, "+newName+", уже используется");
                return currentName;
            }
            LayerNames.Remove(currentName);
            LayerNames.Add(newName);
            return newName;
        }

        public static void ErrorInfo(string message)
        {
            Application.ShowAlertDialog(message);
        }
    }
}
