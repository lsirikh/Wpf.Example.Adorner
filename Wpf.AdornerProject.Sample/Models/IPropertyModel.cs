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
        double ShapeWidth { get; set; }
        double ShapeHeight { get; set; }
        SolidColorBrush Fill { get; set; }
        bool IsShowLable { get; set; }
        string Lable { get; set; }
        double FontSize { get; set; }
        double LableWidth { get; set; }
        double LableHeight { get; set; }
        bool IsEditable { get; set; }
        bool IsSelected { get; set; }
    }
}