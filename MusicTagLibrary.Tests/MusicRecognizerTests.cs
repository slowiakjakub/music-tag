using MusicTagLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MusicTagLibrary.Tests
{
    public class MusicRecognizerTests
    {
        [Fact]
        public async Task RunMusicTagForAudioFileAsync_ShouldWorkWithMp3Song()
        {
            //Arrange
            APIHelper.InitializeClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            string filePath = $@"{Directory.GetCurrentDirectory()}\TestSet\SongsMp3\prelude.mp3";
            string expected = "Kevin MacLeod - Prelude";

            //Act
            await MusicRecognizer.RunMusicTagForAudioFileAsync(filePath);

            //Assert
            Assert.Equal(expected, "test");
        }

    }
}
