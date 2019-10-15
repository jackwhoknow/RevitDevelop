using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;

namespace RevitDevelop
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
           UIApplication uIApplication= commandData.Application;
            TaskDialog.Show("我的第一个命令", "Hello Word");
            int a = 100;
            int b = 200;
            int c = 300;
            int d = 400;
            int e = 500;
            int f = 8800;
            int g = 9800;
            int h = 10000;
            int i = 20000;
            int l = 30000;
            return Result.Succeeded;
        }
    }
}
