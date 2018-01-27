using System;
using System.Collections.Generic;
using System.Text;

namespace ZCompressLibrary
{
    internal static class fake_mem
    {
        internal static void memcpy(List<byte> dest, byte[] source, int source_offset, int length)
        {
            for (int i = 0; i < length; ++i)
            {
                dest.Add(source[source_offset + i]);
            }
        }

        internal static void memset(List<byte> dest, byte value, int length)
        {
            for (int i = 0; i < length; i++)
            {
                dest.Add(value);
            }
        }
    }
}
