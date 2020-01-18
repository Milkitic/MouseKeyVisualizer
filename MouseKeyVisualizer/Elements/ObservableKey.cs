using System.Windows.Forms;
using System;

namespace MouseKeyVisualizer.Elements
{
    public class ObservableKey : ViewModelBase, IElement
    {
        private Keys _key;
        private bool _isPressing;
        private double _nodeX;
        private double _nodeY;
        private double _nodeW = 48;
        private double _nodeH = 48;

        public ObservableKey(Keys key)
        {
            _key = key;
        }

        public Keys Key
        {
            get => _key;
            set
            {
                if (value == _key) return;
                _key = value;
                OnPropertyChanged();
            }
        }

        public bool IsPressing
        {
            get => _isPressing;
            set
            {
                if (value == _isPressing) return;
                _isPressing = value;
                OnPropertyChanged();
            }
        }

        public Origin Origin { get; } = Origins.TopLeft;

        public double NodeX
        {
            get => _nodeX;
            set
            {
                if (value.Equals(_nodeX)) return;
                _nodeX = value;
                OnPropertyChanged();
            }
        }

        public double NodeY
        {
            get => _nodeY;
            set
            {
                if (value.Equals(_nodeY)) return;
                _nodeY = value;
                OnPropertyChanged();
            }
        }

        public double NodeW
        {
            get => _nodeW;
            set
            {
                if (value.Equals(_nodeW)) return;
                _nodeW = value;
                OnPropertyChanged();
            }
        }

        public double NodeH
        {
            get => _nodeH;
            set
            {
                if (value.Equals(_nodeH)) return;
                _nodeH = value;
                OnPropertyChanged();
            }
        }
    }
}