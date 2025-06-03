public interface IGeometricFigure
{
    double Area { get; }
    double GetPerimeter();
    string GetInfo();
    double this[int index] { get; }
}

