using Xunit;
using Project4.Core;
namespace Project4.Test;

public class ClipHandleTests
{
    [Fact]
    public void RunClipTest() // Test if handler adds the clips to each dictionary
    {
        // Arrange
        ClipHandle clipHandler = new ClipHandle(); // Make handler
        SoundClip clip = new SoundClip("test", "..\\..\\..\\untitled.mp3", 1.00, 100); // Make new soundClip

        // Act
        clipHandler.RunClip(clip.name, clip);
        bool dClip = clipHandler.clips.Keys.ToList().Contains("test"); // Checks clips match
        bool sClip = clipHandler.soundClips["test"] == clip; // Checks soundClips match
        bool cClip = clipHandler.tokens.Keys.ToList().Contains("test"); // Check for token match

        // Assert
        Assert.True(dClip && sClip && cClip);
    }

    [Fact]
    public void StopClipTest() // Tests if handler properly removes the clip
    {
        // Arrange
        ClipHandle clipHandler = new ClipHandle(); // Make handler
        SoundClip clip = new SoundClip("test", "..\\..\\..\\untitled.mp3", 1.00, 100);

        // Act
        clipHandler.RunClip(clip.name, clip);
        clipHandler.StopClip(clip.name);
        bool dClip = clipHandler.clips.Keys.ToList().Contains("test"); // Checks clips contains test
        bool sClip = clipHandler.soundClips.Keys.ToList().Contains("test"); // Checks soundClips contains test
        bool cClip = clipHandler.tokens.Keys.ToList().Contains("test"); // Check for token contains test

        // Assert
        Assert.False(dClip && sClip && cClip);
    }
}