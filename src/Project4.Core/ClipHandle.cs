using System;
using System.Collections.Generic;
using System.Text;

namespace Project4.Core
{
    /// <summary>
    /// A class to handle the clips that are being played
    /// </summary>
    public class ClipHandle
    {
        public Dictionary<string, Task> clips { get; private set; } = new Dictionary<string, Task>();
        public Dictionary<string, SoundClip> soundClips { get; private set; } = new Dictionary<string, SoundClip>();
        public Dictionary<string, CancellationTokenSource> tokens { get; private set; } = new Dictionary<string, CancellationTokenSource>();
        
        /// <summary>
        /// Runs the clip using the name and SoundClip and updates the internal dictionary and makes a cancellation token
        /// </summary>
        /// <param name="clipName">The name of the clip</param>
        /// <param name="soundClip">The soundclip class object associated to the name</param>
        public void RunClip(string clipName, SoundClip soundClip)
        {
            var token = new CancellationTokenSource();
            tokens[clipName] = token;
            
            Task clip = Task.Run(async () =>
            {
                soundClip.Start(token);
            }, token.Token);

            clips[clipName] = clip;
            soundClips[clipName] = soundClip;
        }

        /// <summary>
        /// Stops the clip with the name 
        /// </summary>
        /// <param name="clipName">The name of clip</param>
        public void StopClip(string clipName) // Might want to add some error detection for improper names
        {
            var token = tokens[clipName];
            token.Cancel();
            clips.Remove(clipName);
            soundClips.Remove(clipName);
            tokens.Remove(clipName);
        }
    }
}
