#Shortcut
Shortcut allows you to quickly and easily bind system-wide hot keys to callbacks defined by your application so that when the system-wide hot key in question is pressed by the end-user, the bound callback will be invoked. 

Shortcut makes use of fluent interfaces to enable the following succinct syntax:

```c#
_hotkeyBinder.Bind(hotkeyCombination).To(HotkeyCallback);
```

##How Do You Use It?


In order to use Shortcut in your own applications you must first reference the Shortcut library. Once you have referenced the Shortcut library, please follow the sample application listed below.

Alternatively, you could refer to the sample project called *Shortcut.Demo* that is part of the actual repository for guidance.  


```c#
public partial class MainForm : Form
{
    // 1. Declare the Shortcut.HotkeyBinder
    private readonly HotkeyBinder _hotkeyBinder = new HotkeyBinder();
    
    ...
    
    // 2. Declare the method that you would like Shortcut to invoke when the specified hot key 
          is pressed.
    private static void HotkeyCallback()
    {
        MessageBox.Show("You Pressed CTRL + F!");
    }
    
    private void MainForm_Load(object sender, System.EventArgs e)
    {
        // 3. Tell Shortcut to bind a given hot key to the call back you defined earlier. 
        var hotkeyCombination = new HotkeyCombination(Modifiers.Control, Keys.F);
        _hotkeyBinder.Bind(hotkeyCombination).To(HotkeyCallback);
    }
}
```
