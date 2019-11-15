using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;

namespace RevitDevelop
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //UIApplication uIApplication = commandData.Application;
            //Document doc = uIApplication.ActiveUIDocument.Document;
            //Selection sel = uIApplication.ActiveUIDocument.Selection;
            //Reference ref1 = sel.PickObject(ObjectType.Element, "Please select a wall");
            //Wall wall = doc.GetElement(ref1.ElementId) as Wall;
            //WallInfo wallInfo = RvtUtils.GetWallInfo(wall);
            //List<double> values = new List<double> {5,2,4,6,1,3 };
            //Algorithm.Sort.InsertSort(values);

            //int[] array1 = new int[] { 7,6,5,8,9,4,2,1,3};
            //Algorithm.Sort.MergeSort(array1, 0, array1.Length - 1);

            int[] array2 = new int[] {1,2,3,4,5,6,7,8,9};
            Algorithm.Sort.HeapSort(array2);

            int[] array3 = new int[] { 5,6,7,8,9,4,3,2,1 };
            Algorithm.Sort.QuickSort(array3,0, array3.Length-1);
            return Result.Succeeded;
        }
    }
}
