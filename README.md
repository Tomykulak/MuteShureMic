# MuteShureMic
For XLR users of mv7+, who want to mute the mic anyway

# First setup
- Have both XLR + USB of the microphone connected 
- Setup your XLR as a default voice device in the windows

# Edit the code
- Open the file /cSharp/MuteShureMic.cs
(Best in Visual Studio code, but notepad works fine too :)
- Look on line number: 11
    - Change the name of the USB device name of the microphone to yours
    - You can find it in the windows Sound device settings
- Save the file

# Setup the startup file to start automatically
- On your keyboard press: win + r
- Type in: cmd and press Enter
- Type in the window: cd Disk:path\to\your\cSharp file
(example is: cd C:\Users\tomas\gitProjects\MuteShureMic\cSharp)
- You can check if you are in the right directory by typing: dir or ls
- Type in the cmd: dotnet publish MuteShureMic.csproj -c Release -r win-x64 --self-contained
(to create the MuteShureMic.exe file)
- Right click the MuteShureMic.exe and choose: Create shortcut

- On your keyboard press: win + r
- Type in: shell:startup
- Copy the Shortcut of the MuteShureMic.exe you created in the previous step here