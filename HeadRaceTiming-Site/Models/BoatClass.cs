using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeadRaceTimingSite.Models
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1717:Only FlagsAttribute enums should have plural names", Justification = "Not a plural")]
    public enum BoatClass
    {
        SingleScull,
        CoxlessPair,
        CoxedPair,
        DoubleScull,
        CoxlessFour,
        CoxedFour,
        QuadScull,
        Eight
    }
}
