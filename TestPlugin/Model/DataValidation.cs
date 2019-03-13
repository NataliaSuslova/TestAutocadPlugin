using Autodesk.AutoCAD.ApplicationServices;
using System.Collections.Generic;

namespace TestPlugin
{
    /// <summary>
    /// Проверяет допустимость значений некоторых свойств
    /// после их редактирования
    /// </summary>
    public static class DataValidation
    {

        // Проверяет, что новый радиус окружности положительный
        public static double ValidRadius(double newRadius, double currentRadius)
        {
            if (newRadius > 0)
                return newRadius;

            ErrorInfo("Радиус окружности должен быть положительным");
            return currentRadius;
        }

        // Список имеющихся названий слоев
        public static List<string> LayerNames = new List<string> { };

        // Проверяет, что новое имя слоя уникально и 
        // нет попытки переименовать слой 0
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

        // Сообщение об ошибке
        public static void ErrorInfo(string message)
        {
            Application.ShowAlertDialog(message);
        }
    }
}
