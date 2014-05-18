#Shortcut
Shortcut allows you to quickly and easily bind system-wide hotkeys (sometimes called global hotkeys) to callbacks defined by your application so that when the system-wide hot key in question is pressed, the bound callback will be invoked. 

Shortcut makes use of *fluent interfaces* to enable the following succinct syntax:

```c#
_hotkeyBinder.Bind(hotkeyCombination).To(HotkeyCallback);
```

##How Do You Use It?


In order to use Shortcut in your applications you must first [download](https://github.com/ByteBlast/Shortcut/archive/master.zip) and  [reference](http://msdn.microsoft.com/en-us/library/wkze6zky.aspx) the Shortcut class library. Once you have referenced the Shortcut class library, consider the following listing: 


```c#
public partial class MainForm : Form {

    // 1. Declare the Shortcut.HotkeyBinder.
    //
    private readonly HotkeyBinder _hotkeyBinder = new HotkeyBinder();
    
    // 2. Declare the callback that you would like Shortcut to invoke when 
    // the specified system-wide hotkey is pressed.
    //
    private static void HotkeyCallback() {
        MessageBox.Show("You pressed a system-wide hot key!");
    }
    
    private void MainForm_Load(object sender, System.EventArgs e) {
    
        // 3. Tell Shortcut to bind the specified system-wide hot key to the
        // callback you defined earlier. 
        //
        var hotkeyCombination = new HotkeyCombination(Modifiers.Control, Keys.F);
        _hotkeyBinder.Bind(hotkeyCombination).To(HotkeyCallback);
    
        // 4. Alternative syntax.
        //
        // _hotkeyBinder.Bind(Modifiers.Control | Modifiers.Shift, Keys.A).To(HotkeyCallback);    
    }
}
```
Alternatively, you could refer to the sample project called *[Shortcut.Demo](https://github.com/ByteBlast/Shortcut/blob/master/src/Shortcut.Demo/Forms/MainForm.cs)* that can be found in the project repository for guidance.

##Documentation

Shortcut does not expose that many public members however, all of those that it does are decorated with XML comments. Some public methods that you should be aware of are as followed:

| Method                              | Description                                                          |
| ----------------------------------- |:--------------------------------------------------------------------:|
| `HotkeyBinder.Bind`                 | Create a system-wide hot key binding                                 |
| `HotkeyBinder.Unbind`               | Remove a binding                                                     |
| `HotkeyBinder.IsHotkeyAlreadyBoun`  | Determine whether a system-wide hot key has already been bound       | 

Contributions of any kind (issues, pull requests etc.) are encouraged :D
