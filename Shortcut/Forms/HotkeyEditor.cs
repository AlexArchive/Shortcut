// Author: Brian Ferguson

using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Shortcut.Forms
{
    internal class HotkeyEditor : ShortcutKeysEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            var converter = new HotkeyConverter();

            var keys = (value == null) ? Keys.None : (Keys) converter.ConvertTo(value, typeof(Keys));
            value = base.EditValue(context, provider, keys);

            return converter.ConvertFrom(value);
        }
    }
}