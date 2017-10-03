using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace GridViewFlowTest
{
    public sealed class VariableGrid : GridView
    {
        public VariableGrid()
        {
            this.DefaultStyleKey = typeof(VariableGrid);
        }
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            var list = this.ItemsSource as List<string>;      
            var griditem = element as GridViewItem;
            for (var t = (list.Count - list.Count % 4); t < list.Count; t++)
            {
                if (item as string == list[t])
                {
                    if (griditem != null)
                    {
                        VariableSizedWrapGrid.SetColumnSpan(griditem, 2);
                    }
                }
            }
            base.PrepareContainerForItemOverride(element, item);
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            return base.MeasureOverride(availableSize);


        }
        protected override Size ArrangeOverride(Size finalSize)
        {

            this.Clip = new RectangleGeometry { Rect = new Rect(0, 0, finalSize.Width, finalSize.Height) };

            foreach (FrameworkElement element in this.ItemsPanelRoot.Children)
            {
                var list = this.ItemsSource as List<string>;
              
                for (var t = ((list.Count - list.Count % 4)); t < list.Count; t++)
                {
                   
                }
              //  element.Arrange(new Rect(rectX, rectY, element.DesiredSize.Width, element.DesiredSize.Height));
            }
                return base.ArrangeOverride(finalSize);
        }
       
    }
}
