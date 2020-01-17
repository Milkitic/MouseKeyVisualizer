using System;
using System.Windows.Forms;

namespace MouseKeyVisualizer
{
    public class ObservableKey : ViewModelBase, IElement
    {
        private Keys _key;
        private bool _isPressing;
        private double _nodeX;
        private double _nodeY;

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
    }
}