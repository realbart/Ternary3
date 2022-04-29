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
        private readonly (ulong high, ulong low) trits;

        public TernaryInt64((ulong high, ulong low) trits) => this.trits = trits;

        public static explicit operator TernaryInt64(long value) => new TernaryInt64(value.ToTrits40());
        public static implicit operator long(TernaryInt64 value) => value.trits.ToInt64();
    }
}
