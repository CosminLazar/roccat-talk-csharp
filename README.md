# Roccat-Talk
Allows LED illumination configuration on Roccat TalkFX enabled devices

##Installing

```powershell
Install-Package Roccat-Talk
```
[ROCCAT™ TALK® FX](http://www.roccat.org/en/Products/Gaming-Software/Talk-FX/) needs to be installed and running

## Controlling generic TalkFX enabled devices
The LED illumination settings (color, effects) on any TalkFX enabled device can be controlled via the following construct

```c#
using (var connection = new TalkFxConnection())
{
	connection.SetLedRgb(Zone.Event, KeyEffect.Blinking, Speed.Normal, new Color(255, 105, 180));
	connection.RestoreLedRgb();
}
```
It is important to call `RestoreLedRgb` when you're finished controlling the device, so that the user-configured defaults can be restored. Otherwise your settings will remain applied even after your application has terminated.

## Controlling the Ryos keyboard
The LED illumination settings (ON/OFF) on the Ryos keyboard can be controlled via the following construct
```c#
using (var connection = new RyosTalkFXConnection())
{
	connection.Initialize();
	connection.EnterSdkMode();
	
	var keyboardState = new KeyboardState();
    keyboardState.AllLedsOn();
    connection.SetWholeKeyboardState(keyboardState);
	
	connection.ExitSdkMode()
}
```
The Ryos keyboard allows for fine grained control over each LED and therefore has a more specific set of API methods. 
It is important to call `ExitSdkMode` when you're finished controlling the device, so that the user-configured defaults can be restored. Otherwise your settings will remain applied even after your application has terminated.


##Credits
The control of the keyboard is made by communicating with the [ROCCAT™ TALK® FX](http://www.roccat.org/en/Products/Gaming-Software/Talk-FX/) and using the ROCCAT™ TALK® FX SDK.

Since the SDK comprises of an unmanaged C++ class that cannot be used directly in .NET, a wrapper was needed, [talkfx-c-wrapper](https://github.com/eaceaser/talkfx-c-wrapper) was used.

##Remarks
Upon installing the nuget package, a directory labeled CroccatTalkWrapper will be added your solution. This will contain the aforementioned wrapper, which is expected to be present in the output directory.

##Contribute
Pull requests are welcomed.
*The code is tested using the Ryos ISKU FX keyboard, and could use some realworld testing on a Ryos keyboard.*