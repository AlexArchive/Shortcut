#Shortcut
Shortcut allows you to quickly and easily bind system wide hotkeys (sometimes called global hotkeys) to callbacks defined by your application so that when the system wide hotkey in question is pressed, the bound callback will be invoked. 

Shortcut makes use of *fluent interfaces* to enable the following succinct syntax:

```c#
_hotkeyBinder.Bind(hotkeyCombination).To(HotkeyCallback);
```

##Quick Start


In order to use Shortcut in your applications you must first [download](https://github.com/ByteBlast/Shortcut/archive/master.zip) and  [reference](http://msdn.microsoft.com/en-us/library/wkze6zky.aspx) the Shortcut class library. Once you have referenced the Shortcut class library, consider the following listing: 


```c#
public partial class MainForm : Form {

    // 1. Declare the HotkeyBinder.
    //
    private readonly HotkeyBinder _hotkeyBinder = new HotkeyBinder();
    
    // 2. Declare the callback that you would like Shortcut to invoke when 
    // the specified system wide hotkey is pressed.
    //
    private static void HotkeyCallback() {
        MessageBox.Show("You pressed a system wide (sometimes called global) hot key!");
    }
    
    public MainForm() {
        // 3. Tell Shortcut to bind the specified system wide hotkey to the
        // callback you declared earlier. 
        //
        var hotkeyCombination = new HotkeyCombination(Modifiers.Control, Keys.F);
        _hotkeyBinder.Bind(hotkeyCombination).To(HotkeyCallback);
    }
}
```
> Note that it is advisable  to **register system wide hotkeys in the constructor and not the FormLoad event handler** due to an [obscure system bug](http://connect.microsoft.com/VisualStudio/feedback/details/325742/exception-assistant-dialog-box-doesnt-appear-when-debugging-in-vb2008-express) that will cause your program to hang instead of throw an exception if an already bound system wide hotkey is registered.

Alternatively, you could refer to the sample project  *[Shortcut.Demo](https://github.com/ByteBlast/Shortcut/blob/master/src/Shortcut.Demo/Forms/MainForm.cs)* for guidance.

##Documentation


Shortcut does not expose that many public members however, all of those that it does are decorated with XML comments. Some public methods that you should be aware of are as followed:

Use `HotkeyBinder.IsHotkeyAlreadyBound` to determine whether a system wide hotkey has already been bound.

If you want to register a system wide hotkey comprised of multiple modifiers (e.g. Ctrl, Alt + A), do this: 

```c#
var hotkeyCombination = new HotkeyCombination(Modifiers.Control | Modifiers.Alt, Keys.F);
```
