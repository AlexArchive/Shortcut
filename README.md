Shortcut
========

Shortcut allows you to _quickly_ and _easily_ bind a global hotkey to a callback in your application. 


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
