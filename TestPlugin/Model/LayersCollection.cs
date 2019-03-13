using System.Collections.ObjectModel;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;

namespace TestPlugin
{
    /// <summary>
    /// Реализует коллекцию моделей слоев и примитивов: 
    /// окружность, точка, отрезок
    /// </summary>
    public class LayersCollection : ObservableCollection<Layer>
    {
        public LayersCollection() : base()
        {
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;

            using (Transaction tr = db.TransactionManager.StartTransaction())
            {
                // Получение коллекции моделей слоев

                LayerTable lt = tr.GetObject(db.LayerTableId, OpenMode.ForRead) as LayerTable;
                Converter converter = new Converter();
                DataValidation.LayerNames = new System.Collections.Generic.List<string> { };

                foreach (ObjectId ltrId in lt)
                {
                    LayerTableRecord ltr = tr.GetObject(ltrId, OpenMode.ForRead) as LayerTableRecord;
                    Add(converter.Layer(ltr));
                    DataValidation.LayerNames.Add(ltr.Name);
                }

                // Получение коллекции моделей примитивов, 
                // сгруппированных по слоям, к которым принадлежат

                BlockTable acBlkTbl = tr.GetObject(db.BlockTableId, OpenMode.ForRead) as BlockTable;
                BlockTableRecord ms = tr.GetObject(acBlkTbl[BlockTableRecord.ModelSpace], OpenMode.ForWrite) as BlockTableRecord;
                foreach (ObjectId id in ms)
                {
                    Entity entity = (Entity)tr.GetObject(id, OpenMode.ForRead);
                    foreach (Layer layer in this)
                    {
                        if (entity.Layer == layer.Name)
                        {
                            if (entity.GetType() == typeof(DBPoint))
                            {
                                DBPoint point = (DBPoint)tr.GetObject(id, OpenMode.ForRead);
                                layer.Primitives.Add(converter.PrimitivePoint(point));
                            }
                            if (entity.GetType() == typeof(Line))
                            {
                                Line line = (Line)tr.GetObject(id, OpenMode.ForRead);
                                layer.Primitives.Add(converter.PrimitiveLine(line));
                            }
                            if (entity.GetType() == typeof(Circle))
                            {
                                Circle circle = (Circle)tr.GetObject(id, OpenMode.ForRead);
                                layer.Primitives.Add(converter.PrimitiveCircle(circle));
                            }
                        }      
                    }
                }
                tr.Commit();
            }
        }
    }
}
