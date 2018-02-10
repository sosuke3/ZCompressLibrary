using System;
using System.Linq;
using Xunit;
using System.IO;
using ZCompressLibrary;
using Xunit.Abstractions;

namespace ZCompressLibrary.Tests
{
    public class CompressTests
    {
        readonly ITestOutputHelper output;

        public CompressTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void should_compress_array()
        {
            Random r = new Random();
            var bytes = new byte[50];
            r.NextBytes(bytes);

            var compressed = Compress.ALTTPCompressGraphics(bytes, 0, bytes.Length);
            Assert.NotNull(compressed);
        }

    }
}
