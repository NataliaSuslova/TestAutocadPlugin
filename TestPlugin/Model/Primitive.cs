namespace TestPlugin
{
    public abstract class Primitive : AutocadObject
    {
        public override string Name { get; set; }

        public string PrimitiveType { get; set; }

        public double Height { get; set; }
    }
}
