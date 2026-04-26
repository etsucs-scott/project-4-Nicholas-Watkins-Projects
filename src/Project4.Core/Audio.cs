using NAudio.Wave;
using System.Threading.Channels;
namespace Project4.Core;

/// <summary>
/// Class to play sounds from MP3 and WAV using NAudio
/// </summary>
public static class PlaySoundTest
{

    /// <summary>
    /// Plays the sound but through tasks
    /// </summary>
    /// <param name="filePath">string path to the sound file. MP3 and WAV</param>
    /// <returns></returns>
    public static async Task PlaySound(string filePath)
    {
        await Task.Run(() => DealWithSounds(filePath));
    }

    /// <summary>
    /// A static function to play a sound file from the filepath
    /// </summary>
    /// <param name="filePath">string path to the sound file. MP3 and WAV files</param>
    public static void DealWithSounds(string filePath)
    {
        // Got the following code from NAudio's website example code to play audio...

        // Create the audio file reader (supports MP3, WAV, etc.)
        using (var audioFile = new AudioFileReader(filePath))
        // Create the output device (WaveOutEvent is preferred for non-GUI threads)
        using (var waveOut = new DirectSoundOut(DirectSoundOut.Devices.ToList()[2].Guid)) //  var waveOut = new WaveOutEvent() ########################## WARNING WILL NOT WORK ON OTHER DEVICES##############
        {
            // Initialize the player with the audio stream
            waveOut.Init(audioFile);

            // Start playback (non-blocking)
            waveOut.Play();


            // Optional: Wait for playback to finish if blocking behavior is desired
            while (waveOut.PlaybackState == PlaybackState.Playing)
            {
                System.Threading.Thread.Sleep(100);
            }
        }
    }

    public static void Test()
    {
        foreach (var dev in DirectSoundOut.Devices)
        {
            Console.WriteLine($"{dev.Guid}\n{dev.ModuleName}\n{dev.Description} ||||\n");
        }
        Console.WriteLine($"!{DirectSoundOut.Devices.ToList()[2].Guid}");
    }
}