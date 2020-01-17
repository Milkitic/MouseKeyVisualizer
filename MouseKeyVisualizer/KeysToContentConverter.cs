using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Media;

namespace MouseKeyVisualizer
{
    class KeysToContentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Keys key)
            {
                switch (key)
                {
                    case Keys.Space:
                        break;
                    case Keys.LMenu:
                    case Keys.RMenu:
                        return "Alt";
                    case Keys.Back:
                        return "←";
                    case Keys.LControlKey:
                    case Keys.RControlKey:
                        return "Ctrl";
                    case Keys.LShiftKey:
                    case Keys.RShiftKey:
                        return "Shift";
                    case Keys.Capital:
                        return "Caps";
                    case Keys.Oemtilde:
                        return "` ~";
                    case Keys.D1:
                        return "1 !";
                    case Keys.D2:
                        return "2 @";
                    case Keys.D3:
                        return "3 #";
                    case Keys.D4:
                        return "4 $";
                    case Keys.D5:
                        return "5 %";
                    case Keys.D6:
                        return "6 ^";
                    case Keys.D7:
                        return "7 &";
                    case Keys.D8:
                        return "8 *";
                    case Keys.D9:
                        return "9 (";
                    case Keys.D0:
                        return "0 )";
                    case Keys.OemMinus:
                        return "-  _";
                    case Keys.Oemplus:
                        return "=  +";
                    case Keys.OemOpenBrackets:
                        return "[  {";
                    case Keys.OemCloseBrackets:
                        return "]  }";
                    case Keys.Oem5:
                        return "\\  |";
                    case Keys.Oem1:
                        return ";  :";
                    case Keys.Oem7:
                        return "'  \"";
                    case Keys.Oemcomma:
                        return ",  <";
                    case Keys.OemPeriod:
                        return ".  >";
                    case Keys.OemQuestion:
                        return "/  ?";
                }
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
