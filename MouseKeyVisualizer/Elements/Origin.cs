namespace MouseKeyVisualizer.Elements
{
    public struct Origin
    {
        public Origin(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; }
        public double Y { get; }
    }
}