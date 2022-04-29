namespace Ternary3.TernaryInt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
using Ternary3.Internal;

    internal class TernaryInt64
    {
        private readonly (ulong, ulong) trits;

        public TernaryInt64((ulong, ulong) trits) => this.trits = trits;

        //public static explicit operator TernaryInt64(long value) => new TernaryInt32(value.ToUInt64s())
        public static implicit operator long(TernaryInt64 value) => value.trits.ToInt64();
    }
}
