namespace Wpf.AdornerProject.Sample.ViewModels.Elements
{
    public interface IShapeViewModel : IShapeBaseViewModel
    {
        bool IsEditable { get; set; }
        bool OnEditable { get; set; }
    }
}