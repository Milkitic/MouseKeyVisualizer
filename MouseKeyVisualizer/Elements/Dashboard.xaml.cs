using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MouseKeyVisualizer.Annotations;

namespace MouseKeyVisualizer.Elements
{
    public class DashboardVm : ViewModelBase
    {
        private ObservableCollection<double> _haHa = new ObservableCollection<double>();
        private ObservableCollection<double> _haHaSmall = new ObservableCollection<double>();
        private double _minValue;
        private double _maxValue;

        public DashboardVm()
        {
            MinValue = 0;
            MaxValue = 40;
            for (int i = 0; i < 40; i++)
            {
                if (i <= 30)
                {
                    if (i % 5 == 0) _haHa.Add(i);
                    else _haHaSmall.Add(i);
                }
                else if (i <= 35)
                {
                    _haHaSmall.Add(i - 0.5);
                    if (i % 5 == 0) _haHa.Add(i);
                    else _haHaSmall.Add(i);
                }
                else if (i <= 40)
                {
                    _haHaSmall.Add(i - 0.75);
                    _haHaSmall.Add(i - 0.5);
                    _haHaSmall.Add(i - 0.25);
                    if (i % 5 == 0) _haHa.Add(i);
                    else _haHaSmall.Add(i);
                }
            }
        }

        public double MinValue
        {
            get => _minValue;
            set
            {
                if (value.Equals(_minValue)) return;
                _minValue = value;
                OnPropertyChanged();
            }
        }

        public double MaxValue
        {
            get => _maxValue;
            set
            {
                if (value.Equals(_maxValue)) return;
                _maxValue = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<double> HaHa
        {
            get => _haHa;
            set
            {
                if (Equals(value, _haHa)) return;
                _haHa = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<double> HaHaSmall
        {
            get => _haHaSmall;
            set
            {
                if (Equals(value, _haHaSmall)) return;
                _haHaSmall = value;
                OnPropertyChanged();
            }
        }
    }

    /// <summary>
    /// Dashboard.xaml 的交互逻辑
    /// </summary>
    public partial class Dashboard : UserControl, IElement
    {
        private DashboardVm _viewModel;

        public Dashboard()
        {
            InitializeComponent();
        }

        public Origin Origin { get; }
        public double NodeX { get; }
        public double NodeY { get; }
        public double NodeW { get; }
        public double NodeH { get; }

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            _viewModel = (DashboardVm)DataContext;
        }
    }
}
