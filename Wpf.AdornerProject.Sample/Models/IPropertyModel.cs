using System.Windows.Media;

namespace Wpf.AdornerProject.Sample.Models
{
    public interface IPropertyModel
    {
        int Id { get; set; }
        double X { get; set; }
        double Y { get; set; }
        double Width { get; set; }
        double Height { get; set; }
        double Angle { get; set; }
        double StrokeThickness { get; set; }
        string Stroke { get; set; }
        string Fill { get; set; }
        bool IsShowLable { get; set; }
        string Lable { get; set; }
        double FontSize { get; set; }
        bool IsSelected { get; set; }
    }
}