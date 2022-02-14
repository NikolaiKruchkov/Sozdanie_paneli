using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dobavlenie_vkl_i_knopk
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalApplication
    {

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            string tabName = "Revit API training";
            application.CreateRibbonTab(tabName);
            string utilsFolderPath = @"C:\Users\Nikryuchkov\Desktop\Revit\";
            var panel = application.CreateRibbonPanel(tabName, "Стены");
            var button1 = new PushButtonData("Типы стен", "Смена типа стен",
                Path.Combine(utilsFolderPath, "Izmenenie_tipov_sten.dll"),
                "Izmenenie_tipov_sten.Main");
            var button2 = new PushButtonData("Количество", "Количество элементов",
    Path.Combine(utilsFolderPath, "Sozdanie_knopok.dll"),
    "Sozdanie_knopok.Main");
            panel.AddItem(button1);
            panel.AddItem(button2);
            return Result.Succeeded;
        }
    }
}
