using Project4.Core;
using System.Runtime.CompilerServices;


Saver saves = new Saver();
ClipHandle clipHandler = new ClipHandle();


SoundClip testClip = new SoundClip("cave", "..\\..\\..\\..\\..\\Audio\\cave21.mp3", 1.00, 6000);
SoundClip testClip2 = new SoundClip("hamburger", "..\\..\\..\\..\\..\\Audio\\hamburger-sound-effect.mp3", .15, 6000);
SoundClip testClip3 = new SoundClip("naw", "..\\..\\..\\..\\..\\Audio\\hell-naw-dog.mp3", 1.75, 6000);
SoundClip testClip4 = new SoundClip("huh", "..\\..\\..\\..\\..\\Audio\\huh-cat-meme.mp3", .05, 100);
SoundClip testClip5 = new SoundClip("darksouls", "..\\..\\..\\..\\..\\Audio\\darksouls.mp3", .15, 6000);


List<SoundClip> soundClips = new List<SoundClip>() { testClip, testClip2, testClip3, testClip4, testClip5 };

for (int i = 0; i < soundClips.Count(); i++)
    clipHandler.RunClip(soundClips[i].name, soundClips[i]);


while (true)
{
    Console.Clear();
    Console.WriteLine(testClip3.time);
    foreach (SoundClip clip in soundClips)
    {
        Console.WriteLine($"Clip: {clip.path} \n\t|>> Times played: {clip.timesPlayed}\n");
    }
}