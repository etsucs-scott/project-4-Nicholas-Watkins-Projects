using Project4.Core;
using System.Runtime.CompilerServices;



SoundClip testClip = new SoundClip("..\\..\\..\\..\\..\\Audio\\cave21.mp3", 1.00, 6000);
SoundClip testClip2 = new SoundClip("..\\..\\..\\..\\..\\Audio\\hamburger-sound-effect.mp3", .15, 6000);
SoundClip testClip3 = new SoundClip("..\\..\\..\\..\\..\\Audio\\hell-naw-dog.mp3", 1.75, 6000);
SoundClip testClip4 = new SoundClip("..\\..\\..\\..\\..\\Audio\\huh-cat-meme.mp3", .05, 100);
SoundClip testClip5 = new SoundClip("..\\..\\..\\..\\..\\Audio\\darksouls.mp3", .15, 6000);

Task clip1 = Task.Run(testClip.Start);
Task clip2 = Task.Run(testClip2.Start);
Task clip3 = Task.Run(testClip3.Start);
Task clip4 = Task.Run(testClip4.Start);
Task clip5 = Task.Run(testClip5.Start);

List<SoundClip> clips = new List<SoundClip>() { testClip, testClip2, testClip3, testClip4, testClip5 };


while (true)
{
    Console.Clear();
    Console.WriteLine(testClip3.time);
    foreach (SoundClip clip in clips)
    {
        Console.WriteLine($"Clip: {clip.path} \n\t|>> Times played: {clip.timesPlayed}\n");
    }
}