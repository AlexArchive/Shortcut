Shortcut
========

Shortcut makes it very easy to bind a global hotkey to a method in your application. That is, when the global hotkey is pressed your method will be called.




```c#
private readonly HotkeyBinder _hotkeyBinder = new HotkeyBinder();
```

```c#
HotkeyCombination hotkeyCombination = new HotkeyCombination(Modifiers.Control, Keys.F);
_hotkeyBinder.Bind(hotkeyCombination).To(HotkeyCallback);

private static void HotkeyCallback()
{
    MessageBox.Show("Trace: HotkeyCallback()");
}
        
```
