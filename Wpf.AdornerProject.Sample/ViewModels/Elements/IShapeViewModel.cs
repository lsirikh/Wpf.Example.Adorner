namespace Wpf.AdornerProject.Sample.ViewModels.Elements
{
    public interface IShapeViewModel : ISymbolViewModel
    {
        string ShapeFill { get; set; }
        string ShapeStroke { get; set; }
        double ShapeStrokeThick { get; set; }
    }
}