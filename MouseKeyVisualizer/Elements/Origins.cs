namespace MouseKeyVisualizer.Elements
{
    public static class Origins
    {
        public static Origin TopLeft { get; } = new Origin(0, 0);
        public static Origin TopCenter { get; } = new Origin(0.5, 0);
        public static Origin TopRight { get; } = new Origin(1, 0);
        public static Origin CenterLeft { get; } = new Origin(0, 0.5);
        public static Origin Center { get; } = new Origin(0.5, 0.5);
        public static Origin CenterRight { get; } = new Origin(1, 0.5);
        public static Origin BottomLeft { get; } = new Origin(0, 1);
        public static Origin BottomCenter { get; } = new Origin(0.5, 1);
        public static Origin BottomRight { get; } = new Origin(1, 1);
    }
}