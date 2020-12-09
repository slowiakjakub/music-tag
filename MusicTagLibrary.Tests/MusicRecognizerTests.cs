using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MusicTagLibrary.Tests
{
    public class MusicRecognizerTests
    {
        [Fact]
        public async void RunMusicTagForAudioFileAsync_ShouldWorkWithMp3Song()
        {
            //Arrange
            string filePath = $@"{Directory.GetCurrentDirectory()}\TestSet\SongsMp3\prelude.mp3";
            string expected = "Kevin MacLeod- Prelude";

            //Act
            await MusicRecognizer.RunMusicTagForAudioFileAsync(filePath);

            //Assert
            Assert.Equal(expected, "test");
        }
    }
}
