using Project4.Core;
using Xunit;
namespace Project4.Test;

public class SoundClipTests
{
    [Fact]
    public void StartCancelTest() // Check if clip will stop when canceled
    {
        // Arrange
        SoundClip clip = new SoundClip("test", "..\\..\\..\\untitled.mp3", 1.00, 100); // Make new soundClip
        var token = new CancellationTokenSource(); // Make cancellation token


        // Act
        Task tClip = Task.Run(async () =>
        {
            clip.Start(token);
        }, token.Token); // Run token

        Thread.Sleep(7000); // Wait 7 seconds | Full clip 
        token.Cancel(); // Send cancel
        Thread.Sleep(1000); // Wait 1 seconds


        // Assert
        Assert.True(tClip.IsCompleted);
    }

    [Fact]
    public void StartNotCanceledTest() // Check if clip will continue playing until canceled
    {
        // Arrange
        SoundClip clip = new SoundClip("test", "..\\..\\..\\untitled.mp3", 1.00, 100); // Make new soundClip
        var token = new CancellationTokenSource(); // Make cancellation token


        // Act
        Task tClip = Task.Run(async () =>
        {
            clip.Start(token);
        }, token.Token); // Run token


        // Assert
        Assert.False(tClip.IsCompleted);
        token.Cancel();
    }
}