using NAudio.Wave;
using System.Threading.Channels;
namespace Project4.Core;

public static class PlaySoundTest
{
    public static async Task PlaySound(string filePath)
    {
        await Task.Run(() => DealWithSounds(filePath));
    }
    public static void DealWithSounds(string filePath)
    {
        // Create the audio file reader (supports MP3, WAV, etc.)
        using (var audioFile = new AudioFileReader(filePath))
        // Create the output device (WaveOutEvent is preferred for non-GUI threads)
        using (var waveOut = new WaveOutEvent())
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
}