namespace TestPlugin
{
    public class PrimitiveCircle : Primitive
    {
        public PrimitiveCircle()
        {           
        }

        public Point3D Center { get; set; }

        public double Radius { get; set; }

        public override string Display
        {
            get
            {
                return string.Format("X,Y,Z: {0} R: {1}, H: {2}", 
                    Center.ToString(), Radius, Height);
            }
        }

        public override void Edit(object obj)
        {
            var circleEditViewModel = new CircleEditViewModel((PrimitiveCircle)obj);
            var circleEditWindow = new CircleEditWindow(circleEditViewModel);
            circleEditWindow.ShowDialog();
        }

        public override object Clone()
        {
            return new PrimitiveCircle
            {
                Radius = this.Radius,
                Center = (Point3D)this.Center.Clone(),
                Height = this.Height
            };
        }

        public override void Update(AutocadObject obj)
        {
            var circle = (PrimitiveCircle)obj;
            this.Radius = DataValidation.ValidRadius(circle.Radius, this.Radius);
            this.Center = circle.Center;
            this.Height = circle.Height;
            OnPropertyChanged("Display");
        }
    }
}
