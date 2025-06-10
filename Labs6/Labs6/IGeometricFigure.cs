public interface IGeometricFigure
{
    double area { get; }
    double GetPerimeter();
    string GetInfo();
    double this[int index] { get; }
}

