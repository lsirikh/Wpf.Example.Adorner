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

namespace Wpf.Example.OnCavas.RotateAdorner
{
    /// <summary>
    /// Interaction logic for CanvasWindow.xaml
    /// </summary>
    public partial class CanvasWindow : Window
    {
        private RotateAdorner _rotateAdorner;

        public CanvasWindow()
        {
            InitializeComponent();

            // Mouse 이벤트를 구독합니다.
        }


        // Canvas에서 마우스 왼쪽 버튼을 놓을 때 실행되는 이벤트입니다.
        private void MyCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // 선택한 UIElement에 RotateAdorner를 추가하거나 제거합니다.
            ToggleRotateAdorner(myRectangle);
        }

        // 선택한 UIElement에 RotateAdorner를 추가하거나 제거하는 메서드입니다.
        private void ToggleRotateAdorner(UIElement element)
        {
            var adornerLayer = AdornerLayer.GetAdornerLayer(element);
            Adorner[] adorners = adornerLayer.GetAdorners(element);

            // 이미 RotateAdorner가 있다면 제거하고, 없다면 추가합니다.
            if (adorners != null)
            {
                bool hasRotateAdorner = false;
                foreach (var adorner in adorners)
                {
                    if (adorner is RotateAdorner)
                    {
                        adornerLayer.Remove(adorner);
                        hasRotateAdorner = true;
                        break;
                    }
                }

                if (!hasRotateAdorner)
                {
                    adornerLayer.Add(new RotateAdorner(element));
                }
            }
            else
            {
                adornerLayer.Add(new RotateAdorner(element));
            }
        }
    }
}
