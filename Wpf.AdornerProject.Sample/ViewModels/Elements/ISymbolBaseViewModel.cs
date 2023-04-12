using System.Windows;
using Wpf.AdornerProject.Sample.Models;

namespace Wpf.AdornerProject.Sample.ViewModels.Elements
{
    public interface ISymbolBaseViewModel : IPropertyModel
    {
        bool IsEditable { get; set; }
        bool OnEditable { get; set; }
        void OnClickDelete(object sender, RoutedEventArgs args);
        void OnClickEdit(object sender, RoutedEventArgs args);
        void OnClickExit(object sender, RoutedEventArgs args);
    }
}