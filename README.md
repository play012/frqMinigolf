# Pitch detection Minigolf

Please install Unity 6 and Max 9 to play this project. The Unity project is built on version 6000.0.25f1.

The Max 9 Patch starts by getting a microphone input and publishes a frequency number of the loudest pitch with OpenSoundControl on localhost
(There is an additional patch for a MIDI controller input to use a cycle~ generated sound, the launchpad used is a Akai MPD218).
Unity uses the extOSC module to receive the message and runs a golf swing animation on a 10 second countdown timer.
The game logic is saved under `Assets/Scripts/FrqMinigolf.cs` and the setup should look like this:

![Setup](https://github.com/play012/frqMinigolf/blob/main/MinigolfDemo.jpg)
