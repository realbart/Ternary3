using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ternary.IO;
internal class ByteEnumerable: IEnumerable<byte>
{
    private readonly Stream stream;

    public ByteEnumerable(Stream stream) => this.stream = stream;

    public IEnumerator<byte> GetEnumerator() => new ByteEnumerator(stream);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
