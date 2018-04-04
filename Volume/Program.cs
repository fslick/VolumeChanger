using AudioSwitcher.AudioApi.CoreAudio;
using System;

namespace SetVolume
{
    internal class VolumeSetter
    {
        private static CoreAudioDevice device = new CoreAudioController().DefaultPlaybackDevice;

        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine($"Current volume is {device.Volume}");
                return;
            }
            else
            {
                double newVolume = 0;
                if (Double.TryParse(args[0], out newVolume))
                {
                    double previousVolume = device.Volume;
                    device.Volume = newVolume;
                    Console.WriteLine($"Volume was changed from {previousVolume} to {device.Volume}");
                }
                else
                {
                    Console.WriteLine($"Volume ({device.Volume}) wasn't changed because '{args[0]}' could not be parsed into a number.");
                }
            }
        }
    }
}