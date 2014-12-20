#Shortcut

Shortcut enables you to quickly and easily bind system-wide hotkeys to callbacks so that when the system-wide hotkey in question is pressed, the bound callback will be invoked. 

Shortcut is built in such a way that you can bind system-wide hotkeys with the following  succinct and expressive syntax:

```c#
_hotkeyBinder.Bind(Modifiers.Control, Keys.A).To(() => 
    MessageBox.Show("You pressed Control + A.");
```

##Installation

Shortcut is available to build from source or to [download manually](https://github.com/ByteBlast/Shortcut/releases), but for convenience is [available on NuGet](https://www.nuget.org/packages/Shortcut/): 


```
Install-Package Shortcut
```
##Getting Started

```c#
public partial class MainForm : Form 
{
    // Declare and instantiate the HotkeyBinder.
    private readonly HotkeyBinder _hotkeyBinder = new HotkeyBinder();
    
    // Declare the callback that you would like Shortcut to invoke when 
    // the specified system-wide hotkey is pressed.
    private static void HotkeyCallback() 
    {
        MessageBox.Show("You pressed Control + A.");
    }
    
    public MainForm() 
    {
        // Tell Shortcut to bind a specified system-wide hotkey to the
        // callback you declared earlier. 
        _hotkeyBinder.Bind(Modifiers.Control, Keys.A).To(HotkeyCallback);

        // Alternative syntax.
        // var hotkey = new Hotkey(Modiiers.Control, Keys.A); 
        // _hotkeyBinder.Bind(hotkey).To(HotkeyCallback);
    }
}
```

If you want a tangible example or to see Shortcut within the context of another UI framework, please see one of the many [demos](https://github.com/ByteBlast/Shortcut/tree/master/Demos). 

##GUI

Shortcut 2 introduced some custom controls for Windows Forms projects. One such control is the `HotkeyTextBox` which enables users to intuitively input a hotkey combination: 

![](http://i.imgur.com/AnE6hTX.png)

*(Screenshot is of [Ember](https://github.com/ByteBlast/Ember) which incidentally, is a good example of Shortcut in practice.)*

Before you can access this custom `HotkeyTextBox` control, you will need to manually add a reference to `Shortcut.dll` to your Toolbox. To do this:

1. Install Shortcut
2. Locate `Shortcut.dll` in your **bin/** folder.
2. Drag and drop `Shortcut.dll` on to the **Toolbox**.

you should now see the `HotkeyTextBox` control in your Toolbox. You can set or get the control's value via the its `Hotkey` property. 

## Misc

Shortcut does expose that many public methods however, all of those that it does are documented using XML comments. You should be able to ascertain the purpose of each method from it's name and it's accompanying documentation (visible via Intellisense). 

-----

Use the `HotkeyBinder.IsHotkeyAlreadyBound` to determine whether a system wide hotkey has already been bound either by your application.

If you want to register a system-wide hotkey comprised of more than one modifiers (for example,  `Ctrl, Alt + A`), do this: 

```c#
var hotkeyCombination = new HotkeyCombination(Modifiers.Control | Modifiers.Alt, Keys.F);
```