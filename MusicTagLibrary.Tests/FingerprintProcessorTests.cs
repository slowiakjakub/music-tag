using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using MusicTagLibrary;
using MusicTagLibrary.AudioProcessing;
using System.IO;

namespace MusicTagLibrary.Tests
{
    public class FingerprintProcessorTests
    {
        [Fact]
        public void GetFingerprintFromFile_ShouldCorrectlyCalculateSimpleFingerprint()
        {
            //Arrange
           string expected
                = "AQAA1bkiiUuSJAiatUT4F4-U41I--Bv-4KoqWLPw2sKl7PgOzc3RRE80XFD6MHhoeMwJvviOhlmL6sKlw9p23Mc_9C-08BWO_C3SiiW-WPCpGm_BTlFUXIe-o18gFjp8_JB3-Djkw8TxUYfrB89xQsf_CP5xZTuy4zhS22i5oz_84BkB68dxwT8--MAP7eh1-MeHwzmh6UCtHqmKi8Zx4_CFD-kDMzou-BDV4sQXHi8h-_hzfPgP-ME5mC_e4MR94XgVXMeP0zAeHPVwCc3R8yCn40SPB4AN-DyO67Ap5ES-w0f7oIbowCcO6wkOtDp0dD-2o13QE0UP6-h3HD1sEe3RdbDDpMEvOM_xHT-O02rg59BGHfjQnNAeTFUCn8elw4-JlviP_jjEM9APXINP9ENPHXZ6HHmQ_kGPx-gPO4Ru4R7wQz-OE36CGz9w_DmOa8fLw_sPAKGAMgQgAwAgwDAhFFFGAEGYAIApA5RAgjgAhEeCKOMQFOSQIAhDTAFglBCCKioEs8wAhwBDwhlGDAIOASoUN8oihDByRghDhHIECmQIcgi4o5QQzynHiEGMU-GwM8QYDYAYTkMDkGCUELKAMwYgYwAFSCAGFBBOIIGIQBQopQQRwDkiDDNCSWGA0c4gQQk1QFAFiBBAAA";

            string filePath = $@"{Directory.GetCurrentDirectory()}\TestSet\SimpleSounds\ExampleSound.mp3";
            NAudioDecoder decodedFile = new NAudioDecoder(filePath);
            //Act
            string actual = FingerprintProcessor.GetFingerprintFromFile(decodedFile);

            //Assert 
            Assert.Equal(expected, actual);

            
        }
    }
}
