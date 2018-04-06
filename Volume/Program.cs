using AudioSwitcher.AudioApi.CoreAudio;
using System;
using System.Linq;

namespace VolumeChanger
{
    internal class VolumeChanger
    {
        private static CoreAudioDevice device = new CoreAudioController().DefaultPlaybackDevice;
        private static string[] HelpKeywords = { "-h", "--h", "help", "-help", "--help" };

        private static void Main(string[] args)
        {
            if (args.Length <= 0)
            {
                Console.WriteLine($"Current volume is {device.Volume}");
                return;
            }

            if (HelpKeywords.Select(k => k.ToLower()).Any(k => k == args[0]))
            {
                Console.WriteLine("usage: volume [--help] <number>");
                return;
            }

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