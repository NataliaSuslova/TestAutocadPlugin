using System.Collections.ObjectModel;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;

namespace TestPlugin
{
    public class UpdateAutocadDrawing
    {
        private ObservableCollection<Layer> layersCollection;

        public UpdateAutocadDrawing(ObservableCollection<Layer> layersCollection)
        {
            this.layersCollection = layersCollection;
        }

        public void Update()
        {
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Editor ed = doc.Editor;
            Database db = doc.Database;

            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                Converter converter = new Converter();

                foreach (Layer layer in layersCollection)
                {
                    foreach (Primitive primitive in layer.Primitives)
                    {
                        if (primitive is PrimitiveCircle)
                        {
                            PrimitiveCircle pc = primitive as PrimitiveCircle;
                            Circle cir = tr.GetObject(pc.ID, OpenMode.ForWrite, false, true) as Circle;
                            try
                            {                        
                                cir.Radius = pc.Radius;
                                cir.Thickness = pc.Height;
                                cir.Center = converter.Point3d(pc.Center);
                            }
                            catch (Autodesk.AutoCAD.Runtime.Exception Ex)
                            {
                                DataValidation.ErrorInfo(Ex.Message);
                            }
                        }

                        if (primitive is PrimitiveLine)
                        {
                            PrimitiveLine pl = (PrimitiveLine)primitive;
                            Line line = tr.GetObject(pl.ID, OpenMode.ForWrite, false, true) as Line;
                            try
                            {
                                line.Thickness = pl.Height;
                                line.StartPoint = converter.Point3d(pl.StartPoint);
                                line.EndPoint = converter.Point3d(pl.EndPoint);
                            }
                            catch (Autodesk.AutoCAD.Runtime.Exception Ex)
                            {
                                DataValidation.ErrorInfo(Ex.Message);
                            }                           
                        }

                        if (primitive is PrimitivePoint)
                        {
                            PrimitivePoint pp = (PrimitivePoint)primitive;
                            DBPoint point = tr.GetObject(pp.ID, OpenMode.ForWrite, false, true) as DBPoint;
                            try
                            {
                                point.Thickness = pp.Height;
                                point.Position = converter.Point3d(pp.Position);
                            }
                            catch (Autodesk.AutoCAD.Runtime.Exception Ex)
                            {
                                DataValidation.ErrorInfo(Ex.Message);
                            }                           
                        }
                    }

                    LayerTableRecord layerTableRecord = tr.GetObject(layer.ID, OpenMode.ForWrite, false, true) as LayerTableRecord;
                    try
                    {
                        layerTableRecord.Name = layer.Name;
                        layerTableRecord.IsOff = !layer.Visibility;
                        layerTableRecord.Color = converter.AcadColor(layer.LayerColor);
                    }
                    catch (Autodesk.AutoCAD.Runtime.Exception Ex)
                    {
                        DataValidation.ErrorInfo(Ex.Message);
                    }                    
                }
                tr.Commit();
            }
        }
    }
}
