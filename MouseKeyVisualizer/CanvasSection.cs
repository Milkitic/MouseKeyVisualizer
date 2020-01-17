using System.Collections.Generic;
using System.Windows.Forms;

namespace MouseKeyVisualizer
{
    public class CanvasSection
    {
        public List<IElement> Elements { get; set; } = new List<IElement>()
        {
            new ObservableKey(Keys.S){NodeX = 0, NodeY = 30},
            new ObservableKey(Keys.D){NodeX = 51, NodeY = 30},
            new ObservableKey(Keys.F){NodeX = 102, NodeY = 30},
            new ObservableKey(Keys.Space){NodeX = 153, NodeY = 30},
            new ObservableKey(Keys.J){NodeX = 204, NodeY = 30},
            new ObservableKey(Keys.K){NodeX = 255, NodeY = 30},
            new ObservableKey(Keys.L){NodeX = 306, NodeY = 30},
        };
    }
}