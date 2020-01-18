namespace MouseKeyVisualizer.Elements
{
    public interface IElement
    {
        Origin Origin { get; }
        double NodeX { get; }
        double NodeY { get; }
        double NodeW { get; }
        double NodeH { get; }
    }
}