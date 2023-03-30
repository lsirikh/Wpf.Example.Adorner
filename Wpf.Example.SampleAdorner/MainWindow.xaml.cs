using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Wpf.Example.SampleAdorner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FrameworkElement selectedElement;

        public MainWindow()
        {
            InitializeComponent();
        }



        //private void MainCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    if (e.Source.GetType() != typeof(Canvas)) 
        //    {
        //        return;
        //    }
        //    Debug.WriteLine($"{e.GetPosition(MainCanvas)}");

        //    //var hitTestResult = VisualTreeHelper.HitTest(MainCanvas, e.GetPosition(MainCanvas));
        //    VisualTreeHelper.HitTest(MainCanvas, null, HitTestCallback, new PointHitTestParameters(e.GetPosition(MainCanvas)));
        //}



        //private HitTestResultBehavior HitTestCallback(HitTestResult result)
        //{
        //    var visual = result.VisualHit ;

        //    if (selectedElement != null && selectedElement.IsMouseCaptured)
        //        selectedElement.ReleaseMouseCapture();

        //    // 적중한 개체가 Canvas 위에 있는지 확인합니다.
        //    if (visual is Canvas || FindAncestorOfType<Canvas>(visual) != null)
        //    {
        //        // Canvas 위에 있는 경우 처리합니다.
        //        // ...
        //        Debug.WriteLine($"1 {visual.GetType()}");

        //        selectedElement = FindParent<ContentControl>(visual);
        //        if (selectedElement != null)
        //            selectedElement.CaptureMouse();
        //    }
        //    else
        //    {
        //        Debug.WriteLine($"2 {visual.GetType()}");
                
        //        // Canvas 위에 없는 경우 처리하지 않습니다.
        //        return HitTestResultBehavior.Continue;
        //    }

        //    return HitTestResultBehavior.Stop;
        //}

        //public static T FindAncestorOfType<T>( DependencyObject element) where T : DependencyObject
        //{
        //    while (element != null)
        //    {
        //        if (element is T)
        //        {
        //            return (T)element;
        //        }
        //        element = VisualTreeHelper.GetParent(element);
        //    }
        //    return null;
        //}

        //public static T FindParent<T>( DependencyObject child) where T : DependencyObject
        //{
        //    DependencyObject parent = VisualTreeHelper.GetParent(child);

        //    if (parent == null) return null;

        //    T parentT = parent as T;
        //    if (parentT != null)
        //    {
        //        return parentT;
        //    }
        //    else
        //    {
        //        return FindParent<T>(parent);
        //    }
        //}
    }
}
