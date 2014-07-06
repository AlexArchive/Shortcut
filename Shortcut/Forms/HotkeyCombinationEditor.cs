// Author: Brian Ferguson

using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Shortcut.Forms
{
    public class HotkeyCombinationEditor : ShortcutKeysEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            Keys keys = (value == null) ? Keys.None : (Keys)((HotkeyCombination)value);
            object obj = base.EditValue(context, provider, keys);
            return (HotkeyCombination)((Keys)obj);
        }
    }
}