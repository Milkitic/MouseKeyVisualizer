using System.Collections.Generic;
using System.Windows.Forms;
using MouseKeyVisualizer.Elements;

namespace MouseKeyVisualizer
{
    public class CanvasSection
    {
        public List<IElement> Elements { get; set; } = new List<IElement>()
        {
            new ObservableKey(Keys.A) {NodeX = 1550, NodeY = 930},
            new ObservableKey(Keys.S) {NodeX = 1601, NodeY = 930},
            new ObservableKey(Keys.D) {NodeX = 1652, NodeY = 930},
            new ObservableKey(Keys.Space) {NodeX = 1618, NodeY = 990, NodeW = 198},
            new ObservableKey(Keys.J) {NodeX = 1734, NodeY = 930},
            new ObservableKey(Keys.K) {NodeX = 1785, NodeY = 930},
            new ObservableKey(Keys.L) {NodeX = 1836, NodeY = 930},
        };
    }
}