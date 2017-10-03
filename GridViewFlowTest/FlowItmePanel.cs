using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace GridViewFlowTest
{
    public class FlowItmePanel : Panel
    {

        protected override Size MeasureOverride(Size availableSize)
        {
            Size s = base.MeasureOverride(availableSize);

            foreach (UIElement element in this.Children)
                element.Measure(availableSize);
            return s;
        }
        protected override Size ArrangeOverride(Size finalSize)
        {

            this.Clip = new RectangleGeometry { Rect = new Rect(0, 0, finalSize.Width, finalSize.Height) };

            foreach (FrameworkElement element in this.Children)
            {

              //  element.Arrange(new Rect(rectX, rectY, element.DesiredSize.Width, element.DesiredSize.Height));
            }
               return finalSize;
        }

    }
}
