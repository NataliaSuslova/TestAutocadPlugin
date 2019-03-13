namespace TestPlugin
{
    /// <summary>
    /// Содержит общие свойства примитивов
    /// </summary>
    public abstract class Primitive : AutocadObject
    {
        // Название примитива
        public override string Name { get; set; }

        // Тип примитива показывает к какой группе примитивов
        // относится объект, используется для группировки объектов
        public string PrimitiveType { get; set; }

        // Высота, общее редактируемое свойство примитивов
        public double Height { get; set; }
    }
}
