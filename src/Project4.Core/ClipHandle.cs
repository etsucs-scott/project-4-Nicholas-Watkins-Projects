using System;
using System.Collections.Generic;
using System.Text;

namespace Project4.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class ClipHandle
    {
        public Dictionary<string, Task> clips { get; private set; } = new Dictionary<string, Task>();
        public Dictionary<string, SoundClip> soundClips { get; private set; } = new Dictionary<string, SoundClip>();
        public Dictionary<string, CancellationTokenSource> tokens { get; private set; } = new Dictionary<string, CancellationTokenSource>();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clipName"></param>
        /// <param name="soundClip"></param>
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
        /// 
        /// </summary>
        /// <param name="clipName"></param>
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
