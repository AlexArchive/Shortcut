#Shortcut
Shortcut allows you to quickly and easily bind system-wide hot keys to callbacks defined by your application so that when the system-wide hot key in question is pressed by the end-user, the bound callback will be invoked. 

Shortcut makes use of fluent interfaces to enable the following succinct syntax:

```c#
_hotkeyBinder.Bind(hotkeyCombination).To(HotkeyCallback);
```

##How Do You Use It?


In order to use Shortcut in your own applications you must first reference the Shortcut library. Once you have referenced the Shortcut library, please follow the sample application listed below.

You could also follow the sample project (Shortcut.Demo) that is included as part of the repository download.


```c#
public partial class MainForm : Form
{
    // 1. Declare the HotkeyBinder
    private readonly HotkeyBinder _hotkeyBinder = new HotkeyBinder();
    
    ...
    
    // 2. Declare the callback method that the binder should invoke when your specified hot key is pressed.
    private static void HotkeyCallback()
    {
        MessageBox.Show("You Pressed CTRL + F!");
    }
    
    private void MainForm_Load(object sender, System.EventArgs e)
    {
        // 3. Tell the HotkeyBinder which method to bind the system-wide hot key to.
        var hotkeyCombination = new HotkeyCombination(Modifiers.Control, Keys.F);
        _hotkeyBinder.Bind(hotkeyCombination).To(HotkeyCallback);
    }
}
```
