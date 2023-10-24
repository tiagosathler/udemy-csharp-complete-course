namespace S14C209.Entities
{
    internal abstract class Shape : IShape
    {
        public Color Color { get; }

        protected Shape(Color color)
        {
            Color = color;
        }

        public abstract double Area();

        public override string ToString()
        {
            return $"{Color} - Area = {Area():F2}";
        }
    }
}