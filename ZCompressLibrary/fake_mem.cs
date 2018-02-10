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

        internal static void memcpy(byte[] dest, byte[] source, int source_offset, int length)
        {
            for(int i=0; i< length; ++i)
            {
                dest[i] = source[source_offset + i];
            }
        }

        internal static void memcpy(byte[] dest, int dest_offset, byte[] source, int length)
        {
            for (int i = 0; i < length; ++i)
            {
                dest[i + dest_offset] = source[i];
            }
        }

        // this is poorly named
        internal static void memset(List<byte> dest, byte value, int length)
        {
            for (int i = 0; i < length; ++i)
            {
                dest.Add(value);
            }
        }

        internal static void memset(int[] dest, int value, int length)
        {
            for(int i=0; i< length; ++i)
            {
                dest[i] = value;
            }
        }

        internal static void memset(byte[][] dest, byte value)
        {
            for(int i=0; i<dest.GetLength(0); ++i)
            {
                for(int j=0; j<dest[i].Length; ++j)
                {
                    dest[i][j] = value;
                }
            }
        }

        internal static bool memcmp(byte[] buf1, int buf1offset, byte[] buf2, int buf2offset, int size)
        {
            int i = 0;
            while(i < size)
            {
                if(buf1[buf1offset + i] != buf2[buf2offset +i])
                {
                    return false;
                }
                ++i;
            }

            return true;
        }
    }
}
