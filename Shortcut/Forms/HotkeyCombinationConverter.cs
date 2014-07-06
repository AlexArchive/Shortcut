// Author: Brian Ferguson

using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace Shortcut.Forms
{
    public class HotkeyCombinationConverter : KeysConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var obj = base.ConvertFrom(context, culture, value);
            if (obj == null) return null;
            return (HotkeyCombination)((Keys)obj);
        }
    }
}