using System;
using System.Linq;
using Xunit;
using System.IO;
using ZCompressLibrary;
using Xunit.Abstractions;

namespace ZCompressLibrary.Tests
{
    public class DecompressTests
    {
        readonly ITestOutputHelper output;

        public DecompressTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void should_decompress_file_moldorm_bin()
        {
            var file = File.ReadAllBytes("moldorm.bin");

            var decompressed = Decompress.ALTTPDecompressGraphics(file, 0, file.Length);
        }

        [Fact]
        public void should_decompress_file_ganon1_bin_and_be_same_as_ganon1_gfx()
        {
            var file = File.ReadAllBytes("ganon1.bin");
            var expected = File.ReadAllBytes("ganontest.gfx");

            var decompressed = Decompress.ALTTPDecompressGraphics(file, 0, file.Length);
            int i = 0;
            while(i < expected.Length && i < decompressed.Length)
            {
                if(expected[i] != decompressed[i])
                {
                    output.WriteLine($"mismatch at {i}, expected: {expected[i].ToString("X2")} decompressed: {decompressed[i].ToString("X2")}");
                }
                i++;
            }
            Assert.Equal(expected, decompressed);
        }
    }
}
