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
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using MouseKeyVisualizer.Annotations;
using MouseKeyVisualizer.Elements;

namespace MouseKeyVisualizer
{
    public class MainWindowVm : ViewModelBase
    {
        private ObservableCollection<ObservableKey> _observableKeys = new ObservableCollection<ObservableKey>();

        public ObservableCollection<ObservableKey> ObservableKeys
        {
            get => _observableKeys;
            set
            {
                if (Equals(value, _observableKeys)) return;
                _observableKeys = value;
                OnPropertyChanged();
            }
        }

        public Dictionary<Keys, ObservableKey> AvailableKeys { get; } = new Dictionary<Keys, ObservableKey>();

        public void SetKeyDown(Keys key)
        {
            Dispatcher.CurrentDispatcher.Invoke(() =>
            {
                if (!AvailableKeys.ContainsKey(key))
                {
                    //var observableKey = new ObservableKey(key) { IsPressing = true };
                    //_availableKeys.Add(key, observableKey);
                    //ObservableKeys.Add(observableKey);
                }
                else
                {
                    AvailableKeys[key].IsPressing = true;
                }
            });
        }

        public void SetKeyUp(Keys key)
        {
            Dispatcher.CurrentDispatcher.Invoke(() =>
            {
                if (!AvailableKeys.ContainsKey(key))
                {
                    //var observableKey = new ObservableKey(key) { IsPressing = false };
                    //_availableKeys.Add(key, observableKey);
                    //ObservableKeys.Add(observableKey);
                }
                else
                {
                    AvailableKeys[key].IsPressing = false;
                }
            });
        }
    }

    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowVm _viewModel;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnInitialized(object sender, EventArgs e)
        {
            _viewModel = (MainWindowVm)DataContext;

            MouseKeyHook.KeyDown += MouseKeyHook_KeyDown;
            MouseKeyHook.KeyUp += MouseKeyHook_KeyUp;
            MouseKeyHook.Subscribe();

            var o = AppSettings.Default.CanvasSection.Elements;
            foreach (var element in o)
            {
                if (element is ObservableKey key)
                {
                    _viewModel.ObservableKeys.Add(key);
                    _viewModel.AvailableKeys.Add(key.Key, key);
                }
            }
        }

        private void MouseKeyHook_KeyDown(object sender, KeyEventArgs e)
        {
            _viewModel.SetKeyDown(e.KeyCode);
        }

        private void MouseKeyHook_KeyUp(object sender, KeyEventArgs e)
        {
            _viewModel.SetKeyUp(e.KeyCode);
        }

        private void MainWindow_OnClosed(object sender, EventArgs e)
        {
            MouseKeyHook.Unsubscribe();
        }
    }
}
