using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitDevelop
{
    public  class RvtUtils
    {
        /// <summary>
        /// 创建一个参照平面
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="bubbleEnd"></param>
        /// <param name="freeEnd"></param>
        /// <param name="cutVec"></param>
        /// <param name="rpName"></param>
        /// <returns></returns>
        public static ReferencePlane NewReferencePlane(Document doc,XYZ bubbleEnd,XYZ freeEnd,XYZ cutVec,string rpName="")
        {
            ReferencePlane rp = null;
            using (Transaction trans = new Transaction(doc, "New Reference Plane"))
            {
                trans.Start();
                rp = doc.FamilyCreate.NewReferencePlane(bubbleEnd, freeEnd, cutVec, doc.ActiveView);
                rp.Name = rpName;
                trans.Commit();
            }
            return rp;
        }
        public static void CreateDimsionType(Document doc)
        {
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            collector.OfClass(typeof(DimensionType));
            DimensionType dimType = null;
            foreach(Element elem in collector)
            {
                if(elem.Name=="Linear Dimension Style")
                {
                    dimType = elem as DimensionType;
                    break;
                }
            }
            DimensionType newType = dimType.Duplicate("New Dim Type") as DimensionType;
            if(newType!=null)
            {
                using (Transaction trans = new Transaction(doc, "Create new dim type"))
                {
                    trans.Start();
                    newType.get_Parameter(BuiltInParameter.LINE_PEN).Set(2);
                    doc.Regenerate();
                    trans.Commit();
                }
            }
        }
        /// <summary>
        /// 获取墙的长、宽、高信息
        /// </summary>
        /// <param name="wall"></param>
        /// <returns></returns>
        public static WallInfo GetWallInfo(Wall wall)
        {
            WallInfo wallInfo = new WallInfo();
            if(wall==null)
            {
                return wallInfo;
            }
            LocationCurve lc = wall.Location as LocationCurve;
            double dWallLength = lc.Curve.Length;

            //get wall base absoutely height
            Parameter paramBottomLevel = wall.get_Parameter(BuiltInParameter.WALL_BASE_CONSTRAINT);
            //get the bottom level id
            ElementId idbottom = paramBottomLevel.AsElementId();
            Level levelBottom = wall.Document.GetElement(idbottom) as Level;

            Parameter paramBottomOffset = wall.get_Parameter(BuiltInParameter.WALL_BASE_OFFSET); //base offset.
            double dBottomHeight = levelBottom.Elevation + paramBottomOffset.AsDouble();

            //get wall top absoutely height
            double dHeight = 0;
            Parameter paramTopLevel = wall.get_Parameter(BuiltInParameter.WALL_HEIGHT_TYPE); //top level.
            if (paramTopLevel != null)
            {

                //get the bottom level id
                ElementId idTop = paramTopLevel.AsElementId();
                Level levelTop = wall.Document.GetElement(idTop) as Level;
                if (levelTop != null)
                {
                    Parameter paramTopOffset = wall.get_Parameter(BuiltInParameter.WALL_TOP_OFFSET); //upper offset.
                    double dHeightTop = levelTop.Elevation + paramTopOffset.AsDouble();

                    //wall height
                    dHeight = dHeightTop - dBottomHeight;
                }
                else
                    dHeight = wall.get_Parameter(BuiltInParameter.WALL_USER_HEIGHT_PARAM).AsDouble();
            }

            //get wall width
            double dWidth = wall.Width;
            wallInfo.Length = dWallLength;
            wallInfo.Width = dWidth;
            wallInfo.Height = dHeight;
            return wallInfo;
        }
        /// <summary>
        /// 英尺转毫米
        /// </summary>
        /// <param name="feet"></param>
        /// <returns></returns>
        public static double FeetToMillimeter(double feet)
        {
            return UnitUtils.Convert(feet, DisplayUnitType.DUT_DECIMAL_FEET, DisplayUnitType.DUT_MILLIMETERS);
        }
        /// <summary>
        /// 英尺到米
        /// </summary>
        /// <param name="feet"></param>
        /// <returns></returns>
        public static double FeetToMeter(double feet)
        {
            return UnitUtils.Convert(feet, DisplayUnitType.DUT_DECIMAL_FEET, DisplayUnitType.DUT_METERS);
        }
        /// <summary>
        /// 平方英尺到平方米
        /// </summary>
        /// <param name="feet"></param>
        /// <returns></returns>
        public static double SquareFeetToSquareMeter(double feet)
        {
            return UnitUtils.Convert(feet, DisplayUnitType.DUT_SQUARE_FEET, DisplayUnitType.DUT_SQUARE_METERS);
        }
        /// <summary>
        /// 立方英尺到立方米
        /// </summary>
        /// <param name="feet"></param>
        /// <returns></returns>
        public static double CubicFeetToCubicMeter(double feet)
        {
            return UnitUtils.Convert(feet, DisplayUnitType.DUT_CUBIC_FEET, DisplayUnitType.DUT_CUBIC_METERS);
        }
    }
}
