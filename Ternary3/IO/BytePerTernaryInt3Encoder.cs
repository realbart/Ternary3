using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ternary.IO
{
    /// <summary>
    /// Very lightweight encoder/decoder without any checks or optimizations.
    /// Don't use this in production code.
    /// </summary>
    public class BytePerTernaryInt3Encoder : IEncoder, IDecoder
    {
        /// <inheritdoc/>
        public void Flush(Stream binaryStream) => binaryStream.Flush();

        /// <inheritdoc/>
        public int Read(Stream binaryStream, TernaryInt3[] buffer, int offset, int count)
        {
            for (var i = 0; i < count; i++)
            {
                var @byte = binaryStream.ReadByte();
                if (@byte == -1) return i;
                buffer[i + offset] = (sbyte)@byte;
            }
            return count;
        }

        /// <inheritdoc/>
        public void Write(Stream binaryStream, TernaryInt3[] buffer, int offset, int count)
        {
            for (var i = offset; i < offset + count; i++)
            {
                binaryStream.WriteByte((byte)buffer[i]);
            }
        }
    }
}
