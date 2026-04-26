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
        private Dictionary<string, Task> clips = new Dictionary<string, Task>();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clipName"></param>
        /// <param name="soundClip"></param>
        public void RunClip(string clipName, SoundClip soundClip)
        {
            Task clip = Task.Run(soundClip.Start);
            clips[clipName] = clip;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clipName"></param>
        public void StopClip(string clipName) // Might want to add some error detection for improper names
        {
            clips[clipName].Dispose();
            clips.Remove(clipName);
        }
    }
}
