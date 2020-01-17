using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;

namespace MouseKeyVisualizer
{
    static class MouseKeyHook
    {
        private static IKeyboardMouseEvents _globalHook;

        public static event Action<object, KeyEventArgs> KeyDown;
        public static event Action<object, KeyEventArgs> KeyUp;

        public static void Subscribe()
        {
            // Note: for the application hook, use the Hook.AppEvents() instead
            _globalHook = Hook.GlobalEvents();

            _globalHook.KeyDown += GlobalHookKeyDown;
            _globalHook.KeyUp += GlobalHookKeyUp;
        }

        private static void GlobalHookKeyDown(object sender, KeyEventArgs e)
        {
            KeyDown?.Invoke(sender, e);
        }

        private static void GlobalHookKeyUp(object sender, KeyEventArgs e)
        {
            KeyUp?.Invoke(sender, e);
        }

        public static void Unsubscribe()
        {
            _globalHook.KeyDown -= GlobalHookKeyDown;
            _globalHook.KeyUp -= GlobalHookKeyUp;

            //It is recommened to dispose it
            _globalHook.Dispose();
        }
    }
}
