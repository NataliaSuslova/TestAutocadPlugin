namespace TestPlugin
{
    public class PrimitivePoint : Primitive
    {
        public PrimitivePoint()
        {        
        }

        public Point3D Position { get; set; }

        public override string Display
        {
            get
            {
                return string.Format("P: {0}, H: {1}",
                    Position.ToString(), Height);
            }
        }

        public override void Edit(object obj)
        {
            var pointEditViewModel = new PointEditViewModel((PrimitivePoint)obj);
            var pointEditWindow = new PointEditWindow(pointEditViewModel);
            pointEditWindow.ShowDialog();
        }

        public override object Clone()
        {
            return new PrimitivePoint
            {
                Position = (Point3D)this.Position.Clone(),
                Height = this.Height
            };
        }

        public override void Update(AutocadObject obj)
        {
            var point = (PrimitivePoint)obj;
            this.Position = point.Position;
            this.Height = point.Height;
            OnPropertyChanged("Display");
        }
    }
}
