namespace Wpf.AdornerProject.Sample.Models
{
    public interface IShapePropertyModel : IPropertyModel
    {
        double ShapeStrokeThick { get; set; }
        string ShapeStroke { get; set; }
        string ShapeFill { get; set; }
    }
}