﻿using System;
using NAudio.CoreAudioApi;

// win+r   shell:startup
// dotnet publish MuteShureMic.csproj -c Release -r win-x64 --self-contained
class MuteShureMic
{
    static void Main(string[] args)
    {
        // Enter your device name of the mic from USB connection
        string inputUSBDeviceName = "Mikrofon (2 - Shure MV7+)";
        var enumerator = new MMDeviceEnumerator();
        var inputDevice = FindDeviceByName(enumerator, inputUSBDeviceName);
        // Make sure to setup your default device as your mic from the XLR connection
        var defaultInputDevice = enumerator.GetDefaultAudioEndpoint(DataFlow.Capture, Role.Multimedia);

        if (inputDevice == null)
        {
            Console.WriteLine($"Microphone '{inputUSBDeviceName}' not found.");
            return;
        }

        while (true) // Loop indefinitely
        {
            var inputVolume = inputDevice.AudioEndpointVolume;
            bool isMuted = inputVolume.Mute;

            // Mute/unmute the default input device based on the microphone's mute status
            defaultInputDevice.AudioEndpointVolume.Mute = isMuted;

            Thread.Sleep(1000); // Sleep for 1 seconds before the next check
        }
    }

    static MMDevice FindDeviceByName(MMDeviceEnumerator enumerator, string deviceName)
    {
        var inputDevices = enumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active);
        foreach (var device in inputDevices)
        {
            if (device.FriendlyName.Contains(deviceName))
            {
                return device;
            }
        }
        return null;
    }
}